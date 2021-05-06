using AccessData.Queries.Repository;
using Domain.DTO_s;
using PetsLife_Adoptions.Domain.Entities;
using SqlKata.Compilers;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessData.Queries
{
    public class AdoptanteMascotaQuery : IAdoptanteMascotaQuery
    {
        private readonly IDbConnection connection;
        private readonly Compiler SqlKata;
        public AdoptanteMascotaQuery(IDbConnection connection, Compiler sqlKata) 
        {
            this.connection = connection;
            this.SqlKata = sqlKata;
        }

        public AdoptanteDto GetAdoptante(int id)
        {
            var db = new QueryFactory(connection, SqlKata);
            var query = db.Query("AdoptanteMascotas")
                .Join("Adoptantes", "Adoptantes.AdoptanteId", "AdoptanteMascotas.AdoptanteId")
                .Select("Nombre", "Apellido", "Dni", "Direccion", "Telefono", "Email")
                .Where("Adoptantes.AdoptanteId", "=", id)
                .FirstOrDefault<AdoptanteDto>();
            return query;
        }
        public MascotaDto GetMascota(int id)
        {
            var db = new QueryFactory(connection, SqlKata);
            var query = db.Query("Mascotas")
                .Join("Animales", "Animales.TipoAnimalId", "Mascotas.AnimalId")
                .Select("Nombre", "Edad", "Peso", "Imagen", "Historia", "AnimalId AS TipoAnimalId", "Animales.TipoAnimal")
                .Where("Mascotas.MascotaId", "=", id)
                .FirstOrDefault<MascotaDto>();

            return query;
        }

        public List<AdoptanteMascotaDto> GetAdoptanteMascotas()
        {
            var db = new QueryFactory(connection, SqlKata);
            var adoptante = db.Query("AdoptanteMascotas")
                .Join("Adoptantes", "Adoptantes.AdoptanteId", "AdoptanteMascotas.AdoptanteId")
                .Select("Nombre", "Apellido", "Dni", "Direccion", "Telefono", "Email");
            var result = adoptante.Get<AdoptanteMascotaDto>();

            return result.ToList();
        }
    }
}
