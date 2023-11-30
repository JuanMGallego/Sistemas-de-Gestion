using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public static class HandlerPersonasBL
    {
        /// <summary>
        /// Funcion que llama a la DAL y devuelve el num de filas afectadas al borrar
        /// la persona que recibe como parametro y aplica la norma de negocio
        /// Post Condicion: Mi salida es 0: cuando no haya id, -1 error de la BL, 1 conseguido borrar
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Devuelve el num de filas</returns>
        public static int deletePersonaBL(int id)
        {
            int numFilasAfectadas = 0;
            DateTime fechaActual = DateTime.Now;
            // Si el dia es miercoles no se puede borrar 
            if (fechaActual.DayOfWeek == DayOfWeek.Wednesday)
            {
                numFilasAfectadas = -1;
            }
            else
            {
            numFilasAfectadas = DAL.HandlerPersona.deletePersonaDAL(id);

            }

            return numFilasAfectadas;

        }
    }
}
