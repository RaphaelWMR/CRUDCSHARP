using System;
using System.Collections.Generic;
using System.Text;

namespace ML
{
    public class EstudianteDB
    {
        public int estudiante_id { get; set; }
        public string estudiante_pa { get; set; }
        public string estudiante_sa { get; set; }
        public string estudiante_nombres { get; set; }
        public int estudiante_sexo { get; set; }
        public int estudiante_tipodoc { get; set; }
        public string estudiante_ndoc { get; set; }
        public int estudiante_carrera { get; set; }
        public int estudiante_moding { get; set; }
        public int estudiante_estado { get; set; }
        public int estudiante_discapacidad { get; set; }

        public EstudianteDB()
        {

        }
        //Constructor
        public EstudianteDB(int id, string pa, string sa, string n, int s, int td, string nd, int car, int mi, int es, int disc)
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
