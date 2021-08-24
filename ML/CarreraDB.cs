using System;
using System.Collections.Generic;
using System.Text;

namespace ML
{
    public class CarreraDB
    {
        public int carrera_id { get; set; }
        public string carrera_nombre { get; set; }
        public int carrera_facultad { get; set; }
        public int carrera_area { get; set; }
        public CarreraDB()
        {

        }
        //Constructor
        public CarreraDB(int id, string nombre, int facu, int area)
        {
            carrera_id = id;
            carrera_nombre = nombre;
            carrera_facultad = facu;
            carrera_area = area;
        }
    }
}
