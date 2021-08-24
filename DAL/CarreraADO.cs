using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using ML;

namespace DAL
{
    public class CarreraADO
    {
        BD bd = new BD();
        public CarreraADO()
        {

        }
        public List<Carrera> GetCarrera()
        {
            string cadenaConexion = bd.getCadenaConexion();
            try
            {
                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    conexion.Open();
                    string query = "SELECT carrera.carrera_id, carrera.carrera_nombre, facultad.facultad_nombre, area.area_letra FROM carrera JOIN facultad ON carrera.facultad_id=facultad.facultad_id JOIN area ON carrera.area_id=area.area_id";
                    SqlCommand sqlCommand = new SqlCommand(query, conexion);
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    List<Carrera> listaCarrera = new List<Carrera>();
                    //Se repite mientras existan filas en la BD
                    while (sqlDataReader.Read())
                    {
                        //Obteniendo datos de la BD
                        int id = int.Parse(sqlDataReader["carrera_id"].ToString());
                        string nombre = sqlDataReader["carrera_nombre"].ToString();
                        string facultad = sqlDataReader["facultad_nombre"].ToString();
                        char ar = char.Parse(sqlDataReader["area_letra"].ToString());
                        //Con los campos obtenidos, se crea un objeto
                        Carrera carrera = new Carrera(id,nombre,facultad,ar);
                        listaCarrera.Add(carrera);
                    }
                    //Se cierra el lector de datos
                    sqlDataReader.Close();
                    //Se retorna la lista
                    return listaCarrera;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"SQL Server exception: {ex.Message}");
                return null;
            }
        }

        public CarreraDB GetCarreraDB(int id)
        {
            string cadenaConexion = bd.getCadenaConexion(); 
            try
            {
                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    conexion.Open();
                    string query = $"SELECT * FROM carrera WHERE carrera_id={id}";
                    SqlCommand sqlCommand = new SqlCommand(query, conexion);
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    List<CarreraDB> listCarreraDB = new List<CarreraDB>();

                    while (sqlDataReader.Read())
                    {
                        int id_es = int.Parse(sqlDataReader["carrera_id"].ToString());
                        string nombre = sqlDataReader["carrera_nombre"].ToString();
                        int facultad = int.Parse(sqlDataReader["facultad_id"].ToString());
                        int area = int.Parse(sqlDataReader["area_id"].ToString());
                        //Con los campos obtenidos, se crea un objeto
                        CarreraDB carreraDB = new CarreraDB(id_es, nombre, facultad, area);
                        listCarreraDB.Add(carreraDB);

                    }
                    sqlDataReader.Close();
                    return listCarreraDB[0];
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"SQL Server exception: {ex.Message}");
                return null;
            }

        }

        public void InsertarCarrera(string nombre, int facultad,int area)
        {
            string cadenaConexion = bd.getCadenaConexion();
            try
            {
                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    conexion.Open();
                    string query = $"INSERT INTO [dbo].[carrera] ([carrera_nombre] ,[facultad_id] ,[area_id]) VALUES ('{nombre}' ,{facultad} ,{area})";
                    SqlCommand sqlCommand = new SqlCommand(query, conexion);
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"SQL Server exception: {ex.Message}");
            }
        }
        public void updateCarrera(int id, string nombre, int facultad,int area)
        {
            string cadenaConexion = bd.getCadenaConexion();
            try
            {
                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    conexion.Open();
                    string query = $"UPDATE [dbo].[carrera] SET [carrera_nombre] = '{nombre}' ,[facultad_id] = {facultad} ,[area_id] = {area} WHERE carrera_id={id}";
                    SqlCommand sqlCommand = new SqlCommand(query, conexion);
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"SQL Server exception: {ex.Message}");
            }
        }

        public void deleteCarrera(int id)
        {
            string cadenaConexion = bd.getCadenaConexion();
            try
            {
                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    conexion.Open();
                    string query = $"DELETE FROM [dbo].[carrera] WHERE carrera_id={id}";
                    SqlCommand sqlCommand = new SqlCommand(query, conexion);
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"SQL Server exception: {ex.Message}");
            }
        }

        public List<Carrera> searchCarrera(string busqueda)
        {
            string cadenaConexion = bd.getCadenaConexion();
            try
            {
                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    conexion.Open();
                    string query = $"SELECT carrera.carrera_id, carrera.carrera_nombre, facultad.facultad_nombre, area.area_letra FROM carrera JOIN facultad ON carrera.facultad_id=facultad.facultad_id JOIN area ON carrera.area_id=area.area_id WHERE carrera.carrera_nombre LIKE '%{busqueda}%' OR facultad.facultad_nombre LIKE '%{busqueda}%' OR facultad.facultad_nombre LIKE '%{busqueda}%' OR area.area_letra LIKE '%{busqueda}%'";
                    SqlCommand sqlCommand = new SqlCommand(query, conexion);
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    List<Carrera> listaCarrera = new List<Carrera>();
                    //Se repite mientras existan filas en la BD
                    while (sqlDataReader.Read())
                    {
                        //Obteniendo datos de la BD
                        int id = int.Parse(sqlDataReader["carrera_id"].ToString());
                        string nombre = sqlDataReader["carrera_nombre"].ToString();
                        string facultad = sqlDataReader["facultad_nombre"].ToString();
                        char ar = char.Parse(sqlDataReader["area_letra"].ToString());
                        //Con los campos obtenidos, se crea un objeto
                        Carrera carrera = new Carrera(id, nombre, facultad, ar);
                        listaCarrera.Add(carrera);
                    }
                    //Se cierra el lector de datos
                    sqlDataReader.Close();
                    //Se retorna la lista
                    return listaCarrera;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"SQL Server exception: {ex.Message}");
                return null;
            }
        }
        public int contarCarreras()
        {
            string cadenaConexion = bd.getCadenaConexion();
            try
            {
                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    conexion.Open();
                    string query = $"SELECT COUNT(carrera_id) as 'cantidad' FROM carrera"; ;
                    SqlCommand sqlCommand = new SqlCommand(query, conexion);
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    List<int> cantidad = new List<int>();
                    while (sqlDataReader.Read())
                    {
                        int cant = int.Parse(sqlDataReader["cantidad"].ToString());
                        cantidad.Add(cant);
                    }
                    sqlDataReader.Close();
                    return cantidad[0];
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"SQL Server exception: {ex.Message}");
                return -1;
            }
        }

    }
}
