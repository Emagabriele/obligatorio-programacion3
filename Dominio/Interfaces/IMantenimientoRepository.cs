using Dominio.Entidades;
using Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public interface IMantenimientoRepository : IRepositorio<Mantenimiento>
    {
        public IEnumerable<Mantenimiento> GetMantenimientosEntreFechas(DateTime f1, DateTime f2, string nombreCabaña);
        public int Tiene3Mantenimientos(DateTime f, string nombreCabaña);

        public IEnumerable<Mantenimiento> GetMantenimientosEntre(double valor1, double valor2);
    }
}
