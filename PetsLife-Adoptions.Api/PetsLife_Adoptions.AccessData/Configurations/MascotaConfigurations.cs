using Microsoft.EntityFrameworkCore.Metadata.Builders;
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

            /* Carga de Mascotas*/
            modelBuilder.HasData(new Mascota { MascotaId = 1, AnimalId = 1, Adoptado = false, Edad = 1, Historia = "Se darán desparacitados. Faltan 2 semanas para que desteten y pueden irse a un hogar definitivo!!", Imagen= "https://scontent.faep9-2.fna.fbcdn.net/v/t1.6435-9/203992742_287174139818403_7111540916636416702_n.jpg?_nc_cat=106&ccb=1-3&_nc_sid=730e14&_nc_eui2=AeG2rnFxKO0kDNCUKv-aFs7uCS0ud5s0Pt0JLS53mzQ-3b7thL_wiT9vWkkQ8aeIjC4hpGD2CsTERCui-2mxq9-t&_nc_ohc=6RZ4ZwAWuwsAX8rvyoU&_nc_ht=scontent.faep9-2.fna&oh=678793d7d4479262034af3c3f4884be2&oe=60F18064", Nombre="Morocha", Peso = 1 });
            modelBuilder.HasData(new Mascota { MascotaId = 2, AnimalId = 1, Adoptado = false, Edad = 3, Historia = "Ella es una perrita de Berazategui que llevamos a castrar y tiene Dioctophyma", Imagen = "https://scontent.faep9-1.fna.fbcdn.net/v/t1.6435-0/p180x540/191059195_10219931954945369_5336803052641565501_n.jpg?_nc_cat=100&ccb=1-3&_nc_sid=e3f864&_nc_eui2=AeFx6-ffV6qVqcZqzbiPmrih5UoO36HoWzjlSg7foehbOFAHKXbYj1_8w-I1pFWRBn8R83MGGe4FoDiKfiAx3aBX&_nc_ohc=hF6qS_fBD1UAX82TFdK&_nc_ht=scontent.faep9-1.fna&oh=24d84b85de6989caa9e1c89e550bc912&oe=60F0F42E", Nombre = "Negra", Peso = 12 });
            modelBuilder.HasData(new Mascota { MascotaId = 3, AnimalId = 2, Adoptado = false, Edad = 1, Historia = "Lo rescatamos junto a su hermano, Rómulo, de la calle cuando aún eran lactantes. Las probabilidades de que viva, como todo lactantes, eran mínimas. Remo fue criado a mamadera y por eso es súper mamero y cariñoso.", Imagen= "https://scontent.faep9-2.fna.fbcdn.net/v/t1.6435-0/p480x480/191161072_269984801537337_2154404893509938942_n.jpg?_nc_cat=110&ccb=1-3&_nc_sid=730e14&_nc_eui2=AeHqOdgWF6EnhdSUbyj_7ZzqOcj9D4ko_JA5yP0PiSj8kPFxuomn-MPU6dqi140R2dXVf8w2wW7164O59Gn94He9&_nc_ohc=iJejTUWb7CQAX8LZGMV&_nc_ht=scontent.faep9-2.fna&oh=883400aa521e1e8e559653a0c9039d12&oe=60F21513", Nombre="Romulo", Peso = 10 });
            modelBuilder.HasData(new Mascota { MascotaId = 4, AnimalId = 1, Adoptado = false, Edad = 1, Historia = "Maqui es una hembra de tamaño grande, tiene alrededor de un año y está castrada. Es muy tranquila y ama pasear, se lleva de maravilla con perros!! Pero no con gatos y niños.", Imagen = "https://scontent.faep9-1.fna.fbcdn.net/v/t1.6435-9/170693894_238731724662645_1378015511004095585_n.jpg?_nc_cat=100&ccb=1-3&_nc_sid=730e14&_nc_eui2=AeGjA1uyjLs86IugqR0B4qnTJYKQqRyvSSclgpCpHK9JJ-5Hc5CtCssJRQ8Pc3EJAGs0XFxixlri5o0muBHMKIqP&_nc_ohc=RETEU6qh1ckAX_wX4x6&_nc_ht=scontent.faep9-1.fna&oh=74090e9e334c6491136b87ac4a29925d&oe=60F135C0", Nombre = "Maqui", Peso = 8 });
            modelBuilder.HasData(new Mascota { MascotaId = 5, AnimalId = 3, Adoptado = false, Edad = 3, Historia = "El es Pepe, es un loro hablador tiene aproximadamente 3 años y medio. Ya esta desparacitado.", Imagen = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQNSj4o_j4-Y4-DeZbBgYNksKbVDOwVeef4hBErRXzMbT7cDB5A8Fos7Ym6XnSEnXQq7wQ&usqp=CAU", Nombre = "Pepe", Peso = 1 });       
        }
    }
}
