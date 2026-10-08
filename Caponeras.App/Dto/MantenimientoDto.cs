using Caponeras.Data.Models;

namespace Caponeras.App.Dto;

public class MantenimientoDto
{
    public MantenimientoDto()
    {
    }

    public int Idmantenimiento { get; set; }

    public int Idvehiculo { get; set; }

    public int Idtipomantenimiento { get; set; }

    public string Titulo { get; set; }

    public DateTime FechaInicio { get; set; }

    public DateTime FechaFin { get; set; }

    public string Descripcion { get; set; }

    public string Observaciones { get; set; }

    public string Color { get; set; }

    public int Idusuario { get; set; }

    public int? Idlabel { get; set; }

    public int Idstatus { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public Usuarios? Usuarios { get; set; }

    public VehiculosDto? VehiculoDto { get; set; }

    public MantenimientoLabelDto? MantenimientoLabelDto { get; set; }

    public MantenimientoStatusDto? MantenimientoStatusDto { get; set; }

    public TipoMantenimientos? TipoMantenimientos { get; set; }

    public MantenimientoDto(Mantenimientos m)
    {
        if (m == null)
            throw new ArgumentNullException(nameof(m));

        Idmantenimiento = m.Idmantenimineto;
        Idvehiculo = m.Idvehiculo;
        Idtipomantenimiento = m.Idtipomantenimiento;
        Idlabel = m.Idlabel;
        Idstatus = m.Idstatus ?? 0;
        Titulo = m.Titulo;
        FechaInicio = m.FechaInicio;
        FechaFin = m.FechaFin;
        Descripcion = m.Descripcion;
        Observaciones = m.Observaciones;
        Color = m.Color;
        Idusuario = m.Idusuario;
        CreatedAt = m.CreatedAt;
        UpdatedAt = m.UpdatedAt;
        if (m.MantenimientoStatuses is not null)
        {
            MantenimientoStatusDto = new MantenimientoStatusDto(
                m.MantenimientoStatuses.Id,
                m.MantenimientoStatuses.DisplayName, 
                ColorTranslator.FromHtml(m.MantenimientoStatuses.Brush),
                m.MantenimientoStatuses.MenuCaption, 
                m.MantenimientoStatuses.AllowDrag
                );
        }

        if (m.MantenimientoLabels is not null)
        {
            MantenimientoLabelDto = new MantenimientoLabelDto(m.MantenimientoLabels.Id,
                ColorTranslator.FromHtml(m.MantenimientoLabels.Color), m.MantenimientoLabels.DisplayName,
                m.MantenimientoLabels.MenuCaption);
        }

        if (m.Vehiculos is not null)
        {
            VehiculoDto = new VehiculosDto(m.Vehiculos);
        }
    }

    public Mantenimientos Model()
    {
        return new Mantenimientos
        {
            Idmantenimineto = Idmantenimiento,
            Idvehiculo = Idvehiculo,
            Idtipomantenimiento = Idtipomantenimiento,
            Titulo = Titulo,
            FechaInicio = FechaInicio,
            FechaFin = FechaFin,
            Descripcion = Descripcion,
            Observaciones = Observaciones ?? "",
            Color = Color,
            Idusuario = Idusuario,
            CreatedAt = CreatedAt,
            UpdatedAt = UpdatedAt,
            Idstatus = Idstatus,
            Idlabel = Idlabel
        };
    }
}