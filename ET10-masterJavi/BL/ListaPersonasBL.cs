using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class ListaPersonasBL
    {
        /// <summary>
        /// Funcion que devuelve un listado de personas obtenido de la dal y aplicando las reglas de negocio
        /// </summary>
        /// <returns>Lista con personas</returns>
        public static List<clsPersona> listadoCompletoPersonasBL()
        {
            return ListaPersonas.listadoCompletoPersonasBL();
        }

        public static clsPersona getPersonaIdBL(int id)
        {
            return ListaPersonas.listadoCompletoPersonasBL();
        }
    }
}
