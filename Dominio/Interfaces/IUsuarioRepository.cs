using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interfaces
{
    public interface IUsuarioRepository : IRepositorio<Usuario>
    {
        public Usuario Login(string email, string pass);
        public Usuario GetUsuarioByEmail(string email);
    }
}
