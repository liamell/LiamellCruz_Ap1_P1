using LiamellCruz_Ap1_P1.DAL;
using LiamellCruz_Ap1_P1.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LiamellCruz_Ap1_P1.Service;

public class CobroService(Contexto contexto)
{
    private async Task<bool> Existe(int cobroId)
    {
        return await contexto.Cobro
            .AnyAsync(c => c.CobroId == cobroId);
    }

    private async Task<bool> Insertar(Cobros cobro)
    {
        contexto.Cobro.Add(cobro);
        return await contexto
            .SaveChangesAsync() > 0;
    }

    private async Task<bool> Modificar(Cobros cobro)
    {
        contexto.Update(cobro);
        return await contexto
            .SaveChangesAsync() > 0;
    }

    public async Task<bool> Guardar(Cobros cobro)
    {
        if (!await Existe(cobro.CobroId))
        {
            return await Insertar(cobro);
        }
        else
        {
            return await Modificar(cobro);
        }
    }

    public async Task<Cobros> Buscar(int cobroId)
    {
        return await contexto.Cobro.Include(d => d.Deudor)
            .Include(d => d.CobroDetalle)
            .FirstOrDefaultAsync(c => c.CobroId == cobroId);
    }

    public async Task<bool> Eliminar(int cobroId)
    {
        return await contexto.Cobro
            .Include(c => c.CobroDetalle)
            .Where(c => c.CobroId == cobroId)
            .ExecuteDeleteAsync() > 0;
    }

    public async Task<List<Cobros>> Listar(Expression<Func<Cobros, bool>> criterio)
    {
        return await contexto.Cobro.Include(d => d.Deudor)
            .Include(d => d.CobroDetalle)
            .AsNoTracking()
            .Where(criterio).ToListAsync();
    }

}
