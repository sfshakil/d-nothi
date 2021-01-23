using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.JsonParser.Entity.Nothi
{
    public class NoteListResponse
    {
        public string status { get; set; }
        public NoteListDataDTO data { get; set; }
    }
}
