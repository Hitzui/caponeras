using Caponeras.App.Dto;
using Caponeras.App.Helpers;
using Caponeras.Data.Models;
using Microsoft.EntityFrameworkCore;
using NLog;
using System.Data;

namespace Caponeras.App.Services;

public class MaestroCajaService
{
    private INavigationService _navigationService;
    private readonly ILogger _logger = LogManager.GetCurrentClassLogger();
    public string ErrorMessage { get; private set; } = string.Empty;

    public MaestroCajaService(INavigationService navigationService)
    {
        _navigationService = navigationService;
    }

    public async Task<MaestroCajaDto> GetMaestroCaja()
    {
        var today = DateTime.Today;
        var tomorrow = today.AddDays(1);

        await using var ctx = new DataContextCaponeras();

        var mcaja = await ctx.MaestroCajas
            .AsNoTracking()
            .FirstOrDefaultAsync(m =>
                m.Fecha >= today &&
                m.Fecha < tomorrow &&
                m.Estado == EstadoCaja.Abierta);

        return mcaja == null
            ? new MaestroCajaDto(
                IdMaestroCaja: 0,
                IdCaja: 0,
                SaldoInicial: 0,
                Entradas: 0,
                Salidas: 0,
                SaldoFinal: 0,
                Fecha: today,
                Estado: EstadoCaja.Cerrada
            )
            : new MaestroCajaDto(mcaja);
    }

    public async Task<List<DetaMovimientosDto>> GetMovimientosCaja(int idMaestroCaja)
    {
        await using var ctx = new DataContextCaponeras();
        return await ctx.DetaMovimientos
            .AsNoTracking()
            .Where(dm => dm.Idmaestrocaja == idMaestroCaja)
            .Select(dm => new DetaMovimientosDto(dm))
            .ToListAsync();
    }

    public MaestroCajaDto? CajaAperturada()
    {
        using var ctx = new DataContextCaponeras();
        return ctx.MaestroCajas.AsNoTracking()
            .Where(m => m.Estado == EstadoCaja.Abierta)
            .Select(m=> new MaestroCajaDto(m))
            .FirstOrDefault();
    }

    public async Task<bool> AperturarCaja()
    {
        await using var ctx = new DataContextCaponeras();
        await using var transaction = await ctx.Database.BeginTransactionAsync();
        try
        {
            var mcaja = await ctx.MaestroCajas
                .Where(mc => mc.Idcaja == _navigationService.CurrentUser.Idcaja)
                .OrderByDescending(mc => mc.Fecha).FirstOrDefaultAsync();
            var saldoInicial = 0m;
            var saldoFinal = 0m;
            if (mcaja is { Estado: EstadoCaja.Abierta })
            {
                mcaja.Estado = 0;
                mcaja.UpdatedAt = DateTime.Now;
                saldoInicial = mcaja.SaldoFinal;
                saldoFinal = mcaja.SaldoFinal;
            }
            else if (mcaja != null)
            {
                saldoInicial = mcaja.SaldoFinal;
                saldoFinal = mcaja.SaldoFinal;
            }

            var newMaestroCajas = new MaestroCajas
            {
                Idcaja = _navigationService.CurrentUser.Idcaja,
                Fecha = DateTime.Now,
                Estado = EstadoCaja.Abierta,
                SaldoInicial = saldoInicial,
                Entradas = 0,
                Salidas = 0,
                SaldoFinal = saldoFinal,
                TipoCambio = 1,
                Observaciones = "Apertura de caja en sistema",
                CreatedBy = _navigationService.CurrentUser.Idusuario,
                CreatedAt = DateTime.Now,
                UpdatedBy = _navigationService.CurrentUser.Idusuario,
                UpdatedAt = DateTime.Now
            };
            await ctx.AddAsync(newMaestroCajas);
            await ctx.SaveChangesAsync();
            await transaction.CommitAsync();
            return true;
        }
        catch (Exception e)
        {
            await transaction.RollbackAsync();
            _logger.Error(e);
            return false;
        }
    }

