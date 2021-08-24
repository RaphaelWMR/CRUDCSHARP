using System;
using System.Collections.Generic;
using System.Text;

namespace ML
{
    public class Moding
    {
        public int moding_id { get; set; }
        public string moding_descripcion { get; set; }
        public Moding()
        {

        }
        //Constructor
        public Moding(int mii, string mid)
        {     
                moding_id = mii;
                moding_descripcion = mid;
        }
    }
}
