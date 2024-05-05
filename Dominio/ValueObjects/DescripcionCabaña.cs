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
    public class DescripcionCabaña : IValidable
    {
        public string Descripcion { get; set; }

        public DescripcionCabaña(string descripcion)
        {
            Descripcion = descripcion;
        }

        public DescripcionCabaña()
        {
        }

        public void Validar()
        {
            if (Descripcion.Length < 10) throw new CabañaException("La descripcion debe ser mayor a 10");
            if (Descripcion.Length > 500) throw new CabañaException("La descripcion debe ser menor a 200");
        }
    }
}
