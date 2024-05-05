using Dominio.Entidades;
using Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public interface ICabañaRepository : IRepositorio<Cabania>
    {
        public Cabania GetCabaña(string nombre);
        public IEnumerable<Cabania> GetCabañas(string nombre);
        public IEnumerable<Cabania> GetCabañasPorTipo(string nombreTipo);
        public IEnumerable<Cabania> GetCabañasPorCapacidad(int capacidad);
        public IEnumerable<Cabania> GetCabañasHabilitadas();

        public IEnumerable<Cabania> GetCabañasPorMonto(string nombreTipo, int monto);
    }
}
