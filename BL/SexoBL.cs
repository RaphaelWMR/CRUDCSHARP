using System;
using System.Collections.Generic;
using System.Text;
using ML;
using DAL;
namespace BL
{
    public class SexoBL
    {
        sexoADO contexto;
        public SexoBL()
        {
            contexto = new sexoADO();
        }
        public List <Sexo> GetSexo()
        {
            return contexto.GetSexo();
        }
    }
}
