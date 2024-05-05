using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using LogicaAplicacion.InterfacesUC;
using DTOs;
using Dominio.Exceptions;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class CabaniaController : Controller
    {
        private ICabañaUC repositorio;

        public CabaniaController(ICabañaUC repositorio)
        {
            this.repositorio = repositorio;
        }

        [HttpGet("/GetCabañas")]
        public IActionResult GetCabañas()
        {
            return Ok(repositorio.GetAll());
        }

        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult CrearCabaña([FromBody] CabaniaDto c)
        {
            try
            {
                return Created(new Uri("http://localhost:5236/Cabania"), repositorio.Add(c));
            }
            catch (CabañaException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("/GetCabañaPorNombre")]
        public IActionResult GetCabañas(string nombre)
        {
            try
            {
                return Ok(repositorio.GetCabaña(nombre));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            } 
        }

        [HttpGet("/GetCabañasPorTipo")]
        public IActionResult GetCabañasPorTipo(string tipo)
        {
            try 
            {
                return Ok(repositorio.GetCabañasPorTipo(tipo));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
            
        }

        [HttpGet("/GetCabañasPorCapacidad")]
        public IActionResult GetCabañasPorCapacidad(int Capacidad)
        {
            try
            {
                return Ok(repositorio.GetCabañasPorCapacidad(Capacidad));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
            
        }

        [HttpGet("/GetCabañasHabilitadas")]
        public IActionResult GetCabañasHabilitadas()
        {
            try
            {
                return Ok(repositorio.GetCabañasHabilitadas());
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

        }

        [HttpGet("/GetCabañasContiene")]
        public IActionResult GetCabañasContiene(string texto)
        {
            try
            {
                return Ok(repositorio.GetCabañas(texto));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

        }

        [HttpGet("/GetCabañasPorMonto")]
        public IActionResult GetCabañasPorMonto(string nombreTipo, int monto)
        {
            try
            {
                return Ok(repositorio.GetCabañasPorMonto(nombreTipo, monto));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
