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
    public class TipoMascotaQuery : ITipoMascotaQuery
    {
        private readonly IDbConnection connection;
        private readonly Compiler SqlKata;

        public TipoMascotaQuery(IDbConnection connection, Compiler sqlKata)
        {
            this.connection = connection;
            this.SqlKata = sqlKata;
        }
        public List<TipoMascotaDTO> GetAllTipos()
        {
            var db = new QueryFactory(connection, SqlKata);
            var mascota = db.Query("Animales")
                .Select("TipoAnimalId" , "TipoAnimal");


            var result = mascota.Get<TipoMascotaDTO>();

            return result.ToList();
        }
    }
}
