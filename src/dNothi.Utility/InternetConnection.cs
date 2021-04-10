using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Utility
{
   public  class InternetConnection
    {
        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int Description, int ReservedValue);

        public static  bool  Check()
        {
            int Desc;
            return InternetGetConnectedState(out Desc, 0);
        }
    }
}
