using EjsU7_SG.Models.Entidades;
using EjsU7_SG.Models.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EjsU7_SG.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// ActionResult para la vista Index. Creamos una variable que recoge la hora actual del día y
        /// programamos un sistema para enviar un saludo en función de la hora del día.
        /// La vista recibe el mensaje mediante un ViewData, recibe la fecha en versión larga mediante un ViewBag 
        /// y un objeto persona mediante el modelo
        /// </summary>
        /// <returns>Devuelve la vista Index</returns>
        public ActionResult Index()
        {

            var fechaActual = DateTime.Now;
            var message = "Buenos días";

            if (fechaActual.Hour >= 14)
            {
                message = "Buenas tardes";
            } else if (fechaActual.Hour >= 21)
            {
                message = "Buenas noches";
            }

            ViewData["Message"] = message;
            ViewBag.fechaLarga = fechaActual.ToLongDateString();
            return View(persona);
        }

        /// <summary>
        /// ActionResult en el que se ha generado una lista de objetos clsPersona
        /// La vista recibe la lista mediante una ViewBag
        /// Post: La lista no puede estar vacía 
        /// </summary>
        /// <returns>Devuelve la vista listadoPersonas</returns>
        public IActionResult listadoPersonas()
        {
            return View(clsListadoPersonas.listadoPersonas());
        }

        /// <summary>
        /// Creamos un objeto persona porque podemos 
        /// </summary>
        private clsPersona persona = new clsPersona()
        {
            Id = 1,
            Nombre = "Francisco",
            Apellidos = "Rodríguez",
            Direccion = "Mi calle",
            FechaNac = new DateTime(2003, 04, 27),
            Tlfn = 654444089,
        };
    }

}