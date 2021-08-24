using System;

namespace ML
{
    public class Estudiante
    {
        public int estudiante_id { get; set; }
        public string estudiante_pa { get; set; }
        public string estudiante_sa { get; set; }
        public string estudiante_nombres { get; set; }
        public string estudiante_sexo { get; set; }
        public string estudiante_tipodoc { get; set; }
        public string estudiante_ndoc { get; set; }
        public string estudiante_carrera { get; set; }
        public string estudiante_moding { get; set; }
        public string estudiante_estado { get; set; }
        public string estudiante_discapacidad { get; set; }
        public Estudiante()
        {

        }

        //Constructor
        public Estudiante(int id, string pa, string sa, string n, string s, string td, string nd,string car, string mi, string es, string disc)
        {
            estudiante_id = id;
            estudiante_pa = pa;
            estudiante_sa = sa;
            estudiante_nombres = n;
            estudiante_sexo = s;
            estudiante_tipodoc = td;
            estudiante_ndoc = nd;
            estudiante_carrera = car;
            estudiante_moding = mi;
            estudiante_estado = es;
            estudiante_discapacidad = disc;
        }
    }
}


/*
    C = CREATE 
    R = READ 
    U = UPDATE 
    D = DELETE
 */