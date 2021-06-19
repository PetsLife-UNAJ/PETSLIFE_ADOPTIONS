using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace PetsLife_Adoptions.Api.Controllers
{
    [ApiController]
    [Route("api/TiposMascotas")]
    //[Authorize]
    public class TipoMascotaController : ControllerBase
    {
        private readonly ITipoMascotaService _service;
        public TipoMascotaController(ITipoMascotaService service)
        {
            this._service = service;
        }
        [HttpGet("/Tipos")]
        public IActionResult GetTipos()
        {
            try
            {
                return new JsonResult(_service.GetTipos()) { StatusCode = 200 };
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}