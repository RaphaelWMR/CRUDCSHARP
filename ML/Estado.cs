using System;
using System.Collections.Generic;
using System.Text;

namespace ML
{
    public class Estado
    {
        public int estado_id { get; set; }
        public string estado_descripcion { get; set; }
        public Estado()
        {

        }
        //Constructor
        public Estado(int id, string desc)
        {
            estado_id = id;
            estado_descripcion = desc;
        }
    }
}
