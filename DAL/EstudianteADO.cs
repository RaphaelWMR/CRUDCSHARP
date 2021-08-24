using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using ML;

namespace DAL
{
    public class EstudianteADO
    {
        BD bd = new BD();
        public EstudianteADO()
        {

        }
        public List<Estudiante> GetEstudiantes()
        {

            string cadenaConexion = bd.getCadenaConexion();
            try
            {
                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    conexion.Open();
                    string query = "SELECT estudiante.estudiante_id, estudiante.estudiante_pa,estudiante_sa, estudiante.estudiante_nombres, sexo.sexo_descripcion, tipodoc.tipodoc_abrev, estudiante.estudiante_ndoc, carrera.carrera_nombre, modingreso.moding_descripcion, estado.estado_descripcion, discapacidad.discapacidad_descripcion FROM estudiante JOIN sexo ON estudiante.sexo_id=sexo.sexo_id JOIN tipodoc ON estudiante.tipodoc_id=tipodoc.tipodoc_id JOIN carrera ON estudiante.carrera_id=carrera.carrera_id JOIN modingreso ON estudiante.moding_id=modingreso.moding_id JOIN estado ON estudiante.estado_id=estado.estado_id JOIN discapacidad ON estudiante.discapacidad_id=discapacidad.discapacidad_id";
                    SqlCommand sqlCommand = new SqlCommand(query, conexion);
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    List<Estudiante> listaEstudiantes = new List<Estudiante>();
                    //Se repite mientras existan filas en la BD
                    while (sqlDataReader.Read())
                    {
                        //Obteniendo datos de la BD
                        int id = int.Parse(sqlDataReader["estudiante_id"].ToString());
                        string pa = sqlDataReader["estudiante_pa"].ToString();
                        string sa = sqlDataReader["estudiante_sa"].ToString();
                        string n = sqlDataReader["estudiante_nombres"].ToString();
                        string s = sqlDataReader["sexo_descripcion"].ToString();
                        string td = sqlDataReader["tipodoc_abrev"].ToString();
                        string nd = sqlDataReader["estudiante_ndoc"].ToString();
                        string car = sqlDataReader["carrera_nombre"].ToString();
                        string mi = sqlDataReader["moding_descripcion"].ToString();
                        string es = sqlDataReader["estado_descripcion"].ToString();
                        string disc = sqlDataReader["discapacidad_descripcion"].ToString();
                        //Con los campos obtenidos, se crea un objeto
                        Estudiante estudiante = new Estudiante(id,pa,sa,n,s,td,nd,car,mi,es,disc);
                        listaEstudiantes.Add(estudiante);
                    }
                    //Se cierra el lector de datos
                    sqlDataReader.Close();
                    //Se retorna la lista de estudiantes
                    return listaEstudiantes;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"SQL Server exception: {ex.Message}");
                return null;
            }
        }

