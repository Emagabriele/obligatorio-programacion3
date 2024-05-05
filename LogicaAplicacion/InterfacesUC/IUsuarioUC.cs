using Dominio.Entidades;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfacesUC
{
    public interface IUsuarioUC
    {
        public UsuarioDto ObtenerUsuario(UsuarioDto usuario);
    }
}
