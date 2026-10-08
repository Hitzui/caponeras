using Caponeras.App.Dto;
using Caponeras.App.Helpers;
using Caponeras.App.Services;
using System.IO;
using System.Net.Http;
using System.Text.Json;

namespace Caponeras.App.ViewModels.Conductores;

public class ConductorLicenciaFormViewModel : BaseViewModel
{
    private ConductoresService _conductoresService;
    private readonly INavigationService _navigationService;
    private readonly HttpClient _client;

    public ConductorLicenciaFormViewModel(ConductoresService conductoresService, INavigationService navigationService,
        HttpClient client)
    {
        _conductoresService = conductoresService;
        _navigationService = navigationService;
        _client = client;
    }

    public ConductoresDto? ConductorDto { get; private set; }

    private ConductorLicenciasDto? _conductorLicenciasDto;

    public ConductorLicenciasDto? ConductorLicenciaDto
    {
        get => _conductorLicenciasDto;
        set => SetValue(ref _conductorLicenciasDto, value);
    }

    public void LoadCadete()
    {
        ConductorDto = _navigationService.Query as ConductoresDto;
        if (ConductorDto is null) return;
        ConductorLicenciaDto = _conductoresService.FindLicencia(ConductorDto.Idconductor);
    }

    public async Task<string?> SubirImagenAsync(Image imagen, int idConductor, string tipo)
    {
        using var client = new HttpClient();
        using var content = new MultipartFormDataContent();

        var imageBytes = ImageToByteArray(imagen);

        var imageContent = new ByteArrayContent(imageBytes);

        imageContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("image/jpeg");

        content.Add(imageContent, "imagen", $"{tipo}.jpg");
        content.Add(new StringContent(idConductor.ToString()), "idconductor");
        content.Add(new StringContent("licencia"), "documento");
        content.Add(new StringContent(tipo), "tipo");

        var response = await client.PostAsync(
            "https://orobestni.com/caponeras/api-cadetes/upload",
            content);

        if (!response.IsSuccessStatusCode)
            return null;

        var json = await response.Content.ReadAsStringAsync();

        var result = JsonSerializer.Deserialize<UploadResponse>(
            json,
            options: new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            }
        );

        return result?.Url;
    }


    private byte[] ImageToByteArray(Image image)
    {
        using var ms = new MemoryStream();
        image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
        return ms.ToArray();
    }

    public async Task SaveLicencia(ConductorLicenciasDto licencia, Image? fotoFrente, Image? fotoTrasera)
    {
        string? urlFrente = null;
        string? urlTrasera = null;

        if (fotoFrente is not null)
        {
            urlFrente = await SubirImagenAsync(
                fotoFrente,
                licencia.Idconductor,
                "frente");
        }

        if (fotoTrasera is not null)
        {
            urlTrasera = await SubirImagenAsync(
                fotoTrasera,
                licencia.Idconductor,
                "reverso");
        }

        licencia.FotoLicenciaFrente = urlFrente ?? "";
        licencia.FotoLicenciaReverso = urlTrasera ?? "";

        var save = await _conductoresService.SaveLicencia(licencia);
        if (save)
        {
            GetMessageAlert(
                TypeAlert.Success,
                "Guardar",
                "Se han guardado los datos de la licencia de forma correcta",
                _navigationService.MainView
            );
        }
        else
        {
            GetMessageAlert(
                TypeAlert.Error,
                "Error",
                $"No se pudieron guardar los datos de la licencia. {_conductoresService.ErrorMessage}",
                _navigationService.MainView
            );
        }
    }

    public Task<Image?> CargarImagenAsync(string? url)
    {
        return HelperMethods.CargarImagenAsync(url, _client);
    }
}