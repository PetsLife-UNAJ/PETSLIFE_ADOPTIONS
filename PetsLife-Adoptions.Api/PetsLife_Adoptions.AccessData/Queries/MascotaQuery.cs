using AccessData.Queries.Repository;
using Domain.DTO_s;
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
            var query = db.Query("Mascotas");

            var result = query.Get<MascotaDto>();

            return result.ToList();
        }

        public MascotaDto GetMascotaById(int id)
        {
            var db = new QueryFactory(connection, SqlKata);
            var query = db.Query("Mascotas").Where("MascotaId", id).First();

            var mascota = new MascotaDto
            {
                Nombre = query.Nombre,
                Peso = query.Peso,
                Imagen = query.Imagen,
                Historia = query.Historia,
                AnimalId = query.AnimalId,
                Edad = query.Edad
            };


            return mascota;
        }
    }
}
 