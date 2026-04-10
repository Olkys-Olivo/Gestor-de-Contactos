using Microsoft.EntityFrameworkCore;
using GestordeContactos.Models;

namespace GestordeContactos.Data;

public class AppDbContext : DbContext
{
    public DbSet<Contacto> Contactos { get; set; } = null!;
    public DbSet<Categoria> Categorias { get; set; } = null!;

    // Allow external configuration (for DI / tests). Keep parameterless constructor for tools that may need it.
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Only configure here when options have not been provided (e.g. when not using DI).
        if (!optionsBuilder.IsConfigured)
        {
            // Prefer an environment variable for the connection string to avoid hard-coded values.
            var conn = Environment.GetEnvironmentVariable("CONNECTION_STRING")
                       ?? "Data Source=contacts.db";
            optionsBuilder.UseSqlite(conn);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure relationships and constraints if needed
        modelBuilder.Entity<Categoria>()
            .HasMany(c => c.Contactos)
            .WithOne(c => c.Categoria)
            .HasForeignKey(c => c.CategoriaId)
            .OnDelete(DeleteBehavior.Cascade);

        base.OnModelCreating(modelBuilder);
    }
}
