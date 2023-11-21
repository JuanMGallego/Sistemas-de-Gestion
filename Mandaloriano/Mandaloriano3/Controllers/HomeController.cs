using Mandaloriano3.DAL;
using Mandaloriano3.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Mandaloriano3.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Misiones = new SelectList(MisionDAL.ObtenerMisiones(), "Nombre", "Nombre");
            return View();
        }

        [HttpPost]
        public ActionResult VerDetalles(string selectedMision)
        {
            // Aquí podrías implementar lógica para obtener detalles de la misión seleccionada.
            Mision misionSeleccionada = MisionDAL.ObtenerMisiones().FirstOrDefault(m => m.Nombre == selectedMision);
            ViewBag.MisionSeleccionada = misionSeleccionada;
            ViewBag.Misiones = new SelectList(MisionDAL.ObtenerMisiones(), "Nombre", "Nombre", selectedMision);
            return View("Index");
        }
    }
}