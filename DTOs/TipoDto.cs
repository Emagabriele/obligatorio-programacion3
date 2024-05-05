using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class TipoDto
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public double Costo_huesped { get; set; }


        public TipoDto() { }

        public TipoDto(Tipo tipo)
        {
            this.Nombre = tipo.Nombre;
            this.Descripcion = tipo.Descripcion;
            this.Costo_huesped = tipo.Costo_huesped;
        }
    }
}
