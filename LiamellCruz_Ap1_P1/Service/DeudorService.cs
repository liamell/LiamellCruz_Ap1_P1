using LiamellCruz_Ap1_P1.DAL;
using LiamellCruz_Ap1_P1.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LiamellCruz_Ap1_P1.Service;

public class DeudorService(Contexto contexto)
{
    public async Task<List<Deudor>> Listar(Expression<Func<Deudor, bool>> criterio)
    {
        return await contexto.Deudor
            .AsNoTracking()
            .Where(criterio)
            .ToListAsync();
    }


}
