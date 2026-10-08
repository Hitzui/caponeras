using Caponeras.App.Dto;
using Caponeras.App.Helpers;
using Caponeras.App.Services;
using Caponeras.App.Views.Conductores;
using DevExpress.Mvvm;
using NLog;
using System.ComponentModel;
using System.Diagnostics;
using System.Net.Http;
using Caponeras.App.Views.Reportes.Cadetes;
using DevExpress.XtraEditors;
using static Caponeras.App.ViewModels.Conductores.CadetesFormViewModel;
using INavigationService = Caponeras.App.Helpers.INavigationService;

namespace Caponeras.App.ViewModels.Conductores;

public class ConductoresViewModel : BaseViewModel
{
    private readonly ILogger _logger = LogManager.GetCurrentClassLogger();
    private readonly ConductoresService _conductoresService;
    private readonly SemaphoreSlim _loadLock = new(1, 1);
    private readonly INavigationService _navigationService;
    private readonly HttpClient _client;
    private ConductoresDto _condutorDto;

    public BindingList<ConductoresDto> Conductores { get; }
        = new();

    public ConductoresViewModel(ConductoresService conductoresService, INavigationService navigationService, HttpClient client)
    {
        _conductoresService = conductoresService;
        _navigationService = navigationService;
        _client = client;
        Messenger.Default.Register<CadeteAgregadoMessage>(
            this,
            async void (_) =>
            {
                try
                {
                    await LoadAsync();
                }
                catch (Exception e)
                {
                    _logger.Error(e);
                }
            }
        );
    }

    public void SetSelectedItem(ConductoresDto selected)
    {
        _navigationService.Query = selected;
        CondutorDto = selected;
    }

    public ConductoresDto CondutorDto
    {
        get => _condutorDto;
        set => SetProperty(ref _condutorDto, value, "CondutorDto");
    }

    public async Task LoadAsync()
    {
        await _loadLock.WaitAsync();
        try
        {
            var lista = await _conductoresService.GetAllTask();

            Conductores.Clear();
            foreach (var c in lista)
                Conductores.Add(c);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
        }
        finally
        {
            _loadLock.Release();
        }
    }

    public void ShowForm()
    {
        _navigationService.ShowDialog<CadeteFormView>(query: CondutorDto);
    }

    public void ShowFormLicencia()
    {
        _navigationService.ShowDialog<ConductorLicenciaFormView>(query: CondutorDto);
    }

    public void ShowFormIdentificacion()
    {
        _navigationService.ShowDialog<ConductorIdentificacionFormView>(query: CondutorDto);
    }

    public async Task Delete()
    {
        try
        {
            if (_navigationService.Query is not ConductoresDto selected)
            {
                GetMessageAlert(TypeAlert.Warning, "Inactivar", "Seleccione un cadete.", _navigationService.MainView);
                return;
            }

            var result = await _conductoresService.Delete(selected);
            if (result > 0)
            {
                GetMessageAlert(TypeAlert.Success, "Inactivar", "El cadete quedó inactivo y se conservaron sus registros.",
                    _navigationService.MainView);
                await LoadAsync();
            }
            else
                GetMessageAlert(TypeAlert.Error, "Inactivar", "No fue posible inactivar el cadete.", _navigationService.MainView);
        }
        catch (Exception e)
        {
            _logger.Error(e);
            GetMessageAlert(TypeAlert.Error, "Inactivar",
                $"No fue posible inactivar el cadete: {e.GetBaseException().Message}", _navigationService.MainView);
        }
    }

    public async Task ShowReporteCadete()
    {
        var informacionCadete = await _conductoresService.GetInformacionCadete(CondutorDto.Idconductor);

        if (informacionCadete is null)
        {
            XtraMessageBox.Show(
                "No se encontró información del cadete.",
                "Información",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            return;
        }

        var reporte = new ReportDatosCadete();
        if (informacionCadete.Identificacion is not null)
        {
            informacionCadete.Identificacion.FotoIdentificacionFrenteImage = 
                await HelperMethods.CargarImagenAsync(informacionCadete.Identificacion.FotoFrente, _client);
            informacionCadete.Identificacion.FotoIdentificacionReversoImage = 
                await HelperMethods.CargarImagenAsync(informacionCadete.Identificacion.FotoReverso, _client);
        }
        reporte.DataSource = new [] { informacionCadete };

        HelperMethods.LoadReport(reporte, "Datos del Cadete");
    }
}
