using Mandaloriano2.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string seleccion)
        {
            // Obtener la lista de misiones
            var misiones = ObtenerMisiones();
            ViewBag.Misiones = new SelectList(misiones, "Nombre", "Nombre");

            // Si se ha seleccionado una misión, mostrar sus detalles
            if (!string.IsNullOrEmpty(seleccion))
            {
                var mision = ObtenerMisiones().FirstOrDefault(x => x.Nombre == seleccion);
                return View(mision);
            }

            // Si no se ha seleccionado una misión, mostrar la página con la lista desplegable
            return View();
        }

        private List<Mision> ObtenerMisiones()
        {
            // Aquí deberías obtener las misiones desde tu base de datos o de donde sea necesario
            return new List<Mision>
        {
            new Mision { Nombre = "Rescate de Baby Yoda", Descripcion = "Debes hacerte con Grogu y llevarlo a Luke Skywalker para su entrenamiento.", Recompensa = "5000 créditos" },
            new Mision { Nombre = "Recuperar armadura Beskar", Descripcion = "Tu armadura de Beskar ha sido robada. Debes encontrarla.", Recompensa = "2000 créditos" },
            new Mision { Nombre = "Planeta Sorgon", Descripcion = "Debes llevar a un niño de vuelta a su planeta natal 'Sorgon'.", Recompensa = "500 créditos" },
            new Mision { Nombre = "Renacuajos", Descripcion = "Debes llevar a una Dama Rana y sus huevos de Tatooine a la luna del estuario Trask, donde su esposo fertilizará los huevos.", Recompensa = "500 créditos" }
        };
        }
    }
}