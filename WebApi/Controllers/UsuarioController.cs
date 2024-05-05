using DTOs;
using LogicaAplicacion.InterfacesUC;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : Controller
    {
        private IConfiguration configuracion { get; set; }
        private ManejadorJwt ManejadorJwt { get; set; }
        public UsuarioController(IConfiguration configuration, IUsuarioUC obtenerUsuario)
        {
            this.ManejadorJwt = new ManejadorJwt(obtenerUsuario);
            this.configuracion = configuration;
        }

        /// <summary>
        /// Metodo para conseguir Token dado un usuario
        /// </summary>
        /// <param name="usuario">Credenciales de usuario que desea iniciar sesion</param>
        /// <returns>Token generado</returns>
        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public ActionResult<UsuarioDto> Login([FromBody] UsuarioDto usuarioActual)
        {
            try
            {
                var usuario = ManejadorJwt.ObtenerUsuario(usuarioActual);

                var token = ManejadorJwt.GenerarToken(usuario, configuracion);

                return Ok(new
                {
                    Token = token,
                    Usuario = usuario
                });
            }
            catch (Exception ex)
            {
                return Unauthorized(ex.Message);
            }
        }
    }
}
