using DTOs;
using LogicaAplicacion.InterfacesUC;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class TipoController : Controller
    {
        private ITipoUC repositorio;

        public TipoController(ITipoUC repositorio)
        {
            this.repositorio = repositorio;
        }

        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult CrearTipo([FromBody] TipoDto t)
        {
            try
            {
                return Created(new Uri("http://localhost:5236/Tipo"), repositorio.Add(t));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Actualización de equipo en la base de datos
        /// </summary>
        /// <param name="t">Equipo completo sin los integrantes.</param>
        /// <param name="nombreTipo">Id del equipo a actualizar.</param>
        /// <returns>Retorna el equipo recién creado</returns>
        [HttpPut("{nombreTipo}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult EditarTipo([FromBody] TipoDto t, string nombreTipo)
        {
            try
            {
                return Ok(repositorio.Edit(t));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{nombreTipo}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult BorrarEquipo(string nombreTipo)
        {
            try
            {
                repositorio.Delete(nombreTipo);
                return Ok("Equipo eliminado correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("/GetTipos")]
        public IActionResult GetTipos()
        {
            return Ok(repositorio.GetAll());
        }

        [HttpGet("/GetTipo")]
        public IActionResult GetTipo(string nombre)
        {
            try
            {
                return Ok(repositorio.GetTipo(nombre));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
