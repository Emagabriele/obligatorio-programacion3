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
    public class Capacidad : IValidable
    {
        public int CapacidadCabaña { get; set; }
        public Capacidad(int capacidadCabaña)
        {
            CapacidadCabaña = capacidadCabaña;
        }

        public Capacidad() { }
        public void Validar()
        {
            if (CapacidadCabaña <= 0) throw new CabañaException("La cantidad maxima de personas debe ser mayor a 0");
        }
    }
}
