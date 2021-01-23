using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.JsonParser.Entity.Nothi
{
    public class NoteListDataRecordDTO
    {
        public NoteListDataRecordNoteDTO note { get; set; }
        public NoteListDataRecordDeskDTO desk { get; set; }
        public NoteListDataRecordNothiDTO nothi { get; set; }
        public NoteListDataRecordToDTO to { get; set; }
    }
}
