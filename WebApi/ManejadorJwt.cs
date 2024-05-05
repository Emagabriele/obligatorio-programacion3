using DTOs;
using LogicaAplicacion.InterfacesUC;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Security.Claims;

namespace WebApi
{
    public class ManejadorJwt
    {
        private static IUsuarioUC _obtenerUsuario { get; set; }
        public ManejadorJwt(IUsuarioUC obtenerUsuario) { 
            _obtenerUsuario = obtenerUsuario;
        }
        public static UsuarioDto ObtenerUsuario(UsuarioDto email)
        {
            UsuarioDto retorno = _obtenerUsuario.ObtenerUsuario(email);

            return retorno;
        }

        public static string GenerarToken(UsuarioDto usuario, IConfiguration configuracion)
        {
            List<Claim> claims = new List<Claim>() {
                new Claim(ClaimTypes.Email, usuario.Email)
            };

            var claveSecreta = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(configuracion.GetSection("AppSettings:SecretTokenKey").Value!));

            var credenciales = new SigningCredentials(claveSecreta, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(claims: claims, expires: DateTime.Now.AddDays(1), signingCredentials: credenciales);

            var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);

            return jwtToken;
        }
    }
}
