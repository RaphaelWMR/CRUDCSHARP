using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using ML;

namespace DAL
{
    public class sexoADO
    {
        BD bd = new BD();
        public sexoADO()
        {

        }
        public List<Sexo> GetSexo()
        {
           
            string cadenaConexion = bd.getCadenaConexion(); 
            try
            {
                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    conexion.Open();
                    string query = "SELECT * FROM sexo";
                    SqlCommand sqlCommand = new SqlCommand(query, conexion);
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    List<Sexo> listaSexo = new List<Sexo>();
                    //Se repite mientras existan filas en la BD
                    while (sqlDataReader.Read())
                    {
                        //Obteniendo datos de la BD
                        int id = int.Parse(sqlDataReader["sexo_id"].ToString());
                        string sexo_d = sqlDataReader["sexo_descripcion"].ToString();
                        char sexo_ab = char.Parse(sqlDataReader["sexo_abrev"].ToString());
                        //Con los campos obtenidos, se crea un objeto
                        Sexo sexo = new Sexo(id,sexo_d,sexo_ab);
                        listaSexo.Add(sexo);
                    }
                    //Se cierra el lector de datos
                    sqlDataReader.Close();
                    //Se retorna la lista
                    return listaSexo;
                }
            }catch(Exception ex)
            {
                Console.WriteLine($"SQL Server exception: {ex.Message}");
                return null;
            }
        }
    }
}
