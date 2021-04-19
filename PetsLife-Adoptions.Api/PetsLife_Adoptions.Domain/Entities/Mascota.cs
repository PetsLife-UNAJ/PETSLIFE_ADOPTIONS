using System;
using System.Collections.Generic;
using System.Text;

namespace PetsLife_Adoptions.Domain.Entities
{
    public class Mascota
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public double Peso { get; set; }
    }
}
