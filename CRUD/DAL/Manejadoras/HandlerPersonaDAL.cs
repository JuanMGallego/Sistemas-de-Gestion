using Microsoft.Data.SqlClient;
using Entidades;
using _07_CRUD_Personas_DAL.Conexion;
using System.Collections.ObjectModel;
using DAL.Listados;

namespace DAL.Manejadoras
{
	public static class HandlerPersona
	{
		/// <summary>
		/// Se elimina la persona en la bd
		/// Pre: id > 0
		/// Post: No
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public static int deletePersonaDAL(int id)

		{
			int cantidadFilas = 0;
			clsMyConnection miConexion = new clsMyConnection();
			SqlCommand miComando = new SqlCommand();
			miComando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;
			try
			{
				SqlConnection open = miConexion.getConnection();
				miComando.CommandText = "DELETE FROM Personas WHERE ID=@id";
				miComando.Connection = open;
				cantidadFilas = miComando.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				throw ex;
			}

			return cantidadFilas;
		}

		/// <summary>
		/// Se edita la persona seleccionada en la bd
		/// Pre: id > 0
		/// Post: No
		/// </summary>
		/// <param name="persona"></param>
		/// <returns></returns>
		public static int editPersonaDAL(clsPersona persona)
		{
			int cantidadFilas = 0;
			SqlCommand miComando = new SqlCommand();
			clsMyConnection miConexion = new clsMyConnection();

			try
			{
				SqlConnection open = miConexion.getConnection();

				miComando.CommandText = "UPDATE Personas " +
					"SET Nombre = @Nombre, apellidos = @Apellido, Telefono = @Telefono, Direccion = @Direccion, Foto = @Foto, FechaNacimiento = @FechaNacimiento, IDDepartamento = @IdDepartamento " +
					"WHERE ID=@id";
				miComando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = persona.Id;
				miComando.Parameters.Add("@Nombre", System.Data.SqlDbType.VarChar).Value = persona.Nombre;
				miComando.Parameters.Add("@Apellido", System.Data.SqlDbType.VarChar).Value = persona.Apellido;
				miComando.Parameters.Add("@FechaNacimiento", System.Data.SqlDbType.Date).Value = persona.FNac;
				miComando.Parameters.Add("@Direccion", System.Data.SqlDbType.VarChar).Value = persona.Direccion;
				miComando.Parameters.Add("@Telefono", System.Data.SqlDbType.VarChar).Value = persona.Tlf;
				miComando.Parameters.Add("@Foto", System.Data.SqlDbType.VarChar).Value = persona.Foto;
				miComando.Parameters.Add("@IdDepartamento", System.Data.SqlDbType.Int).Value = persona.IdDepartamento;

				miComando.Connection = open;
				cantidadFilas = miComando.ExecuteNonQuery();

			}
			catch (Exception ex)
			{
				throw ex;
			}

			return cantidadFilas;
		}

		/// <summary>
		/// Se crea una persona nueva en la base de datos
		/// Pre: id > 0
		/// Post: No
		/// </summary>
		/// <param name="persona"></param>
		/// <returns></returns>
		public static int createPersonaDAL(clsPersona persona)
		{
			int cantidadFilas = 0;
			SqlCommand miComando = new SqlCommand();
			clsMyConnection miConexion = new clsMyConnection();

			try
			{
				SqlConnection open = miConexion.getConnection();

				miComando.CommandText = "INSERT INTO Personas (Nombre, Apellidos, Telefono, Direccion, Foto, FechaNacimiento, IDDepartamento) " +
				"VALUES (@Nombre, @Apellido, @Telefono, @Direccion, @Foto, @FechaNacimiento, @IdDepartamento)";
				miComando.Parameters.Add("@Nombre", System.Data.SqlDbType.VarChar).Value = persona.Nombre;
				miComando.Parameters.Add("@Apellido", System.Data.SqlDbType.VarChar).Value = persona.Apellido;
				miComando.Parameters.Add("@FechaNacimiento", System.Data.SqlDbType.Date).Value = persona.FNac;
				miComando.Parameters.Add("@Direccion", System.Data.SqlDbType.VarChar).Value = persona.Direccion;
				miComando.Parameters.Add("@Telefono", System.Data.SqlDbType.VarChar).Value = persona.Tlf;
				miComando.Parameters.Add("@Foto", System.Data.SqlDbType.VarChar).Value = persona.Foto;
				miComando.Parameters.Add("@IdDepartamento", System.Data.SqlDbType.Int).Value = persona.IdDepartamento;


				miComando.Connection = open;
				cantidadFilas = miComando.ExecuteNonQuery();

			}
			catch (Exception ex)
			{
				throw ex;
			}

			return cantidadFilas;

		}
	}
}