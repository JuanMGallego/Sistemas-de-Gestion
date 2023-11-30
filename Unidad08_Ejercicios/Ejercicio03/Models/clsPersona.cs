namespace Ejercicio03.Models
{
	public class clsPersona
	{

		public string nombre { get; set; } = "";
		public string apellidos { get; set; } = "";
		public string tlfno { get; set; } = "";

		public clsPersona() { }

		public clsPersona(string nombre, string apellidos, string tlfno)
		{
			this.nombre = nombre;
			this.apellidos = apellidos;
			this.tlfno = tlfno;
		}

	}
}
