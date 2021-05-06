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
        AdoptanteDto CreateAdoptante(int id,AdoptanteDto adoptante);
        void DeleteAdoptante(int id);
        void ConfirmAdoption(Adoptante adoptante, Mascota mascota);
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
        public AdoptanteDto CreateAdoptante(int id,AdoptanteDto adoptante)
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
            var Mascota = _query.GetMascotaById(id);
            ConfirmAdoption(Entity,Mascota);

            var dto = new AdoptanteDto
            {
                Nombre = Entity.Nombre,
                Apellido = Entity.Apellido,
                Dni = Entity.Dni,
                Direccion = Entity.Direccion,
                Telefono = Entity.Telefono,
                Email = Entity.Email,
                MascotaId = Mascota.MascotaId,
                AdoptanteId = Entity.AdoptanteId
            };
            
            return dto;
        }

        public void DeleteAdoptante(int id)
        {
            _repository.Delete<Adoptante>(id);
        }

        public void ConfirmAdoption(Adoptante adoptante, Mascota mascota)
        {
            var Entity = new AdoptanteMascota
            {
                AdoptanteId = adoptante.AdoptanteId,
                MascotaID = mascota.MascotaId
            };
            _repository.Add<AdoptanteMascota>(Entity);
            var dto = new AdoptanteMascotaDto
            {
                AdoptanteId = Entity.AdoptanteId,
                MascotaId = Entity.MascotaID
            };
            
        }
    }
}
