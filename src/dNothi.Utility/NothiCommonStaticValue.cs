using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Utility
{
  public  class NothiCommonStaticValue
    {
        public static int pageLimit = 10;
    }
    public static class HideAndShowData
    {
        public static bool sender { get; set; }
        public static bool mainReceiver { get; set; }
        public static bool subject { get; set; }
        public static bool decision { get; set; }
        public static bool dateAndAttachment { get; set; }
        public static bool folder { get; set; }

        public static void Refresh()
        {
            folder=dateAndAttachment = decision = subject =mainReceiver = sender = true;
            
        }
    }
}
