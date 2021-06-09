using Domain.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessData.Queries.Repository
{
    public interface ITipoMascotaQuery
    {
        List<TipoMascotaDTO> GetAllTipos();
    }
}
