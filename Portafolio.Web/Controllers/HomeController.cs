using Microsoft.AspNetCore.Mvc;
using Portafolio.Web.Models;
using Portafolio.Web.Servicios;
using System.Diagnostics;

namespace Portafolio.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepositorioProyectos repositorioProyectos;
        private readonly IServicioEmial servicioEmial;

        public HomeController(IRepositorioProyectos repositorioProyectos, IServicioEmial servicioEmial)
        {
            this.repositorioProyectos = repositorioProyectos;
            this.servicioEmial = servicioEmial;
        }

        public IActionResult Index()
        {
            var proyectos = repositorioProyectos.ObtenerProyectos().Take(3).ToList();
            var modelo = new HomeIndexViewModel() { Proyectos = proyectos };
            return View(modelo);
        }
     
        public IActionResult Proyectos()
        {
            var proyectos = repositorioProyectos.ObtenerProyectos();
            return View(proyectos); 
        }

        public IActionResult Contacto()
        {      
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Contacto(ContactoViewModel contactoViewModel)
        {
            await servicioEmial.Enviar(contactoViewModel);
            return RedirectToAction("Gracias");
        }

        public IActionResult Gracias()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}