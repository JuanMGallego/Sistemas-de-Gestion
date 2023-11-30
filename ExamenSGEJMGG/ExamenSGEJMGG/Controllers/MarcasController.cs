using ExamenSGEJMGG.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ExamenSGEJMGG.Controllers
{
    public class MarcasController : Controller
    {
        private readonly ILogger<MarcasController> _logger;

        public MarcasController(ILogger<MarcasController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult EditarPrecio(int id)
        {
            return View(EditarPrecio(id));
        }

    }
}