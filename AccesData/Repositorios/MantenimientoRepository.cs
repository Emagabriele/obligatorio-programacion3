using Dominio;
using Dominio.Entidades;
using Dominio.Exceptions;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesData.SqlRepositorios
{
    public class MantenimientoRepository : IMantenimientoRepository
    {
        public HotelContext _context { get; set; } = new HotelContext();

        public void Add(Mantenimiento m)
        {
            try
            {
                m.Validar();
                _context.Mantenimientos.Add(m);
                _context.SaveChanges();
            }
            catch (MantenimientoException me)
            {
                throw me;
            }
        }

        public void Delete(Mantenimiento m)
        {
            try
            {
                if (_context.Mantenimientos.Any(mantenimiento => mantenimiento == m))
                {
                    _context.Mantenimientos.Remove(m);
                    _context.SaveChanges();
                }
                else
                {
                    throw new MantenimientoException("No existe ese mantenimiento");
                }
            }
            catch (MantenimientoException me)
            {
                throw me;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int Tiene3Mantenimientos(DateTime f, string nombreCabaña) {

            return _context.Mantenimientos.Count(mantenmiento => mantenmiento.Fecha == f && mantenmiento.NombreCabaña == nombreCabaña);
        }

        public IEnumerable<Mantenimiento> GetAll()
        {
            return _context.Mantenimientos;
        }

        public IEnumerable<Mantenimiento> GetMantenimientosEntreFechas(DateTime f1, DateTime f2, string nombreCabaña)
        {
            return _context.Mantenimientos.Where(mantenimiento => mantenimiento.Fecha >= f1 && mantenimiento.Fecha <= f2 && mantenimiento._unaCabaña.Nombre == nombreCabaña).OrderByDescending(mantenimiento => mantenimiento.Costo);
        }

        public IEnumerable<Mantenimiento> GetMantenimientosEntre(double valor1, double valor2) {
            return (IEnumerable<Mantenimiento>)_context.Mantenimientos.Where(mantenimiento => mantenimiento._unaCabaña.Capacidad.CapacidadCabaña >= valor1 && mantenimiento._unaCabaña.Capacidad.CapacidadCabaña <= valor2);
        }

        public void Modify(Mantenimiento t)
        {
            throw new NotImplementedException();
        }
    }
}
