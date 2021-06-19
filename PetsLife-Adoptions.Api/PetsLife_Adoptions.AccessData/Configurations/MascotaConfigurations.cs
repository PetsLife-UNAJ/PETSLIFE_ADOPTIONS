﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetsLife_Adoptions.Domain.Entities;

namespace PetsLife_Adoptions.AccessData.Configurations
{
    class MascotaConfigurations
    {
        public MascotaConfigurations(EntityTypeBuilder<Mascota> modelBuilder)
        {
            modelBuilder
                .HasKey(s => s.MascotaId);
            modelBuilder
                .HasOne<Animal>(s => s.Animales)
                .WithMany(g => g.Mascotas).HasForeignKey(j => j.AnimalId);

            modelBuilder
                .Property(s => s.Imagen)
                .IsRequired();
            modelBuilder
                .Property(s => s.Nombre)
                .IsRequired();
            modelBuilder
                .Property(s => s.Edad)
                .IsRequired();
            modelBuilder
                .Property(s => s.Peso)
                .IsRequired();
            modelBuilder
                .Property(s => s.Historia)
                .IsRequired();
            modelBuilder
                .Property(s => s.Adoptado)
                .IsRequired();
        }
    }
}
