using LiamellCruz_Ap1_P1.DAL;
using LiamellCruz_Ap1_P1.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LiamellCruz_Ap1_P1.Service;


public class DetallesCobroService(Contexto contexto)
{
    public async Task<List<Prestamos>> Listar(Expression<Func<Prestamos, bool>> criterio)
    {
        return await contexto.Prestamo
            .AsNoTracking()
            .Where(criterio)
            .ToListAsync();
    }
}
