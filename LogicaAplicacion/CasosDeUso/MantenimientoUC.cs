using Dominio;
using Dominio.Entidades;
using Dominio.Interfaces;
using Dominio.ValueObjects;
using DTOs;
using LogicaAplicacion.InterfacesUC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LogicaAplicacion.CasosDeUso
{
    public class MantenimientoUC : IMantenimientoUC
    {
        private IMantenimientoRepository _repositorio;
        public MantenimientoUC(IMantenimientoRepository repositorio)
        {
            _repositorio = repositorio;
        }

        public string Add(MantenimientoDto mantenimientoDto)
        {
            Mantenimiento m = new Mantenimiento();
            m.Fecha = mantenimientoDto.Fecha;
            m.Descripcion =   mantenimientoDto.Descripcion;
            m.Costo = mantenimientoDto.Costo;
            m.Trabajador = new Trabajador(mantenimientoDto.Trabajador);
            m.NombreCabaña = mantenimientoDto.NombreCabaña;

            _repositorio.Add(m);
            return "Mantenimiento Creado con exito para la cabaña: " + mantenimientoDto.NombreCabaña;
        }

        public IEnumerable<MantenimientoDto> GetAll()
        {
            return _repositorio.GetAll().Select(x => new MantenimientoDto(x));
        }

        public IEnumerable<MantenimientoDto> GetMantenimientosEntreFechas(DateTime f1, DateTime f2, string nombreCabaña)
        {
            IEnumerable<Mantenimiento> m = _repositorio.GetMantenimientosEntreFechas(f1, f2, nombreCabaña);
            if (m.Count() > 0)
            {
                return _repositorio.GetMantenimientosEntreFechas(f1, f2, nombreCabaña).Select(x => new MantenimientoDto(x));
            }
            else
            {
                throw new Exception("No existen mantenimientos entre esas fechas");
            }
        }

        public IEnumerable<MantenimientoDto> GetMantenimientosEntre(double valor1, double valor2)
        {
            IEnumerable<Mantenimiento> c = _repositorio.GetMantenimientosEntre(valor1, valor2);
            if (c.Count() > 0)
            {
                return _repositorio.GetMantenimientosEntre(valor1, valor2).Select(x => new MantenimientoDto(x));
            }
            else
            {
                throw new Exception("El tipo no existe");
            }
        }
    }
}
