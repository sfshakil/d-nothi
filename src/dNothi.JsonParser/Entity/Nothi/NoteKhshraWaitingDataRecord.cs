using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.JsonParser.Entity.Nothi
{
    public class NoteKhshraWaitingDataRecord
    {
        public KhoshraPotroWaitinDataRecordBasicDTO basic { get; set; }
        public KhoshraPotroRecordsMulpotroDTO mulpotro { get; set; }
        public KhoshraPotroWaitinDataRecordNoteOwnerDTO note_owner { get; set; }
        public KhoshraPotroWaitinDataRecordNoteOnucchedDTO note_onucched { get; set; }
    }
}
