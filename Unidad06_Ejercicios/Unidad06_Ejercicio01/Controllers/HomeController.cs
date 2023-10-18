using Microsoft.AspNetCore.Mvc;

namespace Unidad06_Ejercicio01.Controllers
{
    public class HomeController : Controller
    {
        public String Index()
        {
            return "Juanma";
        }

        public String Apellidos()
        {
            return "Gallego Giron";
        }

        public ActionResult Saludo()
        {
            return View();
        }
    }
}