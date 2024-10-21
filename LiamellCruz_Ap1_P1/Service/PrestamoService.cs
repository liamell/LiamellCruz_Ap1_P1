using LiamellCruz_Ap1_P1.DAL;
using LiamellCruz_Ap1_P1.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;

namespace LiamellCruz_Ap1_P1.Service;

public class PrestamoService(Contexto contexto)
{
    public async Task<bool> Guardar(Prestamos prestamo)
    {
        if (!await Existe(prestamo.PrestamoId))
            return await Insertar(prestamo);
        else
            return await Modificar(prestamo);
    }

    private async Task<bool> Existe(int prestamoId)
    {
        return await contexto.Prestamo
            .AnyAsync(p => p.PrestamoId == prestamoId);
    }

    public async Task<bool> Insertar(Prestamos prestamo)
    {
        contexto.Prestamo.Add(prestamo);
        return await contexto.SaveChangesAsync() > 0;
    }

    private async Task<bool> Modificar(Prestamos prestamo)
    {
        contexto.Update(prestamo);
        var modificado = await contexto.SaveChangesAsync() > 0;
        contexto.Entry(prestamo).State= EntityState.Modified;
        return modificado;

    }

    public async Task<bool> Eliminar(int prestamoId)
    {
        return await contexto.Prestamo
            .AsNoTracking()
            .Where(p => p.PrestamoId == prestamoId)
            .ExecuteDeleteAsync() > 0;
    }

    public async Task<Prestamos?> Buscar(int prestamoId)
    {
        return await contexto.Prestamo
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.PrestamoId == prestamoId);
    }

    public async Task<Prestamos?> BuscarPrestamo(int id)
    {
        return await contexto.Prestamo.Include(p => p.Deudor).FirstOrDefaultAsync(p => p.DeudorId == id);
    }


    public async Task<List<Prestamos>> Listar(Expression<Func<Prestamos, bool>> filtro)
    {
        return await contexto.Prestamo
            .Include(p => p.Deudor)
            .Where(filtro)
            .ToListAsync();
    }
  


}
