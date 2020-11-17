using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.JsonParser.Entity.Nothi
{
    public class NothiListAllRecordsDTO
    {
        public NothiAllDTO nothi { get; set; }
        public DeskAllDTO desk { get; set; }
        public StatusAllDTO status { get; set; }
    }
}
