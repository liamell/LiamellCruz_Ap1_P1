using LiamellCruz_Ap1_P1.Models;
using Microsoft.EntityFrameworkCore;

namespace LiamellCruz_Ap1_P1.DAL;

public class Contexto : DbContext
{
    public Contexto(DbContextOptions<Contexto> options) : base(options) { }

    public DbSet<Prestamos> Prestamo { get; set; }
    public DbSet<Deudor> Deudor { get; set; }
    public DbSet<Cobros> Cobro { get; set; }

    public DbSet<CobrosDetalle> CobroDetalle { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Deudor>().HasData(new List<Deudor>()
        {
            new Deudor(){DeudorId=1, Nombres="liamell Cruz"},
            new Deudor(){DeudorId=2, Nombres="Marcos Rosario"},
            new Deudor(){DeudorId=3, Nombres="Josmeyli Duarte"}
        });
    }








}
