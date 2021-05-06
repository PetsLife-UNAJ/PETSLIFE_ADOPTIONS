using Domain.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessData.Queries.Repository
{
    interface IAdoptanteMascotaQuery
    {
        List<AdoptanteMascotaDto> GetAdoptanteMascotas();
        //AdoptanteMascotaDto GetAdoptanteMascota();
        AdoptanteDto GetAdoptante(int id);
        MascotaDto GetMascota(int id);
    }
}
