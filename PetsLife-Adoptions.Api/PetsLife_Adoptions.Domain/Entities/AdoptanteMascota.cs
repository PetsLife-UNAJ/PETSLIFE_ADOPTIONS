﻿namespace PetsLife_Adoptions.Domain.Entities
{
    public class AdoptanteMascota
    {
        public int Id { get; set; }
        public int MascotaID { get; set; }

        public int AdoptanteId { get; set; }
        public Adoptante Adoptantes { get; set; }
        public Mascota Mascotas { get; set; }
    }
}
