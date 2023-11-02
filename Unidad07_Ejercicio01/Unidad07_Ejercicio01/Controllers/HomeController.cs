using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Runtime.ConstrainedExecution;
using Unidad07_Ejercicio01.Models;
using Unidad07_Ejercicio01.Models.DAL;
using static Unidad07_Ejercicio01.Models.Entidades.HomeController;

namespace Unidad07_Ejercicio01.Controllers
{
    public IActionResult Index()
    {
        Persona per = new Persona(); // Declarar la instancia de Persona aquí
        DateTime fechayhoraActual = DateTime.Now;

        ViewBag.HoraActual = fechayhoraActual.ToLongTimeString();

        if (fechayhoraActual.Hour >= 7 && fechayhoraActual.Hour < 12)
        {
            ViewData["Saludo"] = "Buenos días";
        }
        else if (fechayhoraActual.Hour >= 12 && fechayhoraActual.Hour < 19)
        {
            ViewData["Saludo"] = "Buenas tardes";
        }
        else
        {
            ViewData["Saludo"] = "Buenas noches";
        }
                
        per.Nombre = "Fernando José";
        per.Apellidos = "Miguel Gómez";
            
        return View(per);
        
    }

    public IActionResult listadoPersonas()
    {
        try {
            return View(ListaPersonas.ListadoCompletoPersonas());
        } 
        catch (Exception ex) {

            return View("Error");

        }

}