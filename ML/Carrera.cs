using System;
using System.Collections.Generic;
using System.Text;

namespace ML
{
    public class Carrera
    {
        public int carrera_id { get; set; }
        public string carrera_nombre { get; set; }
        public string carrera_facultad { get; set; }
        public char carrera_area { get; set; }
        public Carrera()
        {

        }
        //Constructor
        public Carrera(int id, string nombre,string facu, char area)
        {
            carrera_id = id;
            carrera_nombre = nombre;
            carrera_facultad = facu;
            carrera_area = area;
        }
    }
}
