using Dominio;
using Dominio.Entidades;
using Dominio.Interfaces;
using DTOs;
using LogicaAplicacion.InterfacesUC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso
{
    public class TipoUC : ITipoUC
    {
        private ITipoRepository _repositorio;

        public TipoUC(ITipoRepository repositorio)
        {
            _repositorio = repositorio;
        }
        public TipoDto Add(TipoDto tipoDto)
        {
            Tipo t = new Tipo();
            t.Nombre = tipoDto.Nombre;
            t.Descripcion = tipoDto.Descripcion;
            t.Costo_huesped = tipoDto.Costo_huesped;
            

            _repositorio.Add(t);
            return new TipoDto(_repositorio.GetTipo(tipoDto.Nombre));
        }

        public void Delete(string nombreTipo)
        {
            Tipo tipo = new Tipo();
            tipo.Nombre = nombreTipo;
            _repositorio.Delete(tipo);
        }

        public TipoDto Edit(TipoDto tipoDto)
        {
            Tipo tipo = new Tipo();
            tipo.Nombre = tipoDto.Nombre;
            tipo.Descripcion = tipoDto.Descripcion;
            tipo.Costo_huesped = tipoDto.Costo_huesped;
            _repositorio.Modify(tipo);
            return new TipoDto(_repositorio.GetTipo(tipoDto.Nombre));
        }

        public IEnumerable<TipoDto> GetAll()
        {
            return _repositorio.GetAll().Select(x => new TipoDto(x));
        }

        public TipoDto GetTipo(string nombre)
        {
            Tipo t = _repositorio.GetTipo(nombre);
            if (t != null)
            {
                return new TipoDto(t);
            }
            else
            {
                throw new Exception("El Tipo no existe");
            }
        }
    }
}
