using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO_s
{
    public class ResponseMascotaDto
    {
        public int MascotaId { get; set; }
        
        public int TipoAnimalId { get; set; }
        public bool Adoptado { get; set; }
        public string Imagen { get; set; }
        public string Nombre { get; set; }
        public string Historia { get; set; }
        public int Edad { get; set; }
        public double Peso { get; set; }

    }
}
