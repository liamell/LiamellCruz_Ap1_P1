using LiamellCruz_Ap1_P1.Models;
using Microsoft.EntityFrameworkCore;

namespace LiamellCruz_Ap1_P1.DAL;

public class Contexto : DbContext
{
    public Contexto(DbContextOptions<Contexto> options) : base(options) { }

    public DbSet<Prestamos> Prestamo { get; set; }

}
