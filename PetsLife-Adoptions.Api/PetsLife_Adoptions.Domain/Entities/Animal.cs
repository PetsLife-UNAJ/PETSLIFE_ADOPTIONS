using System.Collections.Generic;

namespace PetsLife_Adoptions.Domain.Entities
{
    public class Animal
    {
        public int TipoAnimalId { get; set; }
        public string TipoAnimal { get; set; }
        public ICollection<Mascota> Mascotas { get; set; }
    }
}
