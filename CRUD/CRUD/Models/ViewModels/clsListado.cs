using BL.Listados;
using System.Collections.ObjectModel;
using Entidades;

namespace CRUD.Models.ViewModels
{
    public class clsListado
    {
        public static ObservableCollection<clsPersona> ListadoPersonas()
        { 
            return ListaPersonasBL.listadoCompletoPersonasBL();
        }

    }
}
