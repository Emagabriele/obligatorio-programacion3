using AccesData.SqlRepositorios;
using Dominio.Entidades;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication3.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private IUsuarioRepository repositorio = new UsuarioRepositorio();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string pass)
        {
            Usuario u = repositorio.Login(email, pass);

            if (u != null)
            {
                HttpContext.Session.SetString("LogueadoEmail", u.Email);
                return RedirectToAction("Index", "Usuario");
            }
            else {
                ViewBag.msg = "Compruebe los datos ingresados.";
                return View();
            }
        }

        public IActionResult Logout()
        {
            string email = HttpContext.Session.GetString("LogueadoEmail");
            if (email != null)
            {
                HttpContext.Session.Clear();
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("AccesoDenegado", "Home");
        }

        public ActionResult AccesoDenegado() {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}