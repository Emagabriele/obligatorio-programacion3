using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfacesUC
{
    public interface IMantenimientoUC
    {
        public string Add(MantenimientoDto mantenimientoDto);
        public IEnumerable<MantenimientoDto> GetAll();
        public IEnumerable<MantenimientoDto> GetMantenimientosEntreFechas(DateTime f1, DateTime f2, string nombreCabaña);

        public IEnumerable<MantenimientoDto> GetMantenimientosEntre(double valor1, double valor2);
    }
}