    public async Task<bool> CerrarCaja()
    {
        await using var ctx = new DataContextCaponeras();
        await using var transaction = await ctx.Database.BeginTransactionAsync();

        try
        {
            var now = DateTime.UtcNow;
            var idCaja = _navigationService.CurrentUser.Idcaja;
            var idUsuario = _navigationService.CurrentUser.Idusuario;

            // 🔍 Obtener la última caja de esa caja física
            var mcaja = await ctx.MaestroCajas
                .Where(mc => mc.Idcaja == idCaja)
                .OrderByDescending(mc => mc.Fecha)
                .ThenByDescending(mc => mc.Idmaestrocaja)
                .FirstOrDefaultAsync();

            // ❌ No hay registros
            if (mcaja == null)
                return false;

            // ⚠️ Ya está cerrada
            if (mcaja.Estado == 0)
                return false;

            // ✅ Cerrar caja
            mcaja.Estado = 0;

            // (opcional pero recomendable)
            mcaja.UpdatedAt = now;
            mcaja.UpdatedBy = idUsuario;

            await ctx.SaveChangesAsync();
            await transaction.CommitAsync();

            return true;
        }
        catch (Exception e)
        {
            await transaction.RollbackAsync();
            _logger.Error(e);
            return false;
        }
    }

    public async Task<bool> RealizarMovimiento(DetaMovimientosDto detaMovimientos)
    {
        await using var ctx = new DataContextCaponeras();
        await using var transaction = await ctx.Database.BeginTransactionAsync(IsolationLevel.Serializable);
        try
        {
            var monto = detaMovimientos.Efectivo;
            var today = DateTime.Today;
            var tomorrow = today.AddDays(1);

            var mcaja = await ctx.MaestroCajas
                .Where(mc =>
                    mc.Idcaja == _navigationService.CurrentUser.Idcaja &&
                    mc.Estado == EstadoCaja.Abierta &&
                    mc.Fecha >= today &&
                    mc.Fecha < tomorrow)
                .FirstOrDefaultAsync();
            if (mcaja is null)
            {
                ErrorMessage = "No hay una caja aperturada para realizar este movimiento";
                return false;
            }

            var naturaleza = await ctx.MovCajas
                .Where(m => m.Idmovcaja == detaMovimientos.Idmovimiento)
                .Select(m => m.Rubros.Naturaleza)
                .SingleOrDefaultAsync();

            switch (naturaleza)
            {
                case RubroNaturaleza.Egreso when mcaja.SaldoFinal < monto:
                    ErrorMessage = "No hay suficiente saldo en caja para realizar esta salida";
                    throw new Exception(ErrorMessage);
                case RubroNaturaleza.Egreso:
                    mcaja.Salidas += monto;
                    mcaja.SaldoFinal -= monto;
                    break;
                case RubroNaturaleza.Ingreso:
                    mcaja.Entradas += monto;
                    mcaja.SaldoFinal += monto;
                    break;
                default:
                    ErrorMessage = $"Naturaleza de movimiento inválida: {naturaleza}";
                    throw new Exception(ErrorMessage);
            }

            var ahora = DateTime.Now;
            var deta = new DetaMovimientos
            {
                Idmaestrocaja = mcaja.Idmaestrocaja,
                Fecha = ahora,
                Concepto = detaMovimientos.Concepto,
                Idmovimiento = detaMovimientos.Idmovimiento,
                ReferenciaTipo = detaMovimientos.ReferenciaTipo,
                ReferenciaId = detaMovimientos.ReferenciaId,
                Efectivo = detaMovimientos.Efectivo,
                Transferencia = 0m,
                Tipocambio = 1m,
                CreatedBy = _navigationService.CurrentUser.Idusuario,
                CreatedAt = ahora,
                UpdatedBy = _navigationService.CurrentUser.Idusuario,
                UpdatedAt = ahora
            };
            await ctx.AddAsync(deta);
            await ctx.SaveChangesAsync();
            await transaction.CommitAsync();
            return true;
        }
        catch (Exception e)
        {
            await transaction.RollbackAsync();
            ErrorMessage = $"Ocurrió un error: {e.Message}";
            _logger.Error(e);
            return false;
        }
    }

