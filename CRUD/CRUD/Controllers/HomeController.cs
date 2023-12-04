using BL.Listados;
using BL.Manejadoras;
using CRUD.Models.ViewModels;
using DAL.Listados;
using Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;

namespace CRUD.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Listado()
        {
            try
            {
                return View(clsListado.ListadoPersonas());
            }
            catch (Exception e)
            {
                ViewBag.Error = "Ha ocurrido un error";
                return View("Error");

            }
        }

        public ActionResult Delete(int id)
        {
            try
            {
                return View(ListaPersonasBL.getPersonaIdBL(id));
            }
            catch (Exception e)
            {
                ViewBag.Error = "Ha ocurrido un error";
                return View("Error");
            }

        }

        [ActionName("Delete")]
        [HttpPost]
        public IActionResult DeletePost(int id)
        {
            try
            {
                int numeroFilas = HandlerPersonaBL.deletePersonaBL(id);
                if (numeroFilas == 0)
                {
                    ViewBag.Info = "Persona no encontrada";
                }
                else
                {
                    ViewBag.Info = "La persona se ha borrado correctamente";
                }

                return View("Listado", clsListado.ListadoPersonas());
            }
            catch
            {
                ViewBag.Error = "Ha ocurrido un error";
                return View("Error");
            }
        }

        public ActionResult Edit(int id)
        {
            try
            {
                return View(ListaPersonasBL.getPersonaIdBL(id));
            }
            catch (Exception e)
            {
                ViewBag.Error = "Ha ocurrido un error";
                return View("Error");
            }
        }

        [ActionName("Edit")]
        [HttpPost]
        public ActionResult EditPost(clsPersona per)
        {
            try
            {
                int numeroFilas = HandlerPersonaBL.editPersonaBL(per);

                if (numeroFilas == 0)
                {
                    ViewBag.Info = "Persona no encontrada";
                }
                else
                {
                    ViewBag.Info = "La persona se ha borrado correctamente";
                }


                return View("Listado", clsListado.ListadoPersonas());
            }
            catch (Exception e)
            {
                ViewBag.Error = "Ha ocurrido un error";
                return View("Error");
            }
        }

        public ActionResult Create(int id)
        {
            try
            {
                
                return View(ListaPersonasBL.getPersonaIdBL(id));
            }
            catch (Exception e)
            {
                ViewBag.Error = "Ha ocurrido un error";
                return View("Error");
            }
        }

        [ActionName("Create")]
        [HttpPost]
        public ActionResult CreatePost(clsPersona per)
        {
            try
            {
                int numeroFilas = HandlerPersonaBL.createPersonaBL(per);

                if (numeroFilas == 0)
                {
                    ViewBag.Info = "Persona no encontrada";
                }
                else
                {
                    ViewBag.Info = "La persona se ha creado correctamente";
                }


                return View("Listado", clsListado.ListadoPersonas());
            }
            catch (Exception e)
            {
                ViewBag.Error = "Ha ocurrido un error";
                return View("Error");
            }
        }

    }

}