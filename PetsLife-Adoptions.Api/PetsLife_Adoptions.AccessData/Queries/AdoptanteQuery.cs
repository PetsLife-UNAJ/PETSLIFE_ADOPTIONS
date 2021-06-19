using AccessData.Queries.Repository;
using Domain.DTO_s;
using PetsLife_Adoptions.Domain.Entities;
using SqlKata.Compilers;
using SqlKata.Execution;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace AccessData.Queries
{
    public class AdoptanteQuery : IAdoptanteQuery
    {
        private readonly IDbConnection connection;
        private readonly Compiler SqlKata;

        public AdoptanteQuery(IDbConnection connection, Compiler sqlKata)
        {
            this.connection = connection;
            this.SqlKata = sqlKata;
        }
        public AdoptanteDto GetAdoptanteById(int id)
        {
            var db = new QueryFactory(connection, SqlKata);
            var query = db.Query("Adoptantes")
                .Join("AdoptanteMascota", "Adoptantes.AdoptanteId", "Adoptantes.AdoptanteId")
                .Select("Nombre", "Apellido", "Dni", "Direccion", "Telefono", "Email", "AdoptanteId")
                .Where("Adoptantes.AdoptanteId", "=", id)
                .FirstOrDefault<AdoptanteDto>();
            return query;
        }

        public List<AdoptanteDto> GetAllAdoptantes()
        {
            var db = new QueryFactory(connection, SqlKata);
            var adoptante = db.Query("Adoptantes")
                .Join("Adoptantes", "Adoptantes.AdoptanteId", "Adoptantes.AdoptanteId")
                .Select("Nombre", "Apellido", "Dni", "Direccion", "Telefono", "Email", "AdoptanteId");
            var result = adoptante.Get<AdoptanteDto>();

            return result.ToList();
        }

        public Mascota GetMascotaById(int id)
        {
            var db = new QueryFactory(connection, SqlKata);
            var query = db.Query("Mascotas")
                .Join("Animales", "Animales.TipoAnimalId", "Mascotas.AnimalId")
                .Select("Nombre", "Edad", "Peso", "Imagen", "Historia", "AnimalId AS TipoAnimalId", "Animales.TipoAnimal", "MascotaId")
                .Where("Mascotas.MascotaId", "=", id)
                .First<Mascota>();

            return query;
        }
    }
}
