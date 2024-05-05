using Dominio.Entidades;
using Dominio.Exceptions;
using Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AccesData.SqlRepositorios
{
    public class TipoRepository : ITipoRepository
    {
        public HotelContext _context { get; set; } = new HotelContext();

        public void Add(Tipo t)
        {
            try
            {
                t.Validar();
                _context.Tipos.Add(t);
                _context.SaveChanges();
            }
            catch (TipoException te)
            {
                throw te;
            }
            catch (Exception)
            {
                throw new TipoException("Error: Clave repetida. No se puede repetir el nombre del tipo.");
            }
        }

        public bool TieneCabañas(Tipo t) {
            return _context.Cabañas.Any(c => c._unTipo == t);
        }

        public Tipo GetTipo(string nombre) {
            return _context.Tipos.Where(t => t.Nombre == nombre).FirstOrDefault();
        }

        public void Delete(Tipo t)
        {
            try
            {
                if (_context.Tipos.Any(tipo => tipo == t))
                {
                    if (!TieneCabañas(t))
                    {
                        _context.Tipos.Remove(t);
                        _context.SaveChanges();
                    }
                    else {
                        throw new TipoException("Este tipo esta en alguna cabaña");
                    }
                }
                else
                {
                    throw new TipoException("No existe ese tipo");
                }
            }
            catch (TipoException te)
            {
                throw te;
            }
        }

        public IEnumerable<Tipo> GetAll()
        {
            return _context.Tipos;
        }

        public void Modify(Tipo t)
        {
            try {
                t.Validar();
                _context.Tipos.Update(t);
                _context.SaveChanges();

            }catch(TipoException te)
            {
                throw te;
            }
        }

        public Tipo Search(string nombre)
        {
            return _context.Tipos.Where(tipos => tipos.Nombre == nombre).FirstOrDefault();
        }
    }
}
