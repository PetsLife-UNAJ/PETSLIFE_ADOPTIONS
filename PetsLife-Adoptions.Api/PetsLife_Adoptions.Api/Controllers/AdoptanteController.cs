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
        [HttpPost("{id}")]
        public IActionResult Post([FromRoute] int id,AdoptanteDto adoptanteDto)
        {
            try
            {
                return new JsonResult(_service.CreateAdoptante(id,adoptanteDto)) { StatusCode = 201 };
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
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
