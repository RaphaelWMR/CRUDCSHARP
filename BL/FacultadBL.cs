using System;
using System.Collections.Generic;
using System.Text;
using ML;
using DAL;

namespace BL
{
    public class FacultadBL
    {
        FacultadADO contexto;
        public FacultadBL()
        {
            contexto = new FacultadADO();
        }
        public List<Facultad> GetFacultad()
        {
            return contexto.GetFacultad();
        }

    }
}
