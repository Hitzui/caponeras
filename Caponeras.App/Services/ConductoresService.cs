using Caponeras.App.Dto;
using Caponeras.App.Helpers;
using Caponeras.Data.Models;
using Microsoft.EntityFrameworkCore;
using NLog;
using System.Diagnostics;

namespace Caponeras.App.Services;

public class ConductoresService
{
    private ILogger _logger = LogManager.GetCurrentClassLogger();
    private MaestroCajaService _maestroService;
    private readonly DataContextCaponeras _context;
    public string ErrorMessage { get; private set; }

    public ConductoresService(DataContextCaponeras context, MaestroCajaService maestroService)
    {
        ErrorMessage = string.Empty;
        _context = context;
        _maestroService = maestroService;
    }


    public Task<List<ConductoresDto>> GetAllTask()
    {
        return _context.Conductors.AsNoTracking()
            .Include(c => c.CuotaConfiguracions)
            .Select(c => new ConductoresDto(c, c.CuotaConfiguracions))
            .ToListAsync();
    }

    public async Task<int> Add(ConductoresDto cadete)
    {
        await ValidateCadeteAsync(cadete);
        await _context.AddAsync(cadete.Conductors());
        return await _context.SaveChangesAsync();
    }

    public Task<bool> ExisteIdentificacion(string query, int excluirId = 0)
    {
        query = query.Trim();
        return _context.Conductors.AnyAsync(c =>
            c.Idconductor != excluirId && c.Identificacion == query);
    }

    public async Task<int> Edit(ConductoresDto conductorDto)
    {
        await ValidateCadeteAsync(conductorDto);
        var find = await _context.Conductors.FindAsync(conductorDto.Idconductor);
        if (find == null)
        {
            throw new Exception("Conductor no encontrado");
        }

        find.Identificacion = conductorDto.Identificacion.Trim();
        find.Nombre = conductorDto.Nombre.Trim();
        find.Telefono = conductorDto.Telefono?.Trim();
        find.Observaciones = conductorDto.Observaciones;
        find.Direccion = conductorDto.Direccion;
        find.Estado = conductorDto.Estado;
        _context.Update(find);
        return await _context.SaveChangesAsync();
    }

    public async Task<int> Delete(ConductoresDto conductorDto)
    {
        if (conductorDto is null || conductorDto.Idconductor <= 0)
            throw new ArgumentException("Seleccione un cadete válido para inactivar.", nameof(conductorDto));

        var find = await _context.Conductors.FindAsync(conductorDto.Idconductor);
        if (find == null)
        {
            throw new Exception("Conductor no encontrado");
        }

        if (find.Estado == EstadoCadete.INACTIVO)
            return 1;

        find.Estado = EstadoCadete.INACTIVO;

        return await _context.SaveChangesAsync();
    }

    private async Task ValidateCadeteAsync(ConductoresDto cadete)
    {
        if (cadete is null)
            throw new ArgumentNullException(nameof(cadete));

        cadete.Nombre = cadete.Nombre?.Trim() ?? string.Empty;
        cadete.Identificacion = cadete.Identificacion?.Trim() ?? string.Empty;
        cadete.Telefono = cadete.Telefono?.Trim() ?? string.Empty;
        cadete.Direccion = cadete.Direccion?.Trim() ?? string.Empty;

        if (string.IsNullOrWhiteSpace(cadete.Nombre) || string.IsNullOrWhiteSpace(cadete.Identificacion))
            throw new ArgumentException("El nombre y la identificación son obligatorios.");
        if (cadete.Nombre.Length > 100 || cadete.Identificacion.Length > 50 || cadete.Telefono.Length > 30)
            throw new ArgumentException("El nombre admite hasta 100 caracteres, la identificación 50 y el celular 30.");
        if (!Enum.IsDefined(cadete.Estado))
            throw new ArgumentException("El estado del cadete no es válido.");

        if (await ExisteIdentificacion(cadete.Identificacion, cadete.Idconductor))
            throw new ArgumentException("Ya existe otro cadete con esa identificación.");
    }

