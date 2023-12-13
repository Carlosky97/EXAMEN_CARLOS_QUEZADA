using Microsoft.EntityFrameworkCore;
using ServiciosTallerMecanico.Models;

namespace ServiciosTallerMecanico.Data
{
    // Esta clase representa el contexto de la base de datos para la API del Taller Mecánico.
    public class APIMecanicoDbContext : DbContext
    {
        // Constructor que toma DbContextOptions como parámetro.
        public APIMecanicoDbContext(DbContextOptions options) : base(options)
        {

        }
        // Define un DbSet para la entidad 'Mecanico'. Este DbSet se utilizará para interactuar con la tabla 'MECANICO' en la base de datos.
        public DbSet<Mecanico> Mecanico { get; set; }

        // Este método se llama cuando se está creando el modelo para el contexto.
        // Permite configurar el modelo utilizando el parámetro modelBuilder.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Mapea la entidad 'Mecanico' a la tabla 'MECANICO' en la base de datos.
            modelBuilder.Entity<Mecanico>().ToTable("MECANICO");
        }
    }
}
