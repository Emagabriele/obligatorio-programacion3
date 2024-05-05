using AccesData.SqlRepositorios;
using Dominio.Entidades;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    public class UsuarioController : Controller
    {
        private IUsuarioRepository repositorio = new UsuarioRepositorio();
        // GET: HomeController1
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Create(Usuario u)
        {
            try
            {
                repositorio.Add(u);
                return RedirectToAction("Login", "Home");
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
