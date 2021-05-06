using AccessData.Commad.Repository;
using Domain.DTO_s;
using PetsLife_Adoptions.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccessData.Validations;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using AccessData.Queries.Repository;
using AccessData.Queries;

namespace Application.Services
{
    public interface IAdoptanteMascotaService
    {
        
        List<AdoptanteDto> GetAdoptanteMascotas();
        void DeleteAdoptanteMascota(int id);
        List<AdoptanteDto> GetPosiblesAdoptantes();
        List<AdoptanteDto> GetAdopcionesConfirmadas();

    }
    public class AdoptanteMascotaService : IAdoptanteMascotaService
    {
        private readonly IGenericRepository _repository;
        private readonly IAdoptanteMascotaQuery _query;
        public AdoptanteMascotaService(IGenericRepository repository, IAdoptanteMascotaQuery query) 
        {
            this._repository = repository;
            this._query = query;
        }

        public void DeleteAdoptanteMascota(int id)
        {
            _repository.Delete<AdoptanteMascota>(id);
        }

        public List<AdoptanteDto> GetAdopcionesConfirmadas()
        {
            return _query.GetAdopcionesAprobadas();
        }

        public List<AdoptanteDto> GetAdoptanteMascotas()
        {
            return _query.GetAdoptantesAll();
        }

        public List<AdoptanteDto> GetPosiblesAdoptantes()
        {
            return _query.GetPosibleAdoptantes();
        }

    }
}
