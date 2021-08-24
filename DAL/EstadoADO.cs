using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using ML;

namespace DAL
{
    public class EstadoADO
    {
        BD bd = new BD();
        public EstadoADO()
        {

        }
        public List<Estado> GetEstado()
        {
            string cadenaConexion = bd.getCadenaConexion();
            try
            {
                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    conexion.Open();
                    string query = "SELECT * FROM estado";
                    SqlCommand sqlCommand = new SqlCommand(query, conexion);
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    List<Estado> listaEstado = new List<Estado>();
                    //Se repite mientras existan filas en la BD
                    while (sqlDataReader.Read())
                    {
                        //Obteniendo datos de la BD
                        int id = int.Parse(sqlDataReader["estado_id"].ToString());
                        string desc = sqlDataReader["estado_descripcion"].ToString();
                        //Con los campos obtenidos, se crea un objeto
                        Estado estado = new Estado(id, desc);
                        listaEstado.Add(estado);
                    }
                    //Se cierra el lector de datos
                    sqlDataReader.Close();
                    //Se retorna la lista
                    return listaEstado;
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
