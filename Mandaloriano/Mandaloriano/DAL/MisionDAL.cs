using Mandaloriano.Models.Entities;

namespace Mandaloriano.DAL
{
    public class MisionDAL
    {
        private static List<Mision> misiones = new List<Mision>
        {
        new Mision { Id = 1, Nombre = "Rescate de Baby Yoda", Descripcion = "Debes hacerte con Grogu y llevárselo a Luke SkyWalker para su entrenamiento.", Recompensa = "5000 créditos" },
        new Mision { Id = 2, Nombre = "Recuperar armadura Beskar", Descripcion = "Tu armadura de Beskar ha sido robada. Debes encontrarla.", Recompensa = "2000 créditos" },
        new Mision { Id = 3, Nombre = "Planeta Sorgon", Descripcion = "Debes llevar a un niño de vuelta a su planeta natal “Sorgon”.", Recompensa = "500 créditos" },
        new Mision { Id = 4, Nombre = "Renacuajos", Descripcion = "Debes llevar a una Dama Rana y sus huevos de Tatooine a la luna del estuario Trask, donde su esposo fertilizará los huevos.", Recompensa = "500 créditos" }
        };

        public List<Mision> ObtenerMisiones()
        {
            return misiones;
        }

        public Mision ObtenerDetallesMision(int id)
        {
            return misiones.Find(m => m.Id == id);
        }
    }
}
