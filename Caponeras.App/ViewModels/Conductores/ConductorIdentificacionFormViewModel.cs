using Caponeras.App.Dto;
using Caponeras.App.Helpers;
using Caponeras.App.Services;
using System.IO;
using System.Net.Http;
using System.Text.Json;

namespace Caponeras.App.ViewModels.Conductores;

public class ConductorIdentificacionFormViewModel : BaseViewModel
{
    private ConductoresService _conductoresService;
    private INavigationService _navigationService;
    private readonly HttpClient _client;
    private ConductorIdentificacionsDto? _conductorIdentificacionsDto;

    public ConductorIdentificacionFormViewModel(ConductoresService conductoresService,
        INavigationService navigationService, HttpClient client)
    {
        _conductoresService = conductoresService;
        _navigationService = navigationService;
        _client = client;
    }

    public ConductoresDto? ConductorDto { get; private set; }

    public ConductorIdentificacionsDto? ConductorIdentificacionsDto
    {
        get => _conductorIdentificacionsDto;
        set => SetValue(ref _conductorIdentificacionsDto, value);
    }

    public async Task Load()
    {
        ConductorDto = _navigationService.Query as ConductoresDto;
        if (ConductorDto is not null)
        {
            ConductorIdentificacionsDto = await _conductoresService.FindIdentificacion(ConductorDto.Idconductor);
        }
    }

    public Task<Image?> CargarImagenAsync(string? url)
    {
        return HelperMethods.CargarImagenAsync(url, _client);
    }

    public async Task SaveIdentificacion(Image? fotoFrente, Image? fotoTrasera)
    {
        if (ConductorIdentificacionsDto is null)
        {
            GetMessageAlert(TypeAlert.Warning, "Guardar", "No hay identificación para guardar",
                _navigationService.MainView);
            return;
        }

        var identificacion = ConductorIdentificacionsDto;
        if (identificacion is null) return;
        string? urlFrente = null;
        string? urlTrasera = null;

        if (fotoFrente is not null)
        {
            urlFrente = await SubirImagenAsync(
                fotoFrente,
                identificacion.Idconductor,
                "frente");
        }

        if (fotoTrasera is not null)
        {
            urlTrasera = await SubirImagenAsync(
                fotoTrasera,
                identificacion.Idconductor,
                "reverso");
        }

        identificacion.FotoFrente = urlFrente ?? string.Empty;
        identificacion.FotoReverso = urlTrasera ?? string.Empty;
        var save = await _conductoresService.SaveIdentificacion(identificacion);
        if (save)
        {
            GetMessageAlert(
                TypeAlert.Success,
                "Guardar",
                "Se han guardado los datos de la idenficacion de forma correcta",
                _navigationService.MainView);
        }
        else
        {
            GetMessageAlert(
                TypeAlert.Error,
                "Error",
                $"No fue posible guardar: {_conductoresService.ErrorMessage}",
                _navigationService.MainView);
        }
    }

    private async Task<string?> SubirImagenAsync(Image imagen, int idConductor, string tipo)
    {
        using var content = new MultipartFormDataContent();
        var imageBytes = ImageToByteArray(imagen);
        var imageContent = new ByteArrayContent(imageBytes);
        imageContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("image/jpeg");

        content.Add(imageContent, "imagen", $"{tipo}.jpg");
        content.Add(new StringContent(idConductor.ToString()), "idconductor");
        content.Add(new StringContent("identificacion"), "documento");
        content.Add(new StringContent(tipo), "tipo");

        var response = await _client.PostAsync(
            requestUri: "https://orobestni.com/caponeras/api-cadetes/upload",
            content: content
        );

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
}