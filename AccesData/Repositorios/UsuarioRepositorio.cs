using Dominio.Entidades;
using Dominio.Exceptions;
using Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesData.SqlRepositorios
{
    public class UsuarioRepositorio : IUsuarioRepository
    {
        public HotelContext _context { get; set; } = new HotelContext();

        public void Add(Usuario u)
        {
            try
            {
                if (!_context.Usuarios.Any(usuario => usuario.Email == u.Email))
                {
                    u.Validar();
                    _context.Usuarios.Add(u);
                    _context.SaveChanges();
                }
                else {
                    throw new UsuarioException("El mail ya existe");
                }
            }
            catch (UsuarioException ue)
            {
                throw ue;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public void Delete(Usuario u)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Usuario> GetAll()
        {
            return _context.Usuarios;
        }

        public Usuario Login(string email, string pass)
        {
            return _context.Usuarios.Where(usuario => usuario.Email == email && usuario.Contraseña == pass).FirstOrDefault();
        }

        public Usuario GetUsuarioByEmail(string email)
        {
            return _context.Usuarios.Where(usuario => usuario.Email == email).FirstOrDefault();
        }

        public void Modify(Usuario u)
        {
            throw new NotImplementedException();
        }
    }
}
