using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class Context : DbContext
{
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Avion> Aviones { get; set; }
    public DbSet<Fabricante> Fabricantes { get; set; }

    public Context(DbContextOptions options) :base(options)
	{
	}
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        #region Usuarios
        modelBuilder.Entity<Usuario>()
            .HasKey(k => k.NombreUsuario);        
        modelBuilder.Entity<Usuario>()
            .Property(p => p.Password)
            .IsRequired();    
        modelBuilder.Entity<Usuario>()
            .Property(a => a.Activo)
            .IsRequired();
        modelBuilder.Entity<Usuario>()
            .Property(fa => fa.FechaAlta)
            .IsRequired();  
        #endregion

        #region Fabricantes
        modelBuilder.Entity<Fabricante>()
            .HasKey(k => k.Id);
        modelBuilder.Entity<Fabricante>()
            .Property(n => n.Nombre)
            .IsRequired();
        modelBuilder.Entity<Fabricante>()
            .HasMany(a => a.Aviones)
            .WithOne(f => f.Fabricante)
            .HasForeignKey(fk => fk.IdFabricante)
            .IsRequired();
        #endregion

        #region Aviones
        modelBuilder.Entity<Avion>()
            .HasKey(k => k.Id);
        modelBuilder.Entity<Avion>()
            .Property(ma => ma.Matricula)
            .IsRequired();
        modelBuilder.Entity<Avion>()
            .Property(mo => mo.Modelo)
            .IsRequired();
        modelBuilder.Entity<Avion>()
            .Property(cp => cp.CantidadPasajeros)
            .IsRequired();
        modelBuilder.Entity<Avion>()
            .Property(au => au.AutonomiaKm)
            .IsRequired();
        modelBuilder.Entity<Avion>()
            .Property(fa => fa.FechaAlta)
            .IsRequired();
        #endregion
    }
        

}
