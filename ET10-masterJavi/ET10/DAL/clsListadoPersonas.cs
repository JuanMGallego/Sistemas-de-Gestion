using Entities;
using Microsoft.Data.SqlClient;

namespace ET10.DAL
{
    public class clsListadoPersonas
    {
        public static List<clsPersona> getListadoPersonas()
        {
            String conexion = "server=jgonzaleze.database.windows.net;database=JaviDB;uid=prueba;pwd=fernandoG321;trustServerCertificate=true";

            SqlConnection miConexion = new SqlConnection();
            List<clsPersona>listadoPersonas = new List<clsPersona>();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dataReader;
            clsPersona personita;

            miConexion.ConnectionString = conexion;

            try
            {
                miConexion.Open();

                cmd.CommandText = "SELECT * FROM personas";
                cmd.Connection = miConexion;
                dataReader = cmd.ExecuteReader();

                if (dataReader.HasRows)
                {
                    while(dataReader.Read())
                    {
                        personita = new clsPersona();
                        personita.Id = (int)dataReader["ID"];
                        personita.Nombre = (string)dataReader["Nombre"];
                        personita.Apellidos = (string)dataReader["Apellidos"];
                        if (dataReader["FechaNacimiento"] != System.DBNull.Value)
                        {
                            personita.FechaNac = (DateTime)dataReader["FechaNacimiento"];
                        }

                        if (dataReader["Direccion"] != System.DBNull.Value)
                        {
                            personita.Direccion = (string)dataReader["Direccion"];
                        }

                        if (dataReader["Telefono"] != System.DBNull.Value)
                        {
                            personita.Telefono = (string)dataReader["Telefono"];
                        }

                        if (dataReader["Foto"] != System.DBNull.Value)
                        {
                            personita.Foto = (string)dataReader["Foto"];
                        }

                        personita.IdDepartamento = (int)dataReader["IDDepartamento"];
                        listadoPersonas.Add(personita);
                    }
                    dataReader.Close();
                    miConexion.Close();
                }
            } catch(SqlException ex)
            {
                throw ex;
            }

            return listadoPersonas;
        
        }
    }
}