    public async Task<bool> ConfigurarCuota(CuotaConfiguracions cuotaConfiguracion)
    {
        try
        {
            ErrorMessage = string.Empty;
            if (cuotaConfiguracion.Idconductor <= 0 || cuotaConfiguracion.MontoDiario <= 0)
                throw new Exception("Debe seleccionar un cadete activo e indicar una cuota mayor a cero.");

            var cadeteActivo = await _context.Conductors
                .AnyAsync(c => c.Idconductor == cuotaConfiguracion.Idconductor &&
                               c.Estado == EstadoCadete.ACTIVO);
            if (!cadeteActivo)
                throw new Exception("No se puede configurar la cuota: el cadete está inactivo o ya no existe.");

            var findCuotas = await _context.CuotaConfiguracions
                .Where(c => c.Idconductor == cuotaConfiguracion.Idconductor)
                .FirstOrDefaultAsync();
            if (findCuotas is not null)
            {
                findCuotas.MontoDiario = cuotaConfiguracion.MontoDiario;
                findCuotas.Observaciones = cuotaConfiguracion.Observaciones;
                findCuotas.Activo = true;
            }
            else
            {
                await _context.CuotaConfiguracions.AddAsync(cuotaConfiguracion);
            }


            var save = await _context.SaveChangesAsync();
            return save > 0;
        }
        catch (Exception e)
        {
            ErrorMessage = e.Message;
            return false;
        }
    }

    public Task<ConductoresDto?> FindById(int id)
    {
        return _context.Conductors
            .AsNoTracking()
            .Include(c => c.CuotaConfiguracions)
            .Include(c => c.VehiculoConductors)
            .Where(c => c.Idconductor == id && c.Estado == EstadoCadete.ACTIVO)
            .Select(x => new ConductoresDto(
                x,
                x.CuotaConfiguracions,
                new VehiculosDto(x.VehiculoConductors.Where(c => c.Idconductor == x.Idconductor)
                    .Select(c => c.Vehiculos).First())
            ))
            .FirstOrDefaultAsync();
    }

    public async Task<ConductorVehiculoDto?> GetVehiculoAsignadoByDate(int idconductor, DateTime fecha)
    {
        fecha = fecha.Date;
        var asignaciones = _context.VehiculoConductors.AsNoTracking()
            .Include(vc => vc.Vehiculos)
            .Include(vc => vc.Zonas)
            .Where(vc => vc.Idconductor == idconductor && vc.Activo == 1 && vc.DeletedAt == null);

        // Una asignación que cubre únicamente este día reemplaza la asignación general por rango.
        var asignacionesDelDia = await asignaciones
            .Where(vc => vc.FechaInicio == fecha && vc.FechaFin == fecha)
            .OrderByDescending(vc => vc.Id)
            .ToListAsync();

        if (asignacionesDelDia.Count > 1)
            throw new InvalidOperationException("El cadete tiene varias asignaciones específicas para esta fecha. Revise el calendario.");

        var seleccionada = asignacionesDelDia.SingleOrDefault();
        if (seleccionada is null)
        {
            var asignacionesPorRango = await asignaciones
                .Where(vc => vc.FechaInicio <= fecha && (vc.FechaFin == null || vc.FechaFin >= fecha))
                .OrderByDescending(vc => vc.FechaInicio)
                .ThenByDescending(vc => vc.Id)
                .ToListAsync();

            if (asignacionesPorRango.Count > 1)
                throw new InvalidOperationException("El cadete tiene más de un vehículo asignado para esta fecha. Revise el calendario.");

            seleccionada = asignacionesPorRango.SingleOrDefault();
        }

        if (seleccionada is null)
            return null;

        return new ConductorVehiculoDto
        {
            IdConductor = seleccionada.Idconductor,
            IdVehiculo = seleccionada.Idvehiculo,
            CodigoVehiculo = seleccionada.Vehiculos.Codigo,
            Placa = seleccionada.Vehiculos.Placa,
            IdZona = seleccionada.Idzona,
            Zona = seleccionada.Zonas?.Nombre,
            FechaInicio = seleccionada.FechaInicio,
            FechaFin = seleccionada.FechaFin
        };
    }

    public Task<CuotaDiariasDto?> GetCuotaDiariaByConductor(int idconductor, DateTime fecha)
    {
        var fechaInicio = fecha.Date;
        var fechaFin = fechaInicio.AddDays(1);

        return _context.CuotaDiarias
            .AsNoTracking()
            .Where(cd => cd.Idconductor == idconductor && cd.Fecha >= fechaInicio && cd.Fecha < fechaFin)
            .Select(cd => new CuotaDiariasDto(cd))
            .FirstOrDefaultAsync();
    }

