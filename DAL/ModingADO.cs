using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using ML;
namespace DAL
{
    public class ModingADO
    {
        BD bd = new BD();
        public ModingADO()
        {

        }
        public List<Moding> GetModing()
        {
            string cadenaConexion = bd.getCadenaConexion();
            try
            {
                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    conexion.Open();
                    string query = "SELECT * FROM modingreso";
                    SqlCommand sqlCommand = new SqlCommand(query, conexion);
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    List<Moding> listaModing = new List<Moding>();
                    //Se repite mientras existan filas en la BD
                    while (sqlDataReader.Read())
                    {
                        //Obteniendo datos de la BD
                        int id = int.Parse(sqlDataReader["moding_id"].ToString());
                        string mi_desc = sqlDataReader["moding_descripcion"].ToString();
                        //Con los campos obtenidos, se crea un objeto
                        Moding moding= new Moding(id, mi_desc);
                        listaModing.Add(moding);
                    }
                    //Se cierra el lector de datos
                    sqlDataReader.Close();
                    //Se retorna la lista
                    return listaModing;
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
