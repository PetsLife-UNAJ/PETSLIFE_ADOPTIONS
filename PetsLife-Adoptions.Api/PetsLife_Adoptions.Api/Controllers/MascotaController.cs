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
    [Route("Mascota")]
    
    public class MascotaController : ControllerBase
    {
        private readonly IMascotaService _service;
        public MascotaController(IMascotaService service )
        {
            this._service = service;
        }
        [HttpPost]
        
        public IActionResult post(MascotaDto mascotaDto)
        {
            try
            {
                return new JsonResult(_service.CreateMascota(mascotaDto)) { StatusCode = 201 };
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
            
        }
        
    }
}
