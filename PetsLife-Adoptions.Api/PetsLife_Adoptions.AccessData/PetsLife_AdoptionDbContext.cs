using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using PetsLife_Adoptions.Domain.Entities;
using System.Text;

namespace PetsLife_Adoptions.AccessData
{
    public class PetsLife_AdoptionDbContext : DbContext
    {
        public PetsLife_AdoptionDbContext(DbContextOptions<PetsLife_AdoptionDbContext> options
            ) : base(options)
        {

        }
    
        public DbSet<Adoptante> Adoptantes { get; set; }
        public DbSet<Mascota> Mascotas { get; set; }
        public DbSet<Animal> Animales { get; set; }
        public DbSet<AdoptanteMascota> AdoptanteMascotas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server = localhost; Database = PetsLife_Adoption_Db ; Trusted_Connection = True; MultipleActiveResultSets = True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder ) 
        {
            /*Key and Relations - Animales*/

            modelBuilder.Entity<Animal>()
                .HasKey(s => s.TipoAnimalId)
                .HasName("AnimalId");
            modelBuilder.Entity<Animal>()
                .Property(s => s.TipoAnimal)
                .IsRequired();

            /*Key and Relations - Adoptante*/

            modelBuilder.Entity<Adoptante>()
                .HasKey(s => s.AdoptanteId)
                .HasName("AdoptanteId");
            modelBuilder.Entity<Adoptante>()
                .Property(s => s.Apellido)
                .IsRequired();
            modelBuilder.Entity<Adoptante>()
                .Property(s => s.Nombre)
                .IsRequired();
            modelBuilder.Entity<Adoptante>()
                .Property(s => s.Dni)
                .IsRequired();
            modelBuilder.Entity<Adoptante>()
                .Property(s => s.Direccion)
                .IsRequired();
            modelBuilder.Entity<Adoptante>()
                .Property(s => s.Telefono)
                .IsRequired();
            modelBuilder.Entity<Adoptante>()
                .Property(s => s.Email)
                .IsRequired();

            /*Key and Relations - Adoptante Mascota */

            modelBuilder.Entity<AdoptanteMascota>()
                .HasKey(s => s.Id)
                .HasName("Id");
            modelBuilder.Entity<AdoptanteMascota>()
                .HasOne<Adoptante>(s => s.Adoptantes)
                .WithMany(g => g.AdoptanteMascota)
                .HasForeignKey(s => s.AdoptanteId);
            modelBuilder.Entity<AdoptanteMascota>()
                .HasOne<Mascota>(s => s.Mascotas)
                .WithMany(g => g.AdoptanteMascota)
                .HasForeignKey(s => s.MascotaID);

            /*Key and Relations - Mascota */

            modelBuilder.Entity<Mascota>()
                .HasKey(s => s.MascotaId)
                .HasName("AdoptanteId");
            modelBuilder.Entity<Mascota>()
                .Property(s => s.AnimalId)
                .IsRequired();
            modelBuilder.Entity<Mascota>()
                .Property(s => s.Imagen)
                .IsRequired();
            modelBuilder.Entity<Mascota>()
                .Property(s => s.Nombre)
                .IsRequired();
            modelBuilder.Entity<Mascota>()
                .Property(s => s.Edad)
                .IsRequired();
            modelBuilder.Entity<Mascota>()
                .Property(s => s.Peso)
                .IsRequired();



            /* Carga de Tipos de Animales*/
            modelBuilder.Entity<Animal>().HasData(new Animal { TipoAnimalId = 1, TipoAnimal = "Canino" });
            modelBuilder.Entity<Animal>().HasData(new Animal { TipoAnimalId = 2, TipoAnimal = "Felino" });
            modelBuilder.Entity<Animal>().HasData(new Animal { TipoAnimalId = 3, TipoAnimal = "Reptil" });
            modelBuilder.Entity<Animal>().HasData(new Animal { TipoAnimalId = 4, TipoAnimal = "Roedor" });
            modelBuilder.Entity<Animal>().HasData(new Animal { TipoAnimalId = 5, TipoAnimal = "Anfibio" });
            modelBuilder.Entity<Animal>().HasData(new Animal { TipoAnimalId = 6, TipoAnimal = "Mamifero" });
            modelBuilder.Entity<Animal>().HasData(new Animal { TipoAnimalId = 7, TipoAnimal = "Acuatico" });
            modelBuilder.Entity<Animal>().HasData(new Animal { TipoAnimalId = 8, TipoAnimal = "Artropodo" });
            modelBuilder.Entity<Animal>().HasData(new Animal { TipoAnimalId = 9, TipoAnimal = "Insecto" });
            modelBuilder.Entity<Animal>().HasData(new Animal { TipoAnimalId = 10, TipoAnimal = "Ave" });
            modelBuilder.Entity<Animal>().HasData(new Animal { TipoAnimalId = 11, TipoAnimal = "Aracnido" });

        }

    }
}
