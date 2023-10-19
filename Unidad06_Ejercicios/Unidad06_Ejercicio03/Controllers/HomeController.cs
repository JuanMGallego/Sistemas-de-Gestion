using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Unidad06_Ejercicio03.Models;

namespace Unidad06_Ejercicio03.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }
    }
}