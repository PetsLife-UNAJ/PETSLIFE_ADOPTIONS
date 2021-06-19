using System.Collections.Generic;

namespace PetsLife_Adoptions.Domain.Entities
{
    public class Adoptante
    {
        public int AdoptanteId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Dni { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public List<AdoptanteMascota> AdoptanteMascota { get; set; }

    }
}
