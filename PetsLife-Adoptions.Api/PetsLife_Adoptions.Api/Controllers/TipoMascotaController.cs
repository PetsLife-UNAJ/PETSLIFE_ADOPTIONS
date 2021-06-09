using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Services;

namespace PetsLife_Adoptions.Api.Controllers
{
    [ApiController]
    [Route("api/TiposMascotas")]
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
