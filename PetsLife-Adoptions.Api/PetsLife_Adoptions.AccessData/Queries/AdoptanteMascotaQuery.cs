using AccessData.Queries.Repository;
using Domain.DTO_s;
using SqlKata.Compilers;
using SqlKata.Execution;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace AccessData.Queries
{
    public class AdoptanteMascotaQuery : IAdoptanteMascotaQuery
    {
        private readonly IDbConnection _connection;
        private readonly Compiler _SqlKata;
        public AdoptanteMascotaQuery(IDbConnection connection, Compiler sqlKata)
        {
            this._connection = connection;
            this._SqlKata = sqlKata;
        }

        public List<AdoptanteDto> GetAdopcionesAprobadas()
        {
            {
                var db = new QueryFactory(_connection, _SqlKata);
                var adoptante = db.Query("AdoptanteMascotas")
                    .Join("Adoptantes", "Adoptantes.AdoptanteId", "AdoptanteMascotas.AdoptanteId")
                    .Join("Mascotas", "Mascotas.MascotaId", "AdoptanteMascotas.MascotaId")
                    .Select("Adoptantes.Nombre", "Adoptantes.Apellido", "Adoptantes.Dni", "Adoptantes.Direccion", "Adoptantes.Telefono", "Adoptantes.Email", "Mascotas.MascotaId", "Adoptantes.AdoptanteId")
                    .Where("Mascotas.Adoptado", "=", true);
                var result = adoptante.Get<AdoptanteDto>();

                return result.ToList();
            }
        }

        public List<AdoptanteDto> GetAdoptantesAll()
        {
            var db = new QueryFactory(_connection, _SqlKata);
            var adoptante = db.Query("AdoptanteMascotas")
                .Join("Adoptantes", "Adoptantes.AdoptanteId", "AdoptanteMascotas.AdoptanteId")
                .Join("Mascotas", "Mascotas.MascotaId", "AdoptanteMascotas.MascotaId")
                .Select("Adoptantes.Nombre", "Adoptantes.Apellido", "Adoptantes.Dni", "Adoptantes.Direccion", "Adoptantes.Telefono", "Adoptantes.Email", "Mascotas.MascotaId", "Adoptantes.AdoptanteId");
            var result = adoptante.Get<AdoptanteDto>();

            return result.ToList();
        }

        public List<AdoptanteDto> GetPosibleAdoptantes()
        {
            var db = new QueryFactory(_connection, _SqlKata);
            var adoptante = db.Query("AdoptanteMascotas")
                .Join("Adoptantes", "Adoptantes.AdoptanteId", "AdoptanteMascotas.AdoptanteId")
                .Join("Mascotas", "Mascotas.MascotaId", "AdoptanteMascotas.MascotaId")
                .Select("Adoptantes.Nombre", "Adoptantes.Apellido", "Adoptantes.Dni", "Adoptantes.Direccion", "Adoptantes.Telefono", "Adoptantes.Email", "Mascotas.MascotaId", "Adoptantes.AdoptanteId")
                .Where("Mascotas.Adoptado", "=", false);
            var result = adoptante.Get<AdoptanteDto>();

            return result.ToList();
        }
    }
}
