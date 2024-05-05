using Dominio.Exceptions;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.ValueObjects
{
    [Owned]
    public class Trabajador : IValidable
    {
        public string Nombre { get; set; }

        public Trabajador() { }

        public Trabajador(string nombre)
        {
            Nombre = nombre;
        }

        public void Validar()
        {
            if (Nombre.Equals("")) throw new MantenimientoException("El nombre del trabajador no debe ser vacio");
        }
    }
}
