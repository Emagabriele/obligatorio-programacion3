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
    public class Tipo : IValidable
    {
        [Key]
        public string Nombre { get; set; }
        
        public string Descripcion { get; set; }
        public double Costo_huesped { get; set; }

        public Tipo(string nombre, string descripcion, double costo_huesped)
        {
            Nombre = nombre;
            Descripcion = descripcion;
            this.Costo_huesped = costo_huesped;
        }
        public Tipo() { 
        }

        public void Validar()
        {
            if (Nombre.Substring(0) == " " && Nombre.Substring(Nombre.Length - 1) == " ") throw new TipoException("El Nombre no debe contener espacios ni en el comienzo, ni en el final");
            if (Descripcion.Length < 10) throw new TipoException("La descripcion debe ser mayor a 10");
            if (Descripcion.Length > 200) throw new TipoException("La descripcion debe ser menor a 200");
            if (Costo_huesped <= 0) throw new TipoException("El Costo debe ser mayor a 0");
        }
    }
}
