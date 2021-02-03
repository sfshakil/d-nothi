using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.JsonParser.Entity.Nothi
{
    public class NoteKhshraWaitingDataRecord
    {
        public NoteKhshraWaitingDataBasicDTO basic { get; set; }
        public NoteKhshraWaitingDataMulpotroDTO mulpotro { get; set; }
        public NoteKhshraWaitingDataNoteOwnerDTO note_owner { get; set; }
        public NoteKhshraWaitingDataNoteOnucchedDTO note_onucched { get; set; }
    }
}
