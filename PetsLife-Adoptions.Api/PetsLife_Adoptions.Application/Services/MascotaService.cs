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
        ResponseMascotaDto CreateMascota(MascotaDto mascota);
        List<ResponseMascotaDto> GetMascotas();
        MascotaDto GetMascota(int id);
        List<MascotaDto> GetMascotasPorTipoAnimal(int id);
        List<MascotaDto> GetAdoptados();
        List<MascotaDto> GetAdoptables();
        ResponseMascotaDto UpdateMascota(int id ,MascotaDto mascota);
        
        void DeleteMascota(int id);
    }
    public class MascotaService : IMascotaService
    {
        private readonly IGenericRepository _repository;
        private readonly IMascotaQuery _query;
        public MascotaService(IGenericRepository repositry, IMascotaQuery query)
        {
            this._repository = repositry;
            this._query = query;
        }

        public ResponseMascotaDto CreateMascota(MascotaDto mascota)
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
                Historia = mascota.Historia,
                Adoptado = mascota.Adoptado
            };

            _repository.Add<Mascota>(Entity);

            var responseEntity = new ResponseMascotaDto
            {
                MascotaId = Entity.MascotaId,
                Nombre = mascota.Nombre,
                Peso = mascota.Peso,
                TipoAnimalId = mascota.TipoAnimalId,
                Edad = mascota.Edad,
                Imagen = mascota.Imagen,
                Historia = mascota.Historia,
                Adoptado = mascota.Adoptado
            };


            return responseEntity;

        }

        public void DeleteMascota(int id)
        {
            _repository.Delete<Mascota>(id);
        }

        public List<MascotaDto> GetAdoptables()
        {
            return _query.GetAllAdoptables();
        }

        public List<MascotaDto> GetAdoptados()
        {
            return _query.GetAllAdoptados();
        }

        public MascotaDto GetMascota(int id)
        {
            return _query.GetMascotaById(id);
        }

        public List<ResponseMascotaDto> GetMascotas()
        {
            return _query.GetAllMascotas();
        }

        public List<MascotaDto> GetMascotasPorTipoAnimal(int id)
        {

            return _query.GetAllMascotasByTipoAnimales(id);

        }

       

        public ResponseMascotaDto UpdateMascota(int id , MascotaDto mascota)
        {
            var validator = new MascotaValidator();

            validator.ValidateAndThrow(mascota);

            var Entity = new Mascota
            {
                MascotaId = id, 
                Nombre = mascota.Nombre,
                Peso = mascota.Peso,
                AnimalId = mascota.TipoAnimalId,
                Edad = mascota.Edad,
                Imagen = mascota.Imagen,
                Historia = mascota.Historia,
                Adoptado = mascota.Adoptado
            };

            _repository.Update<Mascota>(Entity);

            var responseEntity = new ResponseMascotaDto
            {
                MascotaId = Entity.MascotaId,
                Nombre = mascota.Nombre,
                Peso = mascota.Peso,
                TipoAnimalId = mascota.TipoAnimalId,
                Edad = mascota.Edad,
                Imagen = mascota.Imagen,
                Historia = mascota.Historia,
                Adoptado = mascota.Adoptado
            };


            return responseEntity;

            
        }
    }
}
