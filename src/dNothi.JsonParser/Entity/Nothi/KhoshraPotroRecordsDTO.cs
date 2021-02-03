
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.JsonParser.Entity.Nothi
{
    public class KhoshraPotroRecordsDTO
    {
        public KhoshraPotroRecordsBasicDTO basic { get; set; }
        public KhoshraPotroRecordsMulpotroDTO mulpotro { get; set; }
        public KhoshraPotroRecordsNoteOwnerDTO note_owner { get; set; }
        public KhoshraPotroRecordsNoteOnucchedDTO note_onucched { get; set; }
    }
}
