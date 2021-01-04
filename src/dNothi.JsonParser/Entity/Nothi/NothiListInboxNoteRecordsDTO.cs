using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.JsonParser.Entity.Nothi
{
    public class NothiListInboxNoteRecordsDTO
    {
        public NoteNothiListInboxNoteRecordsDTO note { get; set; }
        public DeskNothiListInboxNoteRecordsDTO desk { get; set; }
        public NothiNothiListInboxNoteRecordsDTO nothi { get; set; }
        public ToNothiListInboxNoteRecordsDTO to { get; set; }
    }
}
