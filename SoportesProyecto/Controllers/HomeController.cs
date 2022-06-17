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
       

        public async Task<IActionResult> Index()
        {
            var support = await repositorioSoportes.GetSupport();
            return View(support);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        
        public IActionResult FormRequerimiento()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> FormRequerimiento(RequerimientoSoporte requerimientoSoporte)
        {
            if (ModelState.IsValid)
            {
                await repositorioSoportes.RegistrarSoporte(requerimientoSoporte);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
            
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}