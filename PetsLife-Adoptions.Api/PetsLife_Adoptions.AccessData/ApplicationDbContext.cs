using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using PetsLife_Adoptions.Domain.Entities;
using PetsLife_Adoptions.AccessData.Configurations;
using System.Text;

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

        internal void Add<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder ) 
        {

            new AdoptanteConfigurations(modelBuilder.Entity<Adoptante>());
            new AdoptanteMascotaConfigurations(modelBuilder.Entity<AdoptanteMascota>());
            new AnimalConfigurations(modelBuilder.Entity<Animal>());
            new MascotaConfigurations(modelBuilder.Entity<Mascota>());

            base.OnModelCreating(modelBuilder);

        }

    }
}
