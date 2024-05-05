using AccesData.SqlRepositorios;
using Dominio;
using Dominio.Entidades;
using Dominio.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication2.Controllers
{
    public class CabañaController : Controller
    {
        private ICabañaRepository repositorio = new CabañaRepository();
        private ITipoRepository repositorioTipo = new TipoRepository();
        private IWebHostEnvironment _environment;

        public CabañaController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            string email = HttpContext.Session.GetString("LogueadoEmail");
            if (email != null)
            {
                IEnumerable<Tipo> tipos = repositorioTipo.GetAll();
                ViewBag.Tipos = tipos;
                return View();
            }
            return RedirectToAction("AccesoDenegado", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cabania c, IFormFile imagen)
        {
            string email = HttpContext.Session.GetString("LogueadoEmail");
            if (email != null )
            {
                
                try
                {
                    if (c.NombreTipo != "s")
                    {
                        c.Validar();
                        GuardarImagen(imagen, c);
                        repositorio.Add(c);
                        ViewBag.msg = "Alta Exitosa";
                        return RedirectToAction("SearchAll", "Cabaña");
                    }
                    else
                    {
                        throw new CabañaException("Seleccione un tipo.");
                    }
                        
                }
                catch (CabañaException ce)
                {
                    ViewBag.msg = ce.Message;
                    return View();
                }
            }
            return RedirectToAction("AccesoDenegado", "Home");
        }

        private void GuardarImagen(IFormFile imagen, Cabania c)
        {
            if (imagen == null || c == null) throw new CabañaException("Datos incorrectos");
            string rutaFisicaWwwRoot = _environment.WebRootPath;

            string formato = imagen.FileName.Split(".").Last();

            if (formato != "jpg" && formato != "png" && formato != "jpeg") throw new CabañaException("La imagen debe ser un archivo .png | .jpg | .jpeg");

            string nombreImagen = c.Nombre.Replace(" ", "_") + "_001." + formato;

            string rutaFisicaAvatar = Path.Combine(rutaFisicaWwwRoot, "Imagenes", "Fotos", nombreImagen);

            try
            {
                //el método using libera los recursos del objeto FileStream al finalizar
                using (FileStream f = new FileStream(rutaFisicaAvatar, FileMode.Create))
                {
                    //Para archivos grandes o varios archivos usar la versión
                    //asincrónica de CopyTo. Sería: await imagen.CopyToAsync (f);
                    imagen.CopyTo(f);
                }

                //GUARDAR EL NOMBRE DE LA IMAGEN SUBIDA EN EL OBJETO
                c.Foto = nombreImagen;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult Search()
        {
            string email = HttpContext.Session.GetString("LogueadoEmail");
            if (email != null)
            {
                return View();
            }
            return RedirectToAction("AccesoDenegado", "Home");
        }

        public ActionResult SearchPorNombre(string nombre)
        {
            string email = HttpContext.Session.GetString("LogueadoEmail");
            if (email != null)
            {
                if (repositorio.GetCabañas(nombre) != null)
                {
                    return View(repositorio.GetCabañas(nombre));
                }

                ViewBag.msg = "No se encontraron cabañas.";
                return View();
            }
            return RedirectToAction("AccesoDenegado", "Home");
        }

        public ActionResult SearchPorTipo(string nombreTipo)
        {
            string email = HttpContext.Session.GetString("LogueadoEmail");
            if (email != null)
            {
                if (repositorio.GetCabañasPorTipo(nombreTipo) != null)
                {
                    return View(repositorio.GetCabañasPorTipo(nombreTipo));
                }

                ViewBag.msg = "No se encontraron cabañas.";
                return View();
            }
            return RedirectToAction("AccesoDenegado", "Home");
        }
        public ActionResult SearchPorCapacidad(int capacidad)
        {
            string email = HttpContext.Session.GetString("LogueadoEmail");
            if (email != null)
            {
                if (repositorio.GetCabañasPorCapacidad(capacidad) != null)
                {
                    return View(repositorio.GetCabañasPorCapacidad(capacidad));
                }

                ViewBag.msg = "No se encontraron cabañas.";
                return View();
            }
            return RedirectToAction("AccesoDenegado", "Home");
        }
        public ActionResult SearchHabilitadas()
        {
            string email = HttpContext.Session.GetString("LogueadoEmail");
            if (email != null)
            {
                if (repositorio.GetCabañasHabilitadas() != null)
                {
                    return View(repositorio.GetCabañasHabilitadas());
                }

                ViewBag.msg = "No se encontraron cabañas.";
                return View();
            }
            return RedirectToAction("AccesoDenegado", "Home");
        }

        public ActionResult SearchAll()
        {
            string email = HttpContext.Session.GetString("LogueadoEmail");
            if (email != null)
            {
                if (repositorio.GetAll() != null)
                {
                    IEnumerable<Cabania> cabañas = repositorio.GetAll();
                    return View(cabañas);
                }

                ViewBag.msg = "No se encontraron cabañas.";
                return View();
            }
            return RedirectToAction("AccesoDenegado", "Home");
        }
    }
}
