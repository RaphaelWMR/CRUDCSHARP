using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using ML;

namespace DAL
{
    public class TipodocADO
    {
        BD bd = new BD();
        public TipodocADO()
        {

        }
        public List<Tipodoc> GetTipodoc()
        {
            
            string cadenaConexion = bd.getCadenaConexion();
            try
            {
                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    conexion.Open();
                    string query = "SELECT * FROM tipodoc";
                    SqlCommand sqlCommand = new SqlCommand(query, conexion);
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    List<Tipodoc> listaTipodoc = new List<Tipodoc>();
                    //Se repite mientras existan filas en la BD
                    while (sqlDataReader.Read())
                    {
                        //Obteniendo datos de la BD
                        int id = int.Parse(sqlDataReader["tipodoc_id"].ToString());
                        string desc = sqlDataReader["tipodoc_descripcion"].ToString();
                        string abrev = sqlDataReader["tipodoc_abrev"].ToString();
                        //Con los campos obtenidos, se crea un objeto
                        Tipodoc tipodoc = new Tipodoc(id, desc, abrev);
                        listaTipodoc.Add(tipodoc);
                    }
                    //Se cierra el lector de datos
                    sqlDataReader.Close();
                    //Se retorna la lista
                    return listaTipodoc;
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
