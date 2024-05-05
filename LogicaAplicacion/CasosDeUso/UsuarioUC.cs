using Dominio.Entidades;
using Dominio.Interfaces;
using DTOs;
using LogicaAplicacion.InterfacesUC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso
{
    public class UsuarioUC : IUsuarioUC
    {
        private IUsuarioRepository repositorioUsuarios;
        public UsuarioUC(IUsuarioRepository repositorioUsuarios)
        {
            this.repositorioUsuarios = repositorioUsuarios;
        }

        public UsuarioDto ObtenerUsuario(UsuarioDto usuario)
        {
            UsuarioDto retorno = new UsuarioDto();
            Usuario u = repositorioUsuarios.GetUsuarioByEmail(usuario.Email);
            if (u == null || usuario.Contraseña != u.Contraseña) throw new Exception("Datos Incorrectos");
            retorno.Email = u.Email;
            retorno.Contraseña = u.Contraseña;
            return retorno;
        }
    }
}
