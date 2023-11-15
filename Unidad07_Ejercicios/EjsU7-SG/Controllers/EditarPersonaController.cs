using Microsoft.AspNetCore.Mvc;
using EjsU7_SG.Models.ViewModel;

namespace EjsU7_SG.Controllers
{
    public class EditarPersonaController : Controller
    {
        /// <summary>
        /// Action result para la vista EditarPersona
        /// A la vista se le envía una ViewModel clsPersonaDepartamento, que contiene una lista de personas con departamentos
        /// y otra de departamentos
        /// Post: Siempre devuelve algo
        /// </summary>
        /// <returns>Devuelve la vista EditarPersona</returns>
        public IActionResult EditarPersona()
        {
            return View(new clsPersonaDepartamento());
        }
    }
}
