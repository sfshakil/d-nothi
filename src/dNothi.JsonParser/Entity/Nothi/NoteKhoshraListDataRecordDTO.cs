using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.JsonParser.Entity.Nothi
{
    public class NoteKhoshraListDataRecordDTO
    {
        public NoteKhoshraListDataRecordBasicDTO basic { get; set; }
        public NoteKhoshraListDataRecordMulpotroDTO mulpotro { get; set; }
        public NoteKhoshraListDataRecordNoteOwnerDTO note_owner { get; set; }
        public NoteKhoshraListDataRecordNoteOnucchedDTO note_onucched { get; set; }
    }
}
