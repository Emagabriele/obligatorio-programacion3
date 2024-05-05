using Dominio;
using Dominio.Entidades;
using Dominio.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace AccesData.SqlRepositorios
{
    public class CabañaRepository : ICabañaRepository
    {

        public HotelContext _context { get; set; } = new HotelContext();

        public void Add(Cabania c)
        {
            try
            {
                c.Validar();
                _context.Cabañas.Add(c);
                _context.SaveChanges();
            }
            catch (CabañaException ce)
            {
                throw ce;
            }
            catch (Exception)
            {
                throw new CabañaException("Error: Clave repetida. No se puede repetir el nombre de la cabaña.");
            }
        }

        public void Delete(Cabania c)
        {
            try
            {
                if (_context.Cabañas.Any(cabaña => cabaña == c))
                {
                    _context.Cabañas.Remove(c);
                    _context.SaveChanges();
                }
                else
                {
                    throw new CabañaException("La cabaña no existe");
                }
            }
            catch (CabañaException ce)
            {
                throw ce;
            }
        }

        public IEnumerable<Cabania> GetAll()
        {
            return _context.Cabañas.Include("_unTipo");
        }
        public Cabania GetCabaña(string nombre)
        {
            return _context.Cabañas.Where(cabaña => cabaña.Nombre == nombre).FirstOrDefault();
            
        }

        public IEnumerable<Cabania> GetCabañas(string texto)
        {
            return _context.Cabañas.Where(cabaña => cabaña.Nombre.Contains(texto)).Include("_unTipo");
        }

        public IEnumerable<Cabania> GetCabañasPorTipo(string nombreTipo)
        {
            return _context.Cabañas.Where(cabaña => cabaña.NombreTipo == nombreTipo).Include("_unTipo");
            
        }

        public IEnumerable<Cabania> GetCabañasPorCapacidad(int capacidad)
        {
            return _context.Cabañas.Where(cabaña => cabaña.Capacidad.CapacidadCabaña >= capacidad).Include("_unTipo");
        }

        public IEnumerable<Cabania> GetCabañasHabilitadas()
        {
            return _context.Cabañas.Where(cabaña => cabaña.Habilitada == true).Include("_unTipo");
        }

        public IEnumerable<Cabania> GetCabañasPorMonto(string nombreTipo, int monto) {
            return _context.Cabañas.Where(cabaña => cabaña.NombreTipo == nombreTipo && cabaña.JacuzziPrivado.JacuzziPrivado == true && cabaña.Habilitada == true && (cabaña._unTipo.Costo_huesped * cabaña.Capacidad.CapacidadCabaña) < monto);
        }

        public void Modify(Cabania c)
        {
            throw new NotImplementedException();
        }
    }
}
