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
                .Join("AdoptanteMascota","Adoptantes.AdoptanteId","Adoptantes.AdoptanteId")
                .Select("Nombre", "Apellido", "Dni", "Direccion", "Telefono", "Email")
                .Where("Adoptantes.AdoptanteId","=",id)
                .FirstOrDefault<AdoptanteDto>();
            return query;
        }

        public List<AdoptanteDto> GetAllAdoptantes()
        {
            var db = new QueryFactory(connection, SqlKata);
            var adoptante = db.Query("Adoptantes")
                .Join("Adoptantes", "Adoptantes.AdoptanteId", "Adoptantes.AdoptanteId")
                .Select("Nombre", "Apellido", "Dni", "Direccion", "Telefono", "Email");
            var result = adoptante.Get<AdoptanteDto>();

            return result.ToList();
        }
    }
}
