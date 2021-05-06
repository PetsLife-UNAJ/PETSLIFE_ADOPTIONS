using Domain.DTO_s;
using PetsLife_Adoptions.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessData.Queries.Repository
{
    public interface IAdoptanteQuery
    {
        List<AdoptanteDto> GetAllAdoptantes();
        AdoptanteDto GetAdoptanteById(int id);
        Mascota GetMascotaById(int id);
    }
}
