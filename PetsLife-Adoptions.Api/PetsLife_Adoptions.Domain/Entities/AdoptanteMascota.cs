using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsLife_Adoptions.Domain.Entities
{
    public class AdoptanteMascota
    {
        public int Id { get; set; }
        public int MascotaID { get; set; }
        public int AdoptanteId { get; set; }
    }
}
