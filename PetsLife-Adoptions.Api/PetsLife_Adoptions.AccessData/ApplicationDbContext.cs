using Microsoft.EntityFrameworkCore;
using PetsLife_Adoptions.AccessData.Configurations;
using PetsLife_Adoptions.Domain.Entities;

namespace PetsLife_Adoptions.AccessData
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options
            ) : base(options)
        {
        }

        public DbSet<Adoptante> Adoptantes { get; set; }
        public DbSet<Mascota> Mascotas { get; set; }
        public DbSet<Animal> Animales { get; set; }
        public DbSet<AdoptanteMascota> AdoptanteMascotas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new AdoptanteConfigurations(modelBuilder.Entity<Adoptante>());
            new AdoptanteMascotaConfigurations(modelBuilder.Entity<AdoptanteMascota>());
            new AnimalConfigurations(modelBuilder.Entity<Animal>());
            new MascotaConfigurations(modelBuilder.Entity<Mascota>());

            base.OnModelCreating(modelBuilder);
        }
    }
}