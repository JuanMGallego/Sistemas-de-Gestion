using Entidades;
using Microsoft.Data.SqlClient;
using System.Collections.ObjectModel;
using _07_CRUD_Personas_DAL.Conexion;

namespace DAL.Listados
{
	public static class ListaPersonas
	{

		/// <summary>
		/// Devuelve un listado de personas
		/// Pre : No
		/// Post : No
		/// </summary>
		/// <returns>Lista de personas</returns>
		public static ObservableCollection<clsPersona> listadoCompletoPersonas()
		{
			clsMyConnection miConexion = new clsMyConnection();

			ObservableCollection<clsPersona> listadoPersonas = new ObservableCollection<clsPersona>();

			SqlCommand miComando = new SqlCommand();
			SqlDataReader miLector;
			clsPersona oPersona;

			try
			{

				SqlConnection open = miConexion.getConnection();

				miComando.CommandText = "SELECT * FROM Personas";

				miComando.Connection = open;

				miLector = miComando.ExecuteReader();

				if (miLector.HasRows)

				{

					while (miLector.Read())

					{

						oPersona = new clsPersona();

						oPersona.Id = (int)miLector["ID"];

						oPersona.Nombre = (string)miLector["Nombre"];

						oPersona.Apellido = (string)miLector["Apellidos"];

						oPersona.IdDepartamento = (int)miLector["IDDepartamento"];

						if (miLector["FechaNacimiento"] != System.DBNull.Value)

						{ oPersona.FNac = (DateTime)miLector["FechaNacimiento"]; }

						oPersona.Foto = (string)miLector["Foto"];

						oPersona.Direccion = (string)miLector["Direccion"];

						oPersona.Tlf = (string)miLector["Telefono"];

						listadoPersonas.Add(oPersona);

					}

				}

				miLector.Close();

				open.Close();
			}

			catch (SqlException exSql)

			{
				throw exSql;

			}
			return listadoPersonas;
		}

		/// <summary>
		/// Devuelve una persona según el id
		/// Pre: id > 0
		/// Post: No
		/// </summary>
		/// <returns>Persona</returns>
		public static clsPersona getPersonaId(int id)
		{
			clsMyConnection miConexion = new clsMyConnection();

			SqlCommand miComando = new SqlCommand();

			SqlDataReader miLector;
			clsPersona oPersona = new clsPersona();

			try

			{

				SqlConnection open = miConexion.getConnection();
				miComando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;
				miComando.CommandText = "SELECT * FROM Personas WHERE ID=@id";
				miComando.Connection = open;
				miLector = miComando.ExecuteReader();

				if (miLector.HasRows)

				{

					miLector.Read();
					oPersona.Id = (int)miLector["ID"];
					oPersona.Nombre = (string)miLector["Nombre"];
					oPersona.Apellido = (string)miLector["Apellidos"];
					oPersona.IdDepartamento = (int)miLector["IDDepartamento"];

					if (miLector["FechaNacimiento"] != System.DBNull.Value)
					{ 
						oPersona.FNac = (DateTime)miLector["FechaNacimiento"]; 
					}

					oPersona.Foto = (string)miLector["Foto"];
					oPersona.Direccion = (string)miLector["Direccion"];
					oPersona.Tlf = (string)miLector["Telefono"];

				}

				miLector.Close();
				open.Close();

			}
			catch (SqlException exSql)
			{
				throw exSql;
			}
			return oPersona;
		}
	}



}