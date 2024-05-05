using Dominio.Exceptions;
using Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class Usuario : IValidable
    {
        [Key]
        public string Email { get; set; }

        [MinLength(6)]
        public string Contraseña { get; set; }

        public Usuario(string email, string contraseña)
        {
            Email = email;
            Contraseña = contraseña;
        }

        public Usuario()
        {
        }

        public void Validar()
        {
            if (!Contraseña.Any(ch => char.IsUpper(ch))) throw new UsuarioException("La contraseña no contiene mayusculas");

            if (!Contraseña.Any(ch => char.IsDigit(ch))) throw new UsuarioException("La contraseña no contiene numeros");

            if (!Contraseña.Any(ch => char.IsLower(ch))) throw new UsuarioException("La contraseña no contiene minusculas");

        }
    }
}
