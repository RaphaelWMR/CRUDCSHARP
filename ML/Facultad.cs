using System;
using System.Collections.Generic;
using System.Text;

namespace ML
{
    public class Facultad
    {
        public int facultad_id { get; set; }
        public string facultad_nombre { get; set; }  
        public Facultad()
        {

        }
        //Constructor
        public Facultad(int id, string n)
        {
            facultad_id = id;
            facultad_nombre = n;
        }
    }
}


/*
    C = CREATE 
    R = READ 
    U = UPDATE 
    D = DELETE
 */