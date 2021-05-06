using Domain.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessData.Queries.Repository
{
    public interface IMascotaQuery
    {
        List<ResponseMascotaDto> GetAllMascotas();
        MascotaDto GetMascotaById(int id);
        List<MascotaDto> GetAllMascotasByTipoAnimales(int id);
        List<MascotaDto> GetAllAdoptados();
        List<MascotaDto> GetAllAdoptables();


    }
}
