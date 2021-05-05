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
    public class MascotaQuery : IMascotaQuery
    {
        private readonly IDbConnection connection;
        private readonly Compiler SqlKata;

        public MascotaQuery(IDbConnection connection, Compiler sqlKata)
        {
            this.connection = connection;
            this.SqlKata = sqlKata;
        }

        

        public List<MascotaDto> GetAllMascotas()
        {
            var db = new QueryFactory(connection, SqlKata);
            var mascota = db.Query("Mascotas")
                .Join("Animales", "Animales.TipoAnimalId", "Mascotas.AnimalId")
                .Select("Nombre", "Edad", "Peso", "Imagen", "Historia", "AnimalId AS TipoAnimalId", "Animales.TipoAnimal");
                

            var result = mascota.Get<MascotaDto>();

            return result.ToList();

           
        }

        public MascotaDto GetMascotaById(int id)
        {
            var db = new QueryFactory(connection, SqlKata);
            var query = db.Query("Mascotas")
                .Join("Animales" , "Animales.TipoAnimalId" , "Mascotas.AnimalId")
                .Select("Nombre", "Edad", "Peso", "Imagen", "Historia", "AnimalId AS TipoAnimalId", "Animales.TipoAnimal")
                .Where("Mascotas.MascotaId", "=", id)
                .FirstOrDefault<MascotaDto>();
            
            return query;
        }
    }
}
 