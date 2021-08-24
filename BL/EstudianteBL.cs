using System;
using ML;
using DAL;
using System.Collections.Generic;

namespace BL
{
    public class EstudianteBL
    {
        EstudianteADO contexto;
        public EstudianteBL()
        {
            contexto = new EstudianteADO();
        }
        public List<Estudiante> GetEstudiantes()
        {
            return contexto.GetEstudiantes();
        }
        public EstudianteDB GetEstudianteDB(int id)
        {
            return contexto.GetEstudianteDB(id);
        }
        public void InsertEstudiante(string pa, string sa, string n, int s, int td, string nd, int car, int mi, int es, int disc)
        {
            contexto.InsertarEstudiante(pa, sa, n, s, td, nd, car, mi, es, disc);
        }
        public void UpdateEstudiante(int id, string pa, string sa, string n, int s, int td, string nd, int car, int mi, int es, int disc)
        {
            contexto.updateEstudiante(id, pa, sa, n, s, td, nd, car, mi, es, disc);
        }
        public void DeleteEstudiante(int id)
        {
            contexto.deleteEstudiante(id);
        }
        public int ContarEstudiantes()
        {
            return contexto.contarEstudiantes();
        }

        public List<Estudiante> SearchEstudiantes(string busqueda)
        {
            return contexto.searchEstudiantes(busqueda);
        }
    }
}
