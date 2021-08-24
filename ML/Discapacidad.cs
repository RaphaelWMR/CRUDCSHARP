using System;
using System.Collections.Generic;
using System.Text;

namespace ML
{
    public class Discapacidad
    {
        public int discapacidad_id { get; set; }
        public string discapacidad_descripcion { get; set; }
        public Discapacidad()
        {

        }
        //Constructor
        public Discapacidad(int id,string desc)
        {
            discapacidad_id = id;
            discapacidad_descripcion = desc;
        }
    }
}
