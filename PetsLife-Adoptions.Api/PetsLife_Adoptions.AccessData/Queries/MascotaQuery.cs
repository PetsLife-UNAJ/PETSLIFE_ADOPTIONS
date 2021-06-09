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

        

        public List<ResponseMascotaDto> GetAllMascotas()
        {
            var db = new QueryFactory(connection, SqlKata);
            var mascota = db.Query("Mascotas")
                .Join("Animales", "Animales.TipoAnimalId", "Mascotas.AnimalId")
                .Select("MascotaId","Nombre", "Edad", "Peso","Adoptado","Imagen", "Historia", "AnimalId AS TipoAnimalId", "Animales.TipoAnimal");
                

            var result = mascota.Get<ResponseMascotaDto>();

            return result.ToList();

           
        }

        public MascotaDto GetMascotaById(int id)
        {
            var db = new QueryFactory(connection, SqlKata);
            var query = db.Query("Mascotas")
                .Join("Animales" , "Animales.TipoAnimalId" , "Mascotas.AnimalId")
                .Select("MascotaId", "Nombre", "Edad", "Peso", "Adoptado", "Imagen", "Historia", "AnimalId AS TipoAnimalId", "Animales.TipoAnimal")
                .Where("Mascotas.MascotaId", "=", id)
                .FirstOrDefault<MascotaDto>();
            
            return query;
        }
        public List<MascotaDto> GetAllMascotasByTipoAnimales(int id)
        {
            var db = new QueryFactory(connection, SqlKata);
            var query = db.Query("Mascotas")
                .Join("Animales", "Animales.TipoAnimalId", "Mascotas.AnimalId")
                .Select("MascotaId","Nombre", "Edad", "Peso","Adoptado", "Imagen", "Historia", "AnimalId AS TipoAnimalId", "Animales.TipoAnimal")
                .Where("Mascotas.AnimalId", "=", id);

            var result = query.Get<MascotaDto>().ToList();

            return result;

        }

        public List<MascotaDto> GetAllAdoptados()
        {
            var db = new QueryFactory(connection, SqlKata);
            var query = db.Query("Mascotas")
                .Join("Animales", "Animales.TipoAnimalId", "Mascotas.AnimalId")
                .Select("MascotaId", "Nombre", "Edad", "Peso", "Adoptado", "Imagen", "Historia", "AnimalId AS TipoAnimalId", "Animales.TipoAnimal")
                .Where("Mascotas.Adoptado", "=", true);

            var result = query.Get<MascotaDto>().ToList();

            return result;
        }

        public List<MascotaDto> GetAllAdoptables()
        {
            var db = new QueryFactory(connection, SqlKata);
            var query = db.Query("Mascotas")
                .Join("Animales", "Animales.TipoAnimalId", "Mascotas.AnimalId")
                .Select("MascotaId", "Nombre", "Edad", "Peso", "Adoptado", "Imagen", "Historia", "AnimalId AS TipoAnimalId", "Animales.TipoAnimal")
                .Where("Mascotas.Adoptado", "=", false);

            var result = query.Get<MascotaDto>().ToList();

            return result;
        }

        
    }
}
 