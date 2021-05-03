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

namespace Application.Services
{
    public interface IMascotaService
    {
        Mascota CreateMascota(MascotaDto mascota);
    }
    public class MascotaService : IMascotaService
    {
        private readonly IGenericRepository _repository;
        public MascotaService(IGenericRepository repositry)
        {
            this._repository = repositry;
        }

        public Mascota CreateMascota(MascotaDto mascota)
        {
            var validator = new MascotaValidator();
           
            validator.ValidateAndThrow(mascota);

            var Entity = new Mascota
            {
                Nombre = mascota.Nombre,
                Peso = mascota.Peso,
                AnimalId = mascota.AnimalId,
                Edad = mascota.Edad,
                Imagen = mascota.Imagen
            };

            _repository.Add<Mascota>(Entity);
            return Entity;

           
           
            

          
        }
    }
}
