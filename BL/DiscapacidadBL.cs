using System;
using System.Collections.Generic;
using System.Text;
using ML;
using DAL;

namespace BL
{
    public class DiscapacidadBL
    {
        DiscapacidadADO contexto;
        public DiscapacidadBL()
        {
            contexto = new DiscapacidadADO();
        }
        public List<Discapacidad> GetDiscapacidad()
        {
            return contexto.GetDiscapacidad();
        }
    }
}
