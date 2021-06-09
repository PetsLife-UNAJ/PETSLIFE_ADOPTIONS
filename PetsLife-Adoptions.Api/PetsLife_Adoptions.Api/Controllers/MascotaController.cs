using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Services;
using PetsLife_Adoptions.Domain.Entities;
using Domain.DTO_s;
using Microsoft.AspNetCore.Http;

namespace PetsLife_Adoptions.Api.Controllers
{
    [ApiController]
    [Route("api/Mascota")]

    public class MascotaController : ControllerBase
    {
        private readonly IMascotaService _service;
        public MascotaController(IMascotaService service)
        {
            this._service = service;
        }
        [HttpPost]
        public IActionResult Post(MascotaDto mascotaDto)
        {
            try
            {
                return new JsonResult(_service.CreateMascota(mascotaDto)) { StatusCode = 201 };
            }
            catch (Exception )
            {

                return BadRequest(new { error = "no se pudo crear"});
            }

        }
        

        [HttpGet("/Mascotas/All")]
        public IActionResult GetAll()
        {
            try
            {
                return new JsonResult(_service.GetMascotas()) { StatusCode = 200 };
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

        }
        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            try
            {
                return new JsonResult(_service.GetMascota(id)) { StatusCode = 200 };
            }
            catch (Exception )
            {

                return BadRequest("No se encuentra en la base de datos");
            }


        }
        [HttpGet("/TipoAnimal/{id}")]
        public ActionResult GetAllTipoAnimal(int id)
        {
            try
            {
                return new JsonResult(_service.GetMascotasPorTipoAnimal(id)) { StatusCode = 200 };
            }
            catch (Exception)
            {

                return BadRequest("No se encuentra en la base de datos");
            }

        }
        [HttpGet("/Adoptados")]
        public IActionResult GetAdoptados()
        {
            try
            {
                return new JsonResult(_service.GetAdoptados()) { StatusCode = 200 };
            }
            catch (Exception)
            {

                return BadRequest("No se encuentra en la base de datos");
            }

        }
        [HttpGet("/Adoptables")]
        public IActionResult GetAdoptables()
        {
            try
            {
                return new JsonResult(_service.GetAdoptables()) { StatusCode = 200 };
            }
            catch (Exception)
            {

                return BadRequest("No se encuentra en la base de datos");
            }

        }
        [HttpPut("{id}")]
        public IActionResult UpdateMascota([FromRoute]int id ,MascotaDto mascota)
        {
            try
            {
                return new JsonResult(_service.UpdateMascota(id ,mascota)) { StatusCode = 200 };
            }
            catch (Exception)
            {

                return BadRequest("No se encuentra en la base de datos");
            }

        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _service.DeleteMascota(id);
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest("No se encuentra en la base de datos");
            }
        }
    }
}
