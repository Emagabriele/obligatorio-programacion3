using Dominio.Entidades;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfacesUC
{
    public interface ICabañaUC
    {
        public CabaniaDto Add(CabaniaDto cabañaDto);
        public IEnumerable<CabaniaDto> GetAll();
        public CabaniaDto GetCabaña(string nombre);
        public IEnumerable<CabaniaDto> GetCabañas(string nombre);
        public IEnumerable<CabaniaDto> GetCabañasPorTipo(string nombreTipo);
        public IEnumerable<CabaniaDto> GetCabañasPorCapacidad(int capacidad);
        public IEnumerable<CabaniaDto> GetCabañasHabilitadas();

        public IEnumerable<CabaniaDto> GetCabañasPorMonto(string nombreTipo, int monto);
    }
}
