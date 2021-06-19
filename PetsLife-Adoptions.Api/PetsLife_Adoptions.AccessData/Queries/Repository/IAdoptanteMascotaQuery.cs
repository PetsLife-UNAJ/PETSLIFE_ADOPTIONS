using Domain.DTO_s;
using System.Collections.Generic;

namespace AccessData.Queries.Repository
{
    public interface IAdoptanteMascotaQuery
    {
        List<AdoptanteDto> GetAdoptantesAll();
        List<AdoptanteDto> GetPosibleAdoptantes();
        List<AdoptanteDto> GetAdopcionesAprobadas();
    }
}
