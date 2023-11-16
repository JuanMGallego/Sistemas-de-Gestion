using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Unidad08_Ejercicios.Models;
using Unidad08_Ejercicios.Models.Entities;

namespace Unidad08_Ejercicios.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Editar()
        {
            // Supongamos que tienes una instancia de clsPersona con tus datos
            clsPersona persona = new clsPersona
            {
                IdPersona = 1,
                Nombre = "TuNombre",
                Apellidos = "TusApellidos"
                // Agrega otros datos según sea necesario
            };

            return View(persona);
        }

        // Acción para procesar el formulario y mostrar la vista PersonaModificada
        [HttpPost]
        public ActionResult PersonaModificada(clsPersona personaModificada)
        {
            // Aquí puedes realizar las operaciones necesarias para guardar los cambios en la base de datos, por ejemplo.
            // En este ejemplo, simplemente mostraremos la vista PersonaModificada con los datos modificados.
            return View(personaModificada);
        }
    }
}