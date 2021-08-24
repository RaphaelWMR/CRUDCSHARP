using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class BD
    {
        //Nombre del servidor al cual la aplicacion se conectara
        private static string servidor = @"DESKTOP-I398EVQ\SQLEXPRESS";
        //Nombre de la base de datos al cual la aplicacion se conectara
        private static string baseDeDatos = "estudiantes";
        //Nombre de usuario de la base de datos
        private static string usuario = "sa";
        //Contrasenia del usuario
        private static string contrasenia = "admin";

        public BD()
        {

        }
        public string getCadenaConexion()
        {
            string cadenaConexion = $"Server={servidor};Database={baseDeDatos};User Id={usuario};Password={contrasenia}";
            return cadenaConexion;
        }
    }
}
