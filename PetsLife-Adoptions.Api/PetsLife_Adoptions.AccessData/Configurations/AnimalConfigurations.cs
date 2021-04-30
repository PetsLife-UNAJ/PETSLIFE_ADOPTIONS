using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetsLife_Adoptions.Domain.Entities;

namespace PetsLife_Adoptions.AccessData.Configurations
{
    class AnimalConfigurations
    {
        public AnimalConfigurations (EntityTypeBuilder<Animal> modelBuilder) 
        {
            modelBuilder
                .HasKey(s => s.TipoAnimalId)
                .HasName("AnimalId");
            modelBuilder
                .Property(s => s.TipoAnimal)
                .IsRequired();

            /* Carga de Tipos de Animales*/
            modelBuilder.HasData(new Animal { TipoAnimalId = 1, TipoAnimal = "Canino" });
            modelBuilder.HasData(new Animal { TipoAnimalId = 2, TipoAnimal = "Felino" });
            modelBuilder.HasData(new Animal { TipoAnimalId = 3, TipoAnimal = "Reptil" });
            modelBuilder.HasData(new Animal { TipoAnimalId = 4, TipoAnimal = "Roedor" });
            modelBuilder.HasData(new Animal { TipoAnimalId = 5, TipoAnimal = "Anfibio" });
            modelBuilder.HasData(new Animal { TipoAnimalId = 6, TipoAnimal = "Mamifero" });
            modelBuilder.HasData(new Animal { TipoAnimalId = 7, TipoAnimal = "Acuatico" });
            modelBuilder.HasData(new Animal { TipoAnimalId = 8, TipoAnimal = "Artropodo" });
            modelBuilder.HasData(new Animal { TipoAnimalId = 9, TipoAnimal = "Insecto" });
            modelBuilder.HasData(new Animal { TipoAnimalId = 10, TipoAnimal = "Ave" });
            modelBuilder.HasData(new Animal { TipoAnimalId = 11, TipoAnimal = "Aracnido" });
        }
    }
}
