using Microsoft.AspNetCore.Mvc;

namespace Unidad06_Ejercicio01.Controllers
{
    public class ProductosController : Controller
    {
        public IActionResult ListadoProductos()
        {
            return View();
        }
    }
}
