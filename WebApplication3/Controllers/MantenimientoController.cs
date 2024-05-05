using AccesData.SqlRepositorios;
using Dominio;
using Dominio.Entidades;
using Dominio.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebApplication2.Controllers
{
    public class MantenimientoController : Controller
    {
        private IMantenimientoRepository repositorio = new MantenimientoRepository();
        private ICabañaRepository repositorioCabaña = new CabañaRepository();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create(string nombreCabaña)
        {
            string email = HttpContext.Session.GetString("LogueadoEmail");
            if (email != null)
            {
                ViewBag.cabaña = repositorioCabaña.GetCabaña(nombreCabaña);
                return View();
            }
            return RedirectToAction("AccesoDenegado", "Home");
        }

        [HttpPost]
        public ActionResult Create(Mantenimiento m)
        {
            string email = HttpContext.Session.GetString("LogueadoEmail");
            if (email != null)
            {
                try
                {
                    int num = repositorio.Tiene3Mantenimientos(m.Fecha, m.NombreCabaña);
                    if (num <= 3)
                    {
                        repositorio.Add(m);
                        ViewBag.msg = "Registro Exitoso";
                        return RedirectToAction("SearchAll", "Cabaña");
                    }
                    else
                    {
                        throw new MantenimientoException("Tiene 3 mantenimiento realizados en el dia");
                    }
                }
                catch (MantenimientoException me)
                {
                    ViewBag.msg = me.Message;
                    return View();
                }
            }
            return RedirectToAction("AccesoDenegado", "Home");

        }

        public ActionResult SearchEntreFechas(string nombreCabaña)
        {
            string email = HttpContext.Session.GetString("LogueadoEmail");
            if (email != null)
            {
                ViewBag.nombreCabaña = nombreCabaña;
                return View();
            }
            return RedirectToAction("AccesoDenegado", "Home");
        }

        public ActionResult GetAllEntreFechas(DateTime f1, DateTime f2, string nombreCabaña)
        {
            string email = HttpContext.Session.GetString("LogueadoEmail");
            if (email != null)
            {
                IEnumerable<Mantenimiento> mantenimientos = repositorio.GetMantenimientosEntreFechas(f1, f2, nombreCabaña);

                if (mantenimientos.Count() != 0)
                {
                    return View(mantenimientos);
                }

                ViewBag.msg = "La cabaña seleccionada no tiene mantenimientos";
                return View();
            }
            return RedirectToAction("AccesoDenegado", "Home");
        }
    }
}
