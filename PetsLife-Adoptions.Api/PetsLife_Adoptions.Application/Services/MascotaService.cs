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
    public interface IMascotaService
    {
        Mascota CreateMascota(MascotaDto mascota);
        List<MascotaDto> GetMascotas();
        MascotaDto GetMascota(int id);
        void DeleteMascota(int id);
    }
    public class MascotaService : IMascotaService
    {
        private readonly IGenericRepository _repository;
        private readonly IMascotaQuery _query;
        public MascotaService(IGenericRepository repositry , IMascotaQuery query)
        {
            this._repository = repositry;
            this._query = query;
        }

        public Mascota CreateMascota(MascotaDto mascota)
        {
            var validator = new MascotaValidator();
           
            validator.ValidateAndThrow(mascota);

            var Entity = new Mascota
            {
                Nombre = mascota.Nombre,
                Peso = mascota.Peso,
                AnimalId = mascota.TipoAnimalId,
                Edad = mascota.Edad,
                Imagen = mascota.Imagen,
                Historia = mascota.Historia
            };

            _repository.Add<Mascota>(Entity);
            return Entity;
        
        }

        public void DeleteMascota(int id)
        {
            _repository.Delete<Mascota>(id);
        }

        public MascotaDto GetMascota(int id)
        {
            return _query.GetMascotaById(id);
        }

        public List<MascotaDto> GetMascotas()
        {
            return _query.GetAllMascotas();
        } 

        
    }
}
