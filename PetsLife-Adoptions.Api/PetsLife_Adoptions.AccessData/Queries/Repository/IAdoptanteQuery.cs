using Domain.DTO_s;
using PetsLife_Adoptions.Domain.Entities;
using System.Collections.Generic;

namespace AccessData.Queries.Repository
{
    public interface IAdoptanteQuery
    {
        List<AdoptanteDto> GetAllAdoptantes();
        AdoptanteDto GetAdoptanteById(int id);
        Mascota GetMascotaById(int id);
    }
}