        public EstudianteDB GetEstudianteDB(int id)
        {
            string cadenaConexion = bd.getCadenaConexion();
            try
            {
                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    conexion.Open();
                    string query = $"SELECT * FROM estudiante WHERE estudiante_id={id}";
                    SqlCommand sqlCommand = new SqlCommand(query, conexion);
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    List<EstudianteDB> listEstudianteDB = new List<EstudianteDB>();

                    while (sqlDataReader.Read())
                    {
                        int id_es = int.Parse(sqlDataReader["estudiante_id"].ToString());
                        string pa = sqlDataReader["estudiante_pa"].ToString();
                        string sa = sqlDataReader["estudiante_sa"].ToString();
                        string n = sqlDataReader["estudiante_nombres"].ToString();
                        int s = int.Parse(sqlDataReader["sexo_id"].ToString());
                        int td = int.Parse(sqlDataReader["tipodoc_id"].ToString());
                        string nd = sqlDataReader["estudiante_ndoc"].ToString();
                        int car = int.Parse(sqlDataReader["carrera_id"].ToString());
                        int mi = int.Parse(sqlDataReader["moding_id"].ToString());
                        int es = int.Parse(sqlDataReader["estado_id"].ToString());
                        int disc = int.Parse(sqlDataReader["discapacidad_id"].ToString());
                        //Con los campos obtenidos, se crea un objeto
                        EstudianteDB estudianteDB = new EstudianteDB(id_es, pa, sa, n, s, td, nd, car, mi, es, disc);
                        listEstudianteDB.Add(estudianteDB);

                    }
                    sqlDataReader.Close();
                    return listEstudianteDB[0];
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"SQL Server exception: {ex.Message}");
                return null;
            }

        }

        public List<Estudiante> searchEstudiantes(string busqueda)
        {
            string cadenaConexion = bd.getCadenaConexion();
            try
            {
                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    conexion.Open();
                    string query = $"SELECT estudiante.estudiante_id, estudiante.estudiante_pa, estudiante.estudiante_sa, estudiante.estudiante_nombres, sexo.sexo_descripcion, tipodoc.tipodoc_abrev, estudiante.estudiante_ndoc, carrera.carrera_nombre, modingreso.moding_descripcion, estado.estado_descripcion, discapacidad.discapacidad_descripcion FROM estudiante JOIN sexo ON estudiante.sexo_id=sexo.sexo_id JOIN tipodoc ON estudiante.tipodoc_id=tipodoc.tipodoc_id JOIN carrera ON estudiante.carrera_id=carrera.carrera_id JOIN modingreso ON estudiante.moding_id=modingreso.moding_id JOIN estado ON estudiante.estado_id=estado.estado_id JOIN discapacidad ON estudiante.discapacidad_id=discapacidad.discapacidad_id WHERE estudiante.estudiante_pa LIKE '%{busqueda}%' OR estudiante.estudiante_sa LIKE '%{busqueda}%' OR estudiante.estudiante_nombres LIKE '%{busqueda}%' OR sexo.sexo_descripcion LIKE '%{busqueda}%' OR tipodoc.tipodoc_abrev LIKE '%{busqueda}%' OR estudiante.estudiante_ndoc LIKE '%{busqueda}%' OR carrera.carrera_nombre LIKE '%{busqueda}%' OR modingreso.moding_descripcion LIKE '%{busqueda}%' OR estado.estado_descripcion LIKE '%{busqueda}%' OR discapacidad.discapacidad_descripcion LIKE '%{busqueda}%'";
                    SqlCommand sqlCommand = new SqlCommand(query, conexion);
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    List<Estudiante> listaEstudiantes = new List<Estudiante>();
                    //Se repite mientras existan filas en la BD
                    while (sqlDataReader.Read())
                    {
                        //Obteniendo datos de la BD
                        int id = int.Parse(sqlDataReader["estudiante_id"].ToString());
                        string pa = sqlDataReader["estudiante_pa"].ToString();
                        string sa = sqlDataReader["estudiante_sa"].ToString();
                        string n = sqlDataReader["estudiante_nombres"].ToString();
                        string s = sqlDataReader["sexo_descripcion"].ToString();
                        string td = sqlDataReader["tipodoc_abrev"].ToString();
                        string nd = sqlDataReader["estudiante_ndoc"].ToString();
                        string car = sqlDataReader["carrera_nombre"].ToString();
                        string mi = sqlDataReader["moding_descripcion"].ToString();
                        string es = sqlDataReader["estado_descripcion"].ToString();
                        string disc = sqlDataReader["discapacidad_descripcion"].ToString();
                        //Con los campos obtenidos, se crea un objeto
                        Estudiante estudiante = new Estudiante(id, pa, sa, n, s, td, nd, car, mi, es, disc);
                        listaEstudiantes.Add(estudiante);
                    }
                    //Se cierra el lector de datos
                    sqlDataReader.Close();
                    //Se retorna la lista de estudiantes
                    return listaEstudiantes;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"SQL Server exception: {ex.Message}");
                return null;
            }
        }

        public void InsertarEstudiante(string pa,string sa, string n, int s, int td,string nd,int car,int mi,int es,int disc)
        {
            string cadenaConexion = bd.getCadenaConexion();
            try
            {
                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    conexion.Open();
                    string query = $"INSERT INTO [dbo].[estudiante] ([estudiante_pa] ,[estudiante_sa] ,[estudiante_nombres] ,[sexo_id] ,[tipodoc_id] ,[estudiante_ndoc] ,[carrera_id] ,[moding_id] ,[estado_id] ,[discapacidad_id]) VALUES ('{pa}' ,'{sa}' ,'{n}' ,{s} ,{td} ,'{nd}',{car},{mi},{es},{disc})";
                    SqlCommand sqlCommand = new SqlCommand(query, conexion);
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"SQL Server exception: {ex.Message}");
            }
        }
        public void updateEstudiante(int id, string pa, string sa, string n, int s, int td, string nd, int car, int mi, int es, int disc)
        {
            string cadenaConexion = bd.getCadenaConexion();
            try
            {
                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    conexion.Open();
                    string query = $"UPDATE [dbo].[estudiante] SET [estudiante_pa] = '{pa}' ,[estudiante_sa] = '{sa}' ,[estudiante_nombres] = '{n}' ,[sexo_id] = {s} ,[tipodoc_id] = {td} ,[estudiante_ndoc] = '{nd}' ,[carrera_id] = {car} ,[moding_id] = {mi} ,[estado_id] = {es} ,[discapacidad_id] = {disc} WHERE estudiante_id={id}";
                    SqlCommand sqlCommand = new SqlCommand(query, conexion);
                    sqlCommand.ExecuteNonQuery();
                }
            }   catch(Exception ex)
            {
                Console.WriteLine($"SQL Server exception: {ex.Message}");
            }
        }

        public void deleteEstudiante(int id)
        {
            string cadenaConexion = bd.getCadenaConexion();
            try
            {
                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    conexion.Open();
                    string query = $"DELETE FROM [dbo].[estudiante] WHERE estudiante_id={id}";
                    SqlCommand sqlCommand = new SqlCommand(query, conexion);
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"SQL Server exception: {ex.Message}");
            }
        }
        public int contarEstudiantes()
        {
            string cadenaConexion = bd.getCadenaConexion();
            try
            {
                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    conexion.Open();
                    string query = $"SELECT COUNT(estudiante_id) as 'cantidad' FROM estudiante";;
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
            catch(Exception ex)
            {
                Console.WriteLine($"SQL Server exception: {ex.Message}");
                return -1;
            }
        }
    }
}
