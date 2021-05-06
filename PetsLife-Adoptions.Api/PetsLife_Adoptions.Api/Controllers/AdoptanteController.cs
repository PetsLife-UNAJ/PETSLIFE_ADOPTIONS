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
    [Route("api/Adoptante")]

    public class AdoptanteController : ControllerBase
    {
        private readonly IAdoptanteService _service;
        public AdoptanteController(IAdoptanteService service)
        {
            this._service = service;
        }
        [HttpPost]
        public IActionResult Post(AdoptanteDto adoptanteDto)
        {
            try
            {
                return new JsonResult(_service.CreateAdoptante(adoptanteDto)) { StatusCode = 201 };
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

        }

        [HttpGet("All")]
        public IActionResult GetAll()
        {
            try
            {
                return new JsonResult(_service.GetAdoptantes()) { StatusCode = 200 };
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
                return new JsonResult(_service.GetAdoptante(id)) { StatusCode = 200 };
            }
            catch (Exception )
            {

                return BadRequest("No se encuentra en la base de datos");
            }


        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _service.DeleteAdoptante(id);
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest("No se encuentra en la base de datos");
            }
        }
    }
}
