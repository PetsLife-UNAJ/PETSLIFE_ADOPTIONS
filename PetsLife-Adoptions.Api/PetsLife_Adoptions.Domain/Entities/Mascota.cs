using System;
using System.Collections.Generic;
using System.Text;

namespace PetsLife_Adoptions.Domain.Entities
{
    public class Mascota
    {
        public int MascotaId { get; set; }
<<<<<<< HEAD
        public int AnimalId { get; set; }
        public string Imagen { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public double Peso { get; set; }
=======
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public double Peso { get; set; }
        public string Imagen { get; set; }
>>>>>>> entities
        public List<AdoptanteMascota> AdoptanteMascota { get; set; }
    }
}
