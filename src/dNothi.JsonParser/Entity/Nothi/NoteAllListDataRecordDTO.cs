using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.JsonParser.Entity.Nothi
{
    public class NoteAllListDataRecordDTO
    {
        public NoteListDataRecordNoteDTO note { get; set; }
        public object desk { get; set; }
        public List<NoteListDataRecordDeskDTO> deskDtoList { get; set; }
        public NoteListDataRecordNothiDTO nothi { get; set; }
    }
}
