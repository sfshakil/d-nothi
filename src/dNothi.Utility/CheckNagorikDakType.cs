using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Utility
{
    public class CheckNagorikDakType
    {
        public bool IsNagarik { get; set; }

        public CheckNagorikDakType(string dakType)
        {
            if (dakType == "Nagorik")
                IsNagarik = true;
            else IsNagarik = false;
           
        }

        

    }
}
