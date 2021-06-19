using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace PetsLife_Adoptions.Api.Controllers
{
    [ApiController]
    [Route("api/AdoptanteMascota")]
    //[Authorize]
    public class AdoptanteMascotaController : ControllerBase
    {
        private readonly IAdoptanteMascotaService _service;
        public AdoptanteMascotaController(IAdoptanteMascotaService service)
        {
            this._service = service;
        }
        [HttpGet("/All")]
        public IActionResult GetAll()
        {
            try
            {
                return new JsonResult(_service.GetAdoptanteMascotas()) { StatusCode = 200 };
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("/PosiblesAdoptantes")]
        public IActionResult GetAllPosibles()
        {
            try
            {
                return new JsonResult(_service.GetPosiblesAdoptantes()) { StatusCode = 200 };
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("/AdopcionesFinalizadas")]
        public IActionResult GetAllFinalizadas()
        {
            try
            {
                return new JsonResult(_service.GetAdopcionesConfirmadas()) { StatusCode = 200 };
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}