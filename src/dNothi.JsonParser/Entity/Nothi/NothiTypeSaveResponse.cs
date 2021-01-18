using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.JsonParser.Entity.Nothi
{
    public class NothiTypeSaveResponse
    {
        public string status { get; set; }
        public NothiTypeSaveDTO data { get; set; }
        public int id { get; set; }
        public string message { get; set; }
    }
}
