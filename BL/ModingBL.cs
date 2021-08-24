using System;
using System.Collections.Generic;
using System.Text;
using ML;
using DAL;

namespace BL
{
    public class ModingBL
    {
        ModingADO contexto;
        public ModingBL()
        {
            contexto = new ModingADO();
        }
        public List <Moding> GetModing()
        {
            return contexto.GetModing();
        }
    }
}
