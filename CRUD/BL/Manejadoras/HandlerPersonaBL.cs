using DAL.Manejadoras;
using Entidades;

namespace BL.Manejadoras
{
	public static class HandlerPersonaBL
	{
		
		public static int deletePersonaBL(int id)
		{
			int numFilasAfectadas = 0;
			DateTime fechaActual = DateTime.Now;
			numFilasAfectadas = HandlerPersona.deletePersonaDAL(id);
			
			return numFilasAfectadas;
		}

		public static int editPersonaBL(clsPersona per)
		{
			int numFilasAfectadas = HandlerPersona.editPersonaDAL(per);

			return numFilasAfectadas;
		}

		public static int createPersonaBL(clsPersona per)
		{
			return HandlerPersona.createPersonaDAL(per);
		}
	}
}
