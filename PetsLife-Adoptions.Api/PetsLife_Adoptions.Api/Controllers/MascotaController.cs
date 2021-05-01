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
        //[ProducesResponseType(StatusCodes.Status201Created)]
        public Mascota post(MascotaDto mascotaDto)
        {
            return _service.CreateMascota(mascotaDto);
        }
    }
}
