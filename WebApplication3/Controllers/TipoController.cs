using AccesData.SqlRepositorios;
using Dominio;
using Dominio.Entidades;
using Dominio.Exceptions;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Controllers
{
    public class TipoController : Controller
    {
        private ITipoRepository repositorio = new TipoRepository();

        public ActionResult Create()
        {
            string email = HttpContext.Session.GetString("LogueadoEmail");
            if (email != null)
            {
                return View();
            }
            return RedirectToAction("AccesoDenegado", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Tipo t)
        {
            string email = HttpContext.Session.GetString("LogueadoEmail");
            if (email != null)
            {
                try
                {
                    repositorio.Add(t);
                    return RedirectToAction("GetAll", "Tipo");
                }
                catch (TipoException te)
                {
                    ViewBag.Error = te.Message;
                    return View();
                }
            }
            return RedirectToAction("AccesoDenegado", "Home");
            
        }
        public ActionResult GetAll()
        {
            string email = HttpContext.Session.GetString("LogueadoEmail");
            if (email != null)
            {
                if (repositorio.GetAll().Count() != 0)
                {
                    return View(repositorio.GetAll());
                }

                ViewBag.msg = "La lista esta vacia";
                return View();
            }
            return RedirectToAction("AccesoDenegado", "Home");
        }

        public IActionResult SearchByName()
        {
            string email = HttpContext.Session.GetString("LogueadoEmail");
            if (email != null)
            {
                return View();
            }
            return RedirectToAction("AccesoDenegado", "Home");
        }

        public ActionResult Search(string nombre)
        {
            string email = HttpContext.Session.GetString("LogueadoEmail");
            if (email != null)
            {
                if (repositorio.Search(nombre) != null) { 
                return View(repositorio.Search(nombre));
            }

                ViewBag.msg = "No se encontro el tipo.";
                return View();
            }
            return RedirectToAction("AccesoDenegado", "Home");
        }

        public ActionResult Edit(string nombre)
        {
            string email = HttpContext.Session.GetString("LogueadoEmail");
            if (email != null)
            {
                ViewBag.nombre = nombre;
                return View();
            }
            return RedirectToAction("AccesoDenegado", "Home");
        }

        [HttpPost]
        public ActionResult Edit(Tipo t)
        {
            string email = HttpContext.Session.GetString("LogueadoEmail");
            if (email != null)
            {
                try
                {
                    repositorio.Modify(t);
                    ViewBag.msg = "El cambio fue exitoso";
                    return View();
                }
                catch (TipoException te)
                {
                    ViewBag.msg = te.Message;
                    return View();
                }
            }
            return RedirectToAction("AccesoDenegado", "Home");

        }

        public ActionResult Delete(string nombre)
        {
            string email = HttpContext.Session.GetString("LogueadoEmail");
            if (email != null)
            {
                return View(repositorio.GetTipo(nombre));
            }
            return RedirectToAction("AccesoDenegado", "Home");
        }

        [HttpPost]
        public ActionResult Delete(Tipo t)
        {
            string email = HttpContext.Session.GetString("LogueadoEmail");
            if (email != null)
            {
                try
                {
                    if (!repositorio.TieneCabañas(t))
                    {
                        repositorio.Delete(t);
                        return RedirectToAction("GetAll", "Tipo");
                    }
                    else {
                        throw new TipoException("El tipo esta asociado a cabañas");
                    }
                }
                catch (TipoException te) {
                    ViewBag.msg = te.Message;
                    return View();
                }
            }
            return RedirectToAction("AccesoDenegado", "Home");
        }
    }
}
