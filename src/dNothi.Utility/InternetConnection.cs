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
        public extern static bool InternetGetConnectedState(out int Description, int ReservedValue);

        public static  bool  Check()
        {
            int Desc;
            if(OfflineMode)
            {
                return false;
            }
            return InternetGetConnectedState(out Desc, 0);
        }

        public static bool CheckMachineConnection()
        {
            int Desc;
            return InternetGetConnectedState(out Desc, 0);
        }

        public static bool OfflineMode { get; set; }
    }
}
