using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using ML;

namespace DAL
{
    public class DiscapacidadADO
    {
        BD bd = new BD();
        public DiscapacidadADO()
        {

        }
        public List<Discapacidad> GetDiscapacidad()
        {
            BD bd = new BD();
            string cadenaConexion = bd.getCadenaConexion();
            try
            {
                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    conexion.Open();
                    string query = "SELECT * FROM discapacidad";
                    SqlCommand sqlCommand = new SqlCommand(query, conexion);
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    List<Discapacidad> listaDiscapacidad = new List<Discapacidad>();
                    //Se repite mientras existan filas en la BD
                    while (sqlDataReader.Read())
                    {
                        //Obteniendo datos de la BD
                        int id = int.Parse(sqlDataReader["discapacidad_id"].ToString());
                        string sexo_d = sqlDataReader["discapacidad_descripcion"].ToString();
                        //Con los campos obtenidos, se crea un objeto
                        Discapacidad discapacidad = new Discapacidad(id, sexo_d);
                        listaDiscapacidad.Add(discapacidad);
                    }
                    //Se cierra el lector de datos
                    sqlDataReader.Close();
                    //Se retorna la lista
                    return listaDiscapacidad;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"SQL Server exception: {ex.Message}");
                return null;
            }
        }
    }
}
