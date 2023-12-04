using DAL.Listados;
using Entidades;
using System.Collections.ObjectModel;

namespace BL.Listados
{
	public static class ListaPersonasBL
	{
		
		public static ObservableCollection<clsPersona> listadoCompletoPersonasBL()
		{
			return ListaPersonas.listadoCompletoPersonas();
		}

		public static clsPersona getPersonaIdBL(int id)
		{
			return ListaPersonas.getPersonaId(id);
		}
	}
}