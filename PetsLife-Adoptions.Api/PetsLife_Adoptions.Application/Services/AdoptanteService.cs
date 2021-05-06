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

namespace Application.Services
{
    public interface IAdoptanteService 
    {
        Adoptante CreateAdoptante(AdoptanteDto adoptante);
        List<AdoptanteDto> GetAdoptantes();
        AdoptanteDto GetAdoptante(int id);
        void DeleteAdoptante(int id);
    }
    public class AdoptanteService : IAdoptanteService
    {
        private readonly IGenericRepository _repository;
        private readonly IAdoptanteQuery _query;
        public AdoptanteService(IGenericRepository repository, IAdoptanteQuery query) 
        {
            this._repository = repository;
            this._query = query;
        }
        public Adoptante CreateAdoptante(AdoptanteDto adoptante)
        {
            var validator = new AdoptanteValidator();
            validator.ValidateAndThrow(adoptante);
            var Entity = new Adoptante
            {
                Nombre = adoptante.Nombre,
                Apellido = adoptante.Apellido,
                Dni = adoptante.Dni,
                Direccion = adoptante.Direccion,
                Telefono = adoptante.Telefono,
                Email = adoptante.Email,
            };
            _repository.Add<Adoptante>(Entity);
            return Entity;
        }

        public void DeleteAdoptante(int id)
        {
            _repository.Delete<Adoptante>(id);
        }

        public AdoptanteDto GetAdoptante(int id)
        {
            return _query.GetAdoptanteById(id);
        }

        public List<AdoptanteDto> GetAdoptantes()
        {
            return _query.GetAllAdoptantes();
        }
    }
}
