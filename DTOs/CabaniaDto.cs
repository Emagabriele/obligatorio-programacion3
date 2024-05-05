using Dominio.Entidades;
using Dominio.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class CabaniaDto
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool JacuzziPrivado { get; set; }
        public bool Habilitada { get; set; }
        public int Capacidad { get; set; }
        public string NombreTipo { get; set; }
        public string Foto { get; set; }

        public CabaniaDto() { }

        public CabaniaDto(Cabania cabaña)
        {
            this.Nombre = cabaña.Nombre;
            this.Descripcion = cabaña.Descripcion.Descripcion;
            this.JacuzziPrivado = cabaña.JacuzziPrivado.JacuzziPrivado;
            this.Habilitada = cabaña.Habilitada;
            this.Capacidad = cabaña.Capacidad.CapacidadCabaña;
            this.NombreTipo = cabaña.NombreTipo;
            this.Foto = cabaña.Foto;
        }
    }
}
