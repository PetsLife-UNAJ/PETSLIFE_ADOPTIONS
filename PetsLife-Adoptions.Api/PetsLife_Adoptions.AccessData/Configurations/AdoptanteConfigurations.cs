using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetsLife_Adoptions.Domain.Entities;

namespace PetsLife_Adoptions.AccessData.Configurations
{
    class AdoptanteConfigurations
    {
        public AdoptanteConfigurations(EntityTypeBuilder<Adoptante> modelBuilder)
        {
            modelBuilder
               .HasKey(s => s.AdoptanteId);
            modelBuilder
                .Property(s => s.Apellido)
                .IsRequired();
            modelBuilder
                .Property(s => s.Nombre)
                .IsRequired();
            modelBuilder
                .Property(s => s.Dni)
                .IsRequired();
            modelBuilder
                .Property(s => s.Direccion)
                .IsRequired();
            modelBuilder
                .Property(s => s.Telefono)
                .IsRequired();
            modelBuilder
                .Property(s => s.Email)
                .IsRequired();
        }
    }
}
