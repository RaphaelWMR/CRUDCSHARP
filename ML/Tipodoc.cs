using System;
using System.Collections.Generic;
using System.Text;

namespace ML
{
    public class Tipodoc
    {
        public int tipodoc_id { get; set; }
        public string tipodoc_descripcion { get; set; }
        public string tipodoc_abrev { get; set; }
        public Tipodoc()
        {

        }
        //Constructor
        public Tipodoc(int id, string descr,string abrev)
        {
            tipodoc_id = id;
            tipodoc_descripcion= descr;
            tipodoc_abrev = abrev;
        }
    }
}
