﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PetsLife_Adoptions.Domain.Entities
{
    public class Adoptante
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Dni { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public bool EsApto { get; set; }

    }
}
