using Microsoft.AspNetCore.Mvc;
using BL;
using Entidades;
using DAL.Listados;
using BL.Listados;
using CRUD.Models.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CRUD.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        // GET: api/<PersonasController>
        [HttpGet]
        public IEnumerable<clsPersona> Get()
        {
            return ListaPersonasBL.listadoCompletoPersonasBL();
        }

        //[HttpGet]
        //public IActionResult Get()
        //{
        //    IActionResult salida;
        //    List<clsPersona> listadoCompleto = new List<clsPersona>();
        //    clsListado listadoBL;
        //    try
        //    {
        //        listadoBL = new clsListado();
        //        listadoCompleto = listadoBL.listadoPersonasBL();
        //        if (listadoCompleto.Count() == 0)
        //        {
        //            salida = NoContent();
        //        }
        //        else
        //        {
        //            salida = Ok(listadoCompleto);
        //        }
        //    }
        //    catch
        //    {
        //        salida = BadRequest();
        //    }
        //    return salida;

        //}


        // GET api/<PersonasController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PersonasController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PersonasController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PersonasController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
