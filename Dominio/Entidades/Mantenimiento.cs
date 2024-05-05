using Dominio.Exceptions;
using Dominio.Interfaces;
using Dominio.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class Mantenimiento : IValidable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public double Costo { get; set; }
        [Required]
        public Trabajador Trabajador { get; set; }
        [ForeignKey(nameof(_unaCabaña))] public string NombreCabaña { get; set; }
        public Cabania _unaCabaña { get; set; }

        public Mantenimiento(DateTime fecha, string descripcion, double costo,Trabajador trabajador, Cabania unaCabaña)
        {
            Fecha = fecha;
            Descripcion = descripcion;
            Costo = costo;
            Trabajador = trabajador;
            _unaCabaña = unaCabaña;
        }

        public Mantenimiento()
        {
        }

        public void Validar()
        {
            if (Fecha > DateTime.Now) throw new MantenimientoException("La fecha debe ser menor");

            if (Descripcion.Length < 10) throw new MantenimientoException("La descripcion debe ser mayor a 10");

            if (Descripcion.Length > 200) throw new MantenimientoException("La descripcion debe ser menor a 200");

            if (Costo <= 0) throw new MantenimientoException(" El costo debe ser mayor a 0");

            Trabajador.Validar();
        }
    }
}
