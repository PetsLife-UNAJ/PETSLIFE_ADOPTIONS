using Application.Services;
using Domain.DTO_s;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace PetsLife_Adoptions.Api.Controllers
{
    [ApiController]
    [Route("api/Adoptante")]
    //[Authorize]
    public class AdoptanteController : ControllerBase
    {
        private readonly IAdoptanteService _service;
        public AdoptanteController(IAdoptanteService service)
        {
            this._service = service;
        }
        [HttpPost("{id}")]
        public IActionResult Post([FromRoute] int id, AdoptanteDto adoptanteDto)
        {
            try
            {
                return new JsonResult(_service.CreateAdoptante(id, adoptanteDto)) { StatusCode = 201 };
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