using System.Diagnostics;
using Caponeras.App.Dto;
using Caponeras.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Caponeras.App.Services;

public class MovCajaService
{
    public async Task<List<MovCajasDto>> GetData()
    {
        await using var context = new DataContextCaponeras();
        return context.MovCajas.AsNoTracking().Include(x=>x.Rubros).Select(x => new MovCajasDto().FromModel(x)).ToList();
    }

    public async Task<List<RubrosDto>> GetRubros()
    {
        await using var context = new DataContextCaponeras();
        return context.Rubros.AsNoTracking().Select(x => new RubrosDto().FromModel(x)).ToList();
    }

    public async Task<int> SaveMovCaja(MovCajas movCaja)
    {
        try
        {
            await using var ctx = new DataContextCaponeras();
            if (movCaja.Idmovcaja <= 0)
            {
                var rubro = await ctx.Rubros.FindAsync(movCaja.Idrubro);
                if (rubro is null)
                {
                    throw new Exception("No existe el rubro");
                }

                movCaja.Rubros = rubro;
                await ctx.AddAsync(movCaja);
            }
            else
            {
                var find = await ctx.MovCajas.FindAsync(movCaja.Idmovcaja);
                if (find is null)
                {
                    return -1;
                }

                find.Descripcion = movCaja.Descripcion;
                find.Idrubro = movCaja.Idrubro;
            }

            return await ctx.SaveChangesAsync();
        }
        catch (Exception e)
        {
            Debug.WriteLine(e);
            return -1;
        }
    }

    public async Task<bool> DeleteMovCaja(int idmovcaja)
    {
        await using var ctx = new DataContextCaponeras();
        var find = await ctx.MovCajas.FindAsync(idmovcaja);
        if (find is null)
        {
            return false;
        }
        ctx.MovCajas.Remove(find);
        var save = await ctx.SaveChangesAsync();
        return save > 0;
    }
}