using Dominio.Interfaces;
using DTOs;
using LogicaAplicacion.InterfacesUC;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class MantenimientoController : Controller
    {
        private IMantenimientoUC repositorio;

        public MantenimientoController(IMantenimientoUC repositorio)
        {
            this.repositorio = repositorio;
        }

        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult CrearMantenimiento([FromBody] MantenimientoDto m)
        {
            try
            {
                return Created(new Uri("http://localhost:5236/Mantenimiento"), repositorio.Add(m));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("/GetMantenimientos")]
        public IActionResult GetMantenimientos()
        {
            return Ok(repositorio.GetAll());
        }

        [HttpGet("/GetMantenimientosEntreFechas")]
        public IActionResult GetMantenimientos(DateTime f1, DateTime f2, string nombre)
        {
            try
            {
                return Ok(repositorio.GetMantenimientosEntreFechas(f1, f2, nombre));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpGet("/GetMantenimientosEntre")]
        public IActionResult GetMantenimientosEntre(double valor1, double valor2) {
            try
            {
                return Ok(repositorio.GetMantenimientosEntre(valor1, valor2));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
