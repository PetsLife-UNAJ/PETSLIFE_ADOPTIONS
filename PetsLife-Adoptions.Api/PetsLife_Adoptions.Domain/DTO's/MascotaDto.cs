namespace Domain.DTO_s
{
    public class MascotaDto
    {
        public int MascotaId { get; set; }
        public string TipoAnimal { get; set; }
        public int TipoAnimalId { get; set; }
        public bool Adoptado { get; set; }
        public string Imagen { get; set; }
        public string Nombre { get; set; }
        public string Historia { get; set; }
        public int Edad { get; set; }
        public double Peso { get; set; }

    }
}
