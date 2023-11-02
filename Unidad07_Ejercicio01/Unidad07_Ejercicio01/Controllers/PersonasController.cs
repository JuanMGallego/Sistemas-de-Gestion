using Microsoft.AspNetCore.Mvc;

namespace Unidad07_Ejercicio01.Controllers
{
    public class PersonasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
