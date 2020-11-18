using dNothi.JsonParser.Entity.Dak_List_Inbox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.JsonParser.Entity.Dak
{
   public class DakListNothijatoResponse
    {
        public string status { get; set; }
        public DakListDTO data { get; set;}
    }
}
