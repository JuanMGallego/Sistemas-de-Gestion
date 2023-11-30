using ExamenSGEJMGG.Models.Entidades;

namespace ExamenSGEJMGG.DAL
{
    //La capa DAL podria ir en una biblioteca de clases fuera del proyecto.
    public class clsListadosDAL
    {

        public static List<clsMarca> ObtenerListadoCompletoMarcasDAL()
        {
            return new List<clsMarca>
            {
                new clsMarca { id=1, nombre="Seat"},
                new clsMarca{ id=2, nombre="Nissan"},
                new clsMarca{ id=3, nombre="Renault"}
            };
        }

        public static List<clsModelo> ObtenerListadoModelosPorMarcaDAL(int idMarca)
        {
            return new List<clsModelo>
            {
                //Devuelve la lista de modelos de la marca con la id introducida por parámetros
            };

        }

        public static clsMarca ObtenerMarcaPorIdDAL(int id)
        {
            return new clsMarca
            {

            };
        }

    }
}
