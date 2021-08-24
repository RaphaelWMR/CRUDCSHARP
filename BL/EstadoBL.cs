using System;
using System.Collections.Generic;
using System.Text;
using ML;
using DAL;

namespace BL
{
    public class EstadoBL
    {
        EstadoADO contexto;
        public EstadoBL()
        {
            contexto = new EstadoADO();
        }
        public List<Estado> GetEstado()
        {
            return contexto.GetEstado();
        }
    }
}
