using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.ValueObjects;
using Microsoft.SqlServer.Server;
using Swashbuckle.AspNetCore.Annotations;

namespace DTOs
{
    public class MantenimientoDto
    {
        [DataType(DataType.Date)]
        [SwaggerSchema(Format = "date")]
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public double Costo { get; set; }
        public string Trabajador { get; set; }
        public string NombreCabaña { get; set; }

        public MantenimientoDto() { }

        public MantenimientoDto(Mantenimiento mantenimiento)
        {
            this.Fecha = mantenimiento.Fecha;
            this.Descripcion = mantenimiento.Descripcion;
            this.Costo = mantenimiento.Costo;
            this.Trabajador = mantenimiento.Trabajador.Nombre;
            this.NombreCabaña = mantenimiento.NombreCabaña;
        }

        
    }
}
