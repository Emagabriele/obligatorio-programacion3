using Dominio.Exceptions;
using Dominio.Interfaces;
using Dominio.ValueObjects;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Entidades
{
    public class Cabania : IValidable
    {
        [Key]
        public string Nombre { get; set; }
        public DescripcionCabaña Descripcion { get; set; }
        public JacuzziPriv JacuzziPrivado { get; set; }
        public bool Habilitada { get; set; }

        [Index(nameof(NumHabitacion), IsUnique = true)]

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NumHabitacion { get; set; }
        public Capacidad Capacidad { get; set; }
        [ForeignKey(nameof(_unTipo))] public string NombreTipo { get; set; }
        public Tipo _unTipo { get; set; }
        public string Foto { get; set; }

        public Cabania()
        {
        }

        public Cabania(Tipo unTipo, string nombre, DescripcionCabaña descripcion,JacuzziPriv jacuzziPriv, bool habilitada, Capacidad capacidad, string foto)
        {
            _unTipo = unTipo;
            Nombre = nombre;
            Descripcion = descripcion;
            JacuzziPrivado = jacuzziPriv;
            Habilitada = habilitada;
            Capacidad = capacidad;
            Foto = foto;
        }

        public void Validar()
        {
            if (Nombre.Substring(0) == " " && Nombre.Substring(Nombre.Length - 1) == " ") throw new CabañaException("El Nombre no debe contener espacios ni en el comienzo, ni en el final");
            Capacidad.Validar();
            Descripcion.Validar();
        }
    }
}