    public async Task<DetaMovimientos?> RealizarMovimientoAndGetDetaMovimiento(
        DetaMovimientosDto detaMovimientos,
        DataContextCaponeras ctx,
        bool autoSave = true)
    {
        try
        {
            var monto = detaMovimientos.Efectivo;
            var today = DateTime.Today;
            var tomorrow = today.AddDays(1);

            var mcaja = await ctx.MaestroCajas
                .Where(mc =>
                    mc.Idcaja == _navigationService.CurrentUser.Idcaja &&
                    mc.Estado == EstadoCaja.Abierta &&
                    mc.Fecha >= today &&
                    mc.Fecha < tomorrow)
                .FirstOrDefaultAsync();
            if (mcaja is null)
            {
                ErrorMessage = "No hay una caja aperturada para realizar este movimiento";
                return null;
            }

            var naturaleza = await ctx.MovCajas
                .Where(m => m.Idmovcaja == detaMovimientos.Idmovimiento)
                .Select(m => m.Rubros.Naturaleza)
                .SingleOrDefaultAsync();

            switch (naturaleza)
            {
                case RubroNaturaleza.Egreso when mcaja.SaldoFinal < monto:
                    ErrorMessage = "No hay suficiente saldo en caja para realizar esta salida";
                    throw new Exception(ErrorMessage);
                case RubroNaturaleza.Egreso:
                    mcaja.Salidas += monto;
                    mcaja.SaldoFinal -= monto;
                    break;
                case RubroNaturaleza.Ingreso:
                    mcaja.Entradas += monto;
                    mcaja.SaldoFinal += monto;
                    break;
                default:
                    ErrorMessage = $"Naturaleza de movimiento inválida: {naturaleza}";
                    throw new Exception(ErrorMessage);
            }

            var ahora = DateTime.Now;
            var deta = new DetaMovimientos
            {
                Idmaestrocaja = mcaja.Idmaestrocaja,
                Fecha = ahora,
                Concepto = detaMovimientos.Concepto,
                Idmovimiento = detaMovimientos.Idmovimiento,
                ReferenciaTipo = detaMovimientos.ReferenciaTipo,
                ReferenciaId = detaMovimientos.ReferenciaId,
                Efectivo = detaMovimientos.Efectivo,
                Transferencia = 0m,
                Tipocambio = 1m,
                CreatedBy = _navigationService.CurrentUser.Idusuario,
                CreatedAt = ahora,
                UpdatedBy = _navigationService.CurrentUser.Idusuario,
                UpdatedAt = ahora
            };
            ctx.Update(mcaja);
            await ctx.AddAsync(deta);
            if (autoSave) await ctx.SaveChangesAsync();
            return deta;
        }
        catch (Exception e)
        {
            ErrorMessage = $"Ocurrió un error al realizar el movimiento.{e.Message}";
            _logger.Error(e);
            return null;
        }
    }

    public async Task<IList<MovCajasDto>> GetAllMovimientosCaja()
    {
        await using var ctx = new DataContextCaponeras();
        var param = await ctx.Parametros.AsNoTracking().FirstOrDefaultAsync();
        if (param is null)
        {
            return [];
        }

        var idNotIn = new List<int>
        {
            param.Compra,
            param.AjusteManoObra,
            param.AnulacionCompra,
            param.AnulacionManoObra,
            param.AperturaCaja,
            param.CierreCaja
        };
        return await ctx.MovCajas
            .AsNoTracking()
            .Include(m => m.Rubros)
            .Where(m => !idNotIn.Contains(m.Idmovcaja))
            .Select(m => new MovCajasDto(m)).ToListAsync();
    }
}