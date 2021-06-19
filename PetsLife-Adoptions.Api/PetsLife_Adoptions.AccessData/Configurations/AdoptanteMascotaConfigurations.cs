using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetsLife_Adoptions.Domain.Entities;

namespace PetsLife_Adoptions.AccessData.Configurations
{
    class AdoptanteMascotaConfigurations
    {
        public AdoptanteMascotaConfigurations(EntityTypeBuilder<AdoptanteMascota> modelBuilder)
        {
            modelBuilder
                .HasKey(s => s.Id);
            modelBuilder
                .HasOne<Adoptante>(s => s.Adoptantes)
                .WithMany(g => g.AdoptanteMascota)
                .HasForeignKey(s => s.AdoptanteId);
            modelBuilder
                .HasOne<Mascota>(s => s.Mascotas)
                .WithMany(g => g.AdoptanteMascota)
                .HasForeignKey(s => s.MascotaID);

        }
    }
}
