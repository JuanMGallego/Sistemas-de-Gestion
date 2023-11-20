using Mandaloriano.DAL;
using Mandaloriano.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Mandaloriano.Controllers
{
    public class MisionController : Controller
    {
        private MisionDAL misionDAL;

        public MisionController()
        {
            misionDAL = new MisionDAL();
        }

        public ActionResult Index()
        {
            List<MisionDAL> misiones = misionDAL.ObtenerMisiones();
            ViewBag.Misiones = new SelectList(misiones, "Id", "Nombre");
            return View();
        }

        [HttpPost]
        public ActionResult VerDetalles(int id)
        {
            Mision misión = misionDAL.ObtenerDetallesMision(id);
            ViewBag.DetallesMision = misión;
            return View("Detalles");
        }
    }
}
