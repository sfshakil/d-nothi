using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.JsonParser.Entity.Nothi
{
    public class NothiOnuchhedSaveResponse
    {
        public string status { get; set; }
        public string message { get; set; }
        public NothiOnuchhedSaveDataDTO data { get; set; }
    }
}
