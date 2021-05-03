using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.JsonParser.Entity.Nothi
{
    public class NothivuktoPotroDataRecordDTO
    {
        public NothivuktoPotroDataRecordBasicDTO basic { get; set; }
        public NothivuktoPotroDataRecordMulpotroDTO mulpotro { get; set; }
        public NothivuktoPotroDataRecordNoteOwnerDTO note_owner { get; set; }
        public KhoshraPotroWaitinDataRecordNoteOnucchedDTO note_onucched { get; set; }
    }
}
