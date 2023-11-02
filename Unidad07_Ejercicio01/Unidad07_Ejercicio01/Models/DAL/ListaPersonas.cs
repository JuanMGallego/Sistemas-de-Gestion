using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace Unidad07_Ejercicio01.Models.DAL
{
    public class ListaPersonas
    {
        /// <summary>
        /// Funcion que devuelve un listado completo de personas
        /// Pre: ninguna    
        /// Post: ninguna
        /// </summary>
        /// <returns></returns>
        public List<Persona> listadoCompletoPersonas()
        {
            List<Persona> listadoPersonas = new List<Persona>() {
                new Persona("Fernando", "Miguel"),
                new Persona("Juanma", "Sanchez"),
                new Persona("Pedro", "Palardo")
            };

            throw new Exception();
            return listadoPersonas;
            
        }
    }
}
