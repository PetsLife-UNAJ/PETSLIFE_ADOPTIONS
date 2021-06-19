using Domain.DTO_s;
using System.Collections.Generic;

namespace AccessData.Queries.Repository
{
    public interface ITipoMascotaQuery
    {
        List<TipoMascotaDTO> GetAllTipos();
    }
}
