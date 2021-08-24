using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using ML;

namespace DAL
{
    public class FacultadADO
    {
        BD bd = new BD();
        public FacultadADO()
        {

        }
        public List<Facultad> GetFacultad()
        {  
            string cadenaConexion = bd.getCadenaConexion();
            try
            {
                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    conexion.Open();
                    string query = "SELECT * FROM Facultad";
                    SqlCommand sqlCommand = new SqlCommand(query, conexion);
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    List<Facultad> listaFacultad = new List<Facultad>();
                    //Se repite mientras existan filas en la BD
                    while (sqlDataReader.Read())
                    {
                        //Obteniendo datos de la BD
                        int id = int.Parse(sqlDataReader["facultad_id"].ToString());
                        string fn = sqlDataReader["facultad_nombre"].ToString();
                        //Con los campos obtenidos, se crea un objeto
                        Facultad facultad = new Facultad(id,fn);
                        listaFacultad.Add(facultad);
                    }
                    //Se cierra el lector de datos
                    sqlDataReader.Close();
                    //Se retorna la list
                    return listaFacultad;
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
