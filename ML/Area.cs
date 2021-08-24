using System;
using System.Collections.Generic;
using System.Text;

namespace ML
{
    public class Area
    {
        public int area_id { get; set; }
        public char area_letra { get; set; }
        public string area_descripcion { get; set; }

        public Area()
        {

        }

        //Constructor
        public Area(int id, char letra,string descripcion)
        {
            area_id = id;
            area_letra = letra;
            area_descripcion = descripcion;
        }

    }
}

