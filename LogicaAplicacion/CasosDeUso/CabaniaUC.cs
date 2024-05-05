using Dominio;
using Dominio.Entidades;
using Dominio.Exceptions;
using Dominio.ValueObjects;
using DTOs;
using LogicaAplicacion.InterfacesUC;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LogicaAplicacion.CasosDeUso
{
    public class CabaniaUC : ICabañaUC
    {
        private ICabañaRepository _repositorio;

        public CabaniaUC(ICabañaRepository repositorio)
        {
            _repositorio = repositorio;
        }

        public CabaniaDto Add(CabaniaDto cabañaDto)
        {
            Cabania c = new Cabania();
            c.Nombre = cabañaDto.Nombre;
            c.Descripcion = new DescripcionCabaña(cabañaDto.Descripcion);
            c.JacuzziPrivado = new JacuzziPriv(cabañaDto.JacuzziPrivado);
            c.Capacidad = new Capacidad(cabañaDto.Capacidad);
            c.Habilitada = cabañaDto.Habilitada;
            c.NombreTipo = cabañaDto.NombreTipo;
            c.Foto = cabañaDto.Foto;

            _repositorio.Add(c);
            return new CabaniaDto(_repositorio.GetCabaña(cabañaDto.Nombre));
        }

        public IEnumerable<CabaniaDto> GetAll()
        {
            return _repositorio.GetAll().Select(x => new CabaniaDto(x));
        }

        public CabaniaDto GetCabaña(string nombre)
        {
            Cabania c = _repositorio.GetCabaña(nombre);
            if (c != null)
            {
                return new CabaniaDto(c);
            }
            else {
                throw new Exception("La cabaña no existe");
            }
        }

        public IEnumerable<CabaniaDto> GetCabañas(string nombre)
        {
            IEnumerable<Cabania> c = _repositorio.GetCabañas(nombre);
            if (c.Count() > 0)
            {
                return _repositorio.GetCabañas(nombre).Select(x => new CabaniaDto(x));
            }
            else
            {
                throw new Exception("No existen cabañas que contengan ese texto.");
            }
        }

        public IEnumerable<CabaniaDto> GetCabañasHabilitadas()
        {
            IEnumerable<Cabania> c = _repositorio.GetCabañasHabilitadas();
            if (c.Count() > 0)
            {
                return _repositorio.GetCabañasHabilitadas().Select(x => new CabaniaDto(x));
            } else
            {
                throw new Exception("No existen cabañas habilitadas");
            }
        }

        public IEnumerable<CabaniaDto> GetCabañasPorCapacidad(int capacidad)
        {
            IEnumerable<Cabania> c = _repositorio.GetCabañasPorCapacidad(capacidad);
            if (c.Count() > 0)
            {
                return _repositorio.GetCabañasPorCapacidad(capacidad).Select(x => new CabaniaDto(x));
            }
            else
            {
                throw new Exception("La cabaña no existe");
            }
        }

        public IEnumerable<CabaniaDto> GetCabañasPorTipo(string nombreTipo)
        {
            IEnumerable<Cabania> c = _repositorio.GetCabañasPorTipo(nombreTipo);
            if (c.Count() > 0)
            {
                return _repositorio.GetCabañasPorTipo(nombreTipo).Select(x => new CabaniaDto(x));
            }
            else {
                throw new Exception("El tipo no existe");
            }
        }

        public IEnumerable<CabaniaDto> GetCabañasPorMonto(string nombreTipo, int monto)
        {
            IEnumerable<Cabania> c = _repositorio.GetCabañasPorTipo(nombreTipo);
            if (c.Count() > 0)
            {
                return _repositorio.GetCabañasPorMonto(nombreTipo, monto).Select(x => new CabaniaDto(x));
            }
            else
            {
                throw new Exception("El tipo no existe");
            }
        }
    }
}
