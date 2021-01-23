using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.JsonParser.Entity.Nothi
{
    public class NoteListDataDTO
    {
        public List<NoteListDataRecordDTO> records { get; set; }
        public int total_records { get; set; }
    }
}
