using System;
using System.Collections.Generic;
using System.Text;
using ML;
using DAL;


namespace BL
{
    public class AreaBL
    {
        AreaADO contexto;
        public AreaBL()
        {
            contexto = new AreaADO();
        }
        public List<Area> GetAreas()
        {
            return contexto.GetAreas();
        }
    }
}
