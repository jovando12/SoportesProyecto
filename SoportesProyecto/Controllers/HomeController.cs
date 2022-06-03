using Microsoft.AspNetCore.Mvc;
using SoportesProyecto.Models;
using System.Diagnostics;
using SoportesProyecto.Services;

namespace SoportesProyecto.Controllers
{
    public class HomeController : Controller
    {

        private readonly IRepositorioSoportes repositorioSoportes;
        
        public HomeController(IRepositorioSoportes repositorioSoportes)
        {
            this.repositorioSoportes = repositorioSoportes;
        }
       

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [HttpGet]
        public IActionResult FormRequerimiento()
        {
            return View();
        }
        [HttpPost]
        public IActionResult FormRequerimiento(RequerimientoSoporte requerimientoSoporte)
        {
            repositorioSoportes.RegistrarSoporte(requerimientoSoporte);
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}