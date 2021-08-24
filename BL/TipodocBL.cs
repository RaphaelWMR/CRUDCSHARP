using System;
using System.Collections.Generic;
using System.Text;
using ML;
using DAL;

namespace BL
{
    public class TipodocBL
    {
        TipodocADO contexto;
        public TipodocBL()
        {
            contexto = new TipodocADO();
        }
        public List<Tipodoc> GetTipodoc()
        {
            return contexto.GetTipodoc();
        }
    }
}