    public async Task<bool> RegistrarPagoCuotaDiaria(
        int idconductor, 
        decimal monto, 
        string observaciones,
        DateTime fecha,
        Usuarios currentUser
        )
    {
        ErrorMessage = string.Empty;
        if (monto <= 0)
        {
            ErrorMessage = "El monto del pago debe ser mayor a cero.";
            return false;
        }

        fecha = fecha.Date;
        await using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            var parametros = await _context.Parametros.AsNoTracking().FirstOrDefaultAsync();
            if (parametros is null)
            {
                throw new Exception("No se han configurado los parámetros del sistema.");
            }

            var cadeteActivo = await _context.Conductors
                .AnyAsync(c => c.Idconductor == idconductor && c.Estado == EstadoCadete.ACTIVO);
            if (!cadeteActivo)
                throw new Exception("No se puede registrar la cuota: el cadete está inactivo o ya no existe.");

            var asignacionesActivas = _context.VehiculoConductors
                .AsNoTracking()
                .Where(vc => vc.Idconductor == idconductor &&
                             vc.Activo == 1 &&
                             vc.DeletedAt == null);

            // Priorizar la cobertura exacta del día sobre el tramo de asignación regular.
            var asignacionesDelDia = await asignacionesActivas
                .Where(vc => vc.FechaInicio == fecha && vc.FechaFin == fecha)
                .OrderByDescending(vc => vc.Id)
                .ToListAsync();

            if (asignacionesDelDia.Count > 1)
                throw new Exception("El conductor tiene varias asignaciones específicas para esa fecha. Revise sus asignaciones.");

            var asignacionesVigentes = asignacionesDelDia;
            if (asignacionesVigentes.Count == 0)
            {
                asignacionesVigentes = await asignacionesActivas
                    .Where(vc => vc.FechaInicio <= fecha && (vc.FechaFin == null || vc.FechaFin >= fecha))
                    .OrderByDescending(vc => vc.FechaInicio)
                    .ThenByDescending(vc => vc.Id)
                    .ToListAsync();
            }

            if (asignacionesVigentes.Count == 0)
            {
                throw new Exception("El conductor no tiene un vehículo asignado para la fecha seleccionada.");
            }
            if (asignacionesVigentes.Count > 1)
            {
                throw new Exception("El conductor tiene más de un vehículo asignado para la fecha seleccionada. Revise sus asignaciones.");
            }
            var vehiculoAsignado = asignacionesVigentes[0];

            var cuotaDiaria = await _context.CuotaDiarias
                .FirstOrDefaultAsync(cd => cd.Idconductor == idconductor &&
                                           cd.Fecha >= fecha && cd.Fecha < fecha.AddDays(1));

            if (cuotaDiaria == null)
            {
                var cuotaConfiguracion = await _context.CuotaConfiguracions
                    .FirstOrDefaultAsync(cc => cc.Idconductor == idconductor && cc.Activo);
                if (cuotaConfiguracion is null)
                    throw new Exception("No se ha configurado ni registrado una cuota diaria para este conductor.");

                await AgregarCuota(
                    monto, 
                    observaciones, 
                    currentUser, 
                    parametros,
                    cuotaConfiguracion, 
                    fecha,
                    vehiculoAsignado);
            }
            else
            {
                await ActualizarCuota(monto, observaciones, parametros, cuotaDiaria, fecha, vehiculoAsignado);
            }

            await _context.SaveChangesAsync();
            await transaction.CommitAsync();
            return true;
        }
        catch (Exception e)
        {
            ErrorMessage = e.Message;
            await transaction.RollbackAsync();
            return false;
        }
    }

    private async Task ActualizarCuota(decimal monto,
        string observaciones,
        Parametros parametros,
        CuotaDiarias cuotaDiaria, DateTime fecha, VehiculoConductors vehiculoAsignado)
    {
        var cadete = await _context.Conductors.FindAsync(cuotaDiaria.Idconductor);
        if (cadete is null)
        {
            throw new Exception("El cadete no fue encontrado.");
        }

        var nuevoMonto = cuotaDiaria.MontoEntregado + monto;

        if (nuevoMonto > cuotaDiaria.MontoCuota)
        {
            throw new Exception(
                "El monto entregado supera la cuota pendiente.");
        }

        cuotaDiaria.MontoEntregado = nuevoMonto;
        cuotaDiaria.IdVehiculo = vehiculoAsignado.Idvehiculo;

        cuotaDiaria.Diferencia = cuotaDiaria.MontoCuota - cuotaDiaria.MontoEntregado;

        cuotaDiaria.Porcentaje = (cuotaDiaria.MontoEntregado /
                                  cuotaDiaria.MontoCuota) * 100;

        cuotaDiaria.Observaciones = observaciones;
        var concepto = nuevoMonto == cuotaDiaria.MontoCuota ? "Cancelación" : "Abono";
        var detalle = new DetaMovimientosDto
        {
            Fecha = fecha,
            Concepto = $"{concepto} cuota de cadete {cadete.Nombre}",
            Idmovimiento = parametros.PagoCuotaCadete,
            ReferenciaTipo = ReferenciaMovimiento.CuotaCadete,
            ReferenciaId = cuotaDiaria.IdCuotaDiaria,
            Efectivo = monto,
            Transferencia = 0,
            Tipocambio = 1
        };

        var detalleIngresado =
            await _maestroService.RealizarMovimientoAndGetDetaMovimiento(
                detalle,
                _context,
                false);

        if (detalleIngresado is null)
        {
            throw new Exception(_maestroService.ErrorMessage);
        }
    }

    private async Task AgregarCuota(decimal monto, string observaciones,
        Usuarios currentUser, Parametros parametros, CuotaConfiguracions cuotaConfiguracion,
        DateTime fecha,
        VehiculoConductors vehiculoAsignado)
    {
        var cadete = await _context.Conductors.FindAsync(vehiculoAsignado.Idconductor);
        if (cadete is null)
        {
            throw new Exception("El cadete no fue encontrado.");
        }

        if (cuotaConfiguracion.MontoDiario <= 0)
        {
            throw new Exception("La cuota diaria configurada no es válida.");
        }

        CuotaDiarias cuotaDiaria;
        var diferencia = cuotaConfiguracion.MontoDiario - monto;
        var porcentaje = (monto / cuotaConfiguracion.MontoDiario) * 100;
        if (diferencia < 0)
        {
            throw new Exception("El monto entregado no puede ser mayor a la cuota diaria configurada.");
        }

        cuotaDiaria = new CuotaDiarias
        {
            Idconductor = vehiculoAsignado.Idconductor,
            Fecha = fecha,
            IdVehiculo = vehiculoAsignado.Idvehiculo,
            MontoCuota = cuotaConfiguracion.MontoDiario,
            MontoEntregado = monto,
            Diferencia = diferencia,
            Porcentaje = porcentaje,
            Observaciones = observaciones,
            CreatedBy = currentUser.Idusuario,
            CreatedAt = DateTime.Now,
        };
        await _context.CuotaDiarias.AddAsync(cuotaDiaria);
        await _context.SaveChangesAsync();
        var detalle = new DetaMovimientosDto
        {
            Fecha = DateTime.Now,
            Concepto = $"Pago de cuota de cadete {cadete.Nombre}",
            Idmovimiento = parametros.PagoCuotaCadete,
            ReferenciaTipo = ReferenciaMovimiento.CuotaCadete,
            ReferenciaId = cuotaDiaria.IdCuotaDiaria,
            Efectivo = monto,
            Transferencia = 0,
            Tipocambio = 1
        };
        var detalleIngresado =
            await _maestroService.RealizarMovimientoAndGetDetaMovimiento(detalle, _context, false);
        if (detalleIngresado is null)
        {
            throw new Exception(_maestroService.ErrorMessage);
        }
    }

    public ConductorLicenciasDto? FindLicencia(int idconductor)
    {
        var lic = _context.ConductorLicencias
            .Include(lic => lic.Conductors)
            .FirstOrDefault(c =>
                c.Idconductor == idconductor && c.Activa);
        return new ConductorLicenciasDto(lic);
    }

    public async Task<bool> SaveLicencia(ConductorLicenciasDto licencia)
    {
        try
        {
            if (licencia.Idlicencia > 0)
            {
                var find = await _context.ConductorLicencias.FindAsync(licencia.Idlicencia);
                if (find is not null)
                {
                    // Update the existing license
                    find.FotoLicenciaFrente = licencia.FotoLicenciaFrente;
                    find.FotoLicenciaReverso = licencia.FotoLicenciaReverso;
                    find.FechaEmision = licencia.FechaEmision;
                    find.FechaVencimiento = licencia.FechaVencimiento;
                    find.NumeroLicencia = licencia.NumeroLicencia;
                    find.Categoria = licencia.Categoria;
                    find.Observaciones = licencia.Observaciones;
                    find.UpdatedAt = DateTime.Now;
                }
            }
            else
            {
                var newLicencia = new ConductorLicencias
                {
                    Idconductor = licencia.Idconductor,
                    NumeroLicencia = licencia.NumeroLicencia,
                    Categoria = licencia.Categoria,
                    FechaEmision = licencia.FechaEmision,
                    FechaVencimiento = licencia.FechaVencimiento,
                    Activa = true,
                    FotoLicenciaFrente = licencia.FotoLicenciaFrente,
                    FotoLicenciaReverso = licencia.FotoLicenciaReverso,
                    Observaciones = licencia.Observaciones,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };
                await _context.ConductorLicencias.AddAsync(newLicencia);
            }

            var save = await _context.SaveChangesAsync();
            return save > 0;
        }
        catch (Exception e)
        {
            ErrorMessage = e.Message;
            Debug.WriteLine(e);
            _logger.Error(e, "Error saving license for conductor ID {ConductorId}", licencia.Idconductor);
            return false;
        }
    }

    public async Task<bool> SaveIdentificacion(ConductorIdentificacionsDto identificacionsDto)
    {
        try
        {
            if (identificacionsDto.Ididentificacion > 0)
            {
                var findIdentificacion =
                    await _context.ConductorIdentificacions.FindAsync(identificacionsDto.Ididentificacion);
                if (findIdentificacion is not null)
                {
                    findIdentificacion.NumeroIdentificacion = identificacionsDto.NumeroIdentificacion;
                    findIdentificacion.DireccionDomiciliar = identificacionsDto.DireccionDomiciliar;
                    findIdentificacion.FechaEmision = identificacionsDto.FechaEmision;
                    findIdentificacion.FechaVencimiento = identificacionsDto.FechaVencimiento;
                    findIdentificacion.MunicipioResidencia = identificacionsDto.MunicipioResidencia;
                    if (!string.IsNullOrEmpty(identificacionsDto.FotoFrente))
                    {
                        findIdentificacion.FotoFrente = identificacionsDto.FotoFrente;
                    }

                    if (!string.IsNullOrEmpty(identificacionsDto.FotoReverso))
                    {
                        findIdentificacion.FotoReverso = identificacionsDto.FotoReverso;
                    }

                    findIdentificacion.Observaciones = identificacionsDto.Observaciones;
                    findIdentificacion.UpdatedAt = DateTime.Now;
                }
            }
            else
            {
                var identificacion = new ConductorIdentificacions
                {
                    Idconductor = identificacionsDto.Idconductor,
                    NumeroIdentificacion = identificacionsDto.NumeroIdentificacion,
                    FechaEmision = identificacionsDto.FechaEmision,
                    FechaVencimiento = identificacionsDto.FechaVencimiento,
                    Activa = true,
                    FotoFrente = identificacionsDto.FotoFrente,
                    FotoReverso = identificacionsDto.FotoReverso,
                    Observaciones = identificacionsDto.Observaciones,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    DireccionDomiciliar = identificacionsDto.DireccionDomiciliar,
                    MunicipioResidencia = identificacionsDto.MunicipioResidencia,
                };
                await _context.AddAsync(identificacion);
            }

            var save = await _context.SaveChangesAsync();
            return save > 0;
        }
        catch (Exception e)
        {
            _logger.Error(e);
            ErrorMessage = e.Message;
            return false;
        }
    }

    public Task<ConductorIdentificacionsDto?> FindIdentificacion(int idconductor)
    {
        return _context.ConductorIdentificacions
            .Where(identificacions => identificacions.Idconductor == idconductor && identificacions.Activa)
            .Select(c => new ConductorIdentificacionsDto(c))
            .FirstOrDefaultAsync();
    }

    public async Task<InformacionCadeteDto?> GetInformacionCadete(int idconductor)
    {
        var conductor = await _context.Conductors
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Idconductor == idconductor);

        if (conductor == null)
            return null;

        var licencia = await _context.ConductorLicencias
            .AsNoTracking()
            .Where(x => x.Idconductor == idconductor && x.Activa)
            .FirstOrDefaultAsync();

        var identificacion = await _context.ConductorIdentificacions
            .AsNoTracking()
            .Where(x => x.Idconductor == idconductor && x.Activa)
            .FirstOrDefaultAsync();

        return new InformacionCadeteDto(
            new ConductoresDto(conductor),
            licencia != null ? new ConductorLicenciasDto(licencia) : null,
            identificacion != null ? new ConductorIdentificacionsDto(identificacion) : null
        );
    }

    public Task<List<CuotaDetalleDto>> GetDetalleCuotas(DateTime? fecha = null)
    {
        var query = _context.CuotaDiarias
            .Include(c => c.Conductors)
            .Include(c => c.Vehiculos)
            .AsNoTracking();
        if (fecha is not null)
        {
            var fechaInicio = fecha.Value.Date;
            var fechaFin = fechaInicio.AddDays(1);
            query = query.Where(c => c.Fecha >= fechaInicio && c.Fecha < fechaFin);
        }

        return query.Select(c => new CuotaDetalleDto(
            c.Fecha,
            c.Vehiculos.Codigo,
            c.Vehiculos.Placa,
            c.MontoCuota,
            c.MontoEntregado,
            c.Diferencia,
            c.Porcentaje,
            c.Conductors.Nombre
        )).ToListAsync();
    }
}
