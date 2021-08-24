using System;
using System.Collections.Generic;
using System.Text;

namespace ML
{
    public class Sexo
    {
        public int sexo_id { get; set; }
        public string sexo_descripcion { get; set; }
        public char sexo_abrev { get; set; }
        public Sexo()
        {

        }

        //Constructor
        public Sexo(int id,string des, char ab)
        {
            sexo_id = id;
            sexo_descripcion = des;
            sexo_abrev = ab;
        }
    }
}
