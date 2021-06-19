using Domain.DTO_s;
using System.Collections.Generic;

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
