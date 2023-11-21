using Mandaloriano3.Models.Entities;

namespace Mandaloriano3.DAL
{
    public class MisionDAL
    {
        // Aquí podrías implementar lógica para obtener la lista de misiones desde la base de datos.
        public static List<Mision> ObtenerMisiones()
        {
            return new List<Mision>
        {
            new Mision { Nombre = "Rescate de Baby Yoda", Descripcion = "Debes hacerte con Grogu y llevárselo a Luke SkyWalker para su entrenamiento.", Recompensa = "5000 créditos" },
            new Mision { Nombre = "Recuperar armadura Beskar", Descripcion = "Tu armadura de Beskar ha sido robada. Debes encontrarla.", Recompensa = "2000 créditos" },
            new Mision { Nombre = "Planeta Sorgon", Descripcion = "Debes llevar a un niño de vuelta a su planeta natal “Sorgon”.", Recompensa = "500 créditos" },
            new Mision { Nombre = "Renacuajos", Descripcion = "Debes llevar a una Dama Rana y sus huevos de Tatooine a la luna del estuario Trask, donde su esposo fertilizará los huevos.", Recompensa = "500 créditos" }
        };
        }
    }
}
