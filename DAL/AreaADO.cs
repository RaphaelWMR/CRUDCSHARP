using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using ML;

namespace DAL
{
    public class AreaADO
    {
        public AreaADO()
        {

        }
        public List<Area> GetAreas()
        {
            BD bd = new BD();
            string cadenaConexion = bd.getCadenaConexion();
            try
            {
                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    conexion.Open();
                    string query = "SELECT * FROM Area";
                    SqlCommand sqlCommand = new SqlCommand(query, conexion);
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    List<Area> listaAreas = new List<Area>();
                    //Se repite mientras existan filas en la BD
                    while (sqlDataReader.Read())
                    {
                        //Obteniendo datos de la BD
                        int id = int.Parse(sqlDataReader["area_id"].ToString());
                        char al = char.Parse(sqlDataReader["area_letra"].ToString()) ;
                        string ad = sqlDataReader["area_descripcion"].ToString();
                        //Con los campos obtenidos, se crea un objeto
                        Area area = new Area(id, al, ad);
                        listaAreas.Add(area);
                    }
                    //Se cierra el lector de datos
                    sqlDataReader.Close();
                    //Se retorna la lista de 
                    return listaAreas;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"SQL Server exception: {ex.Message}");
                return null;
            }
        }
    }
}
