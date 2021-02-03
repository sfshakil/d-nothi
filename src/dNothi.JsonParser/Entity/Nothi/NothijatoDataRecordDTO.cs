using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.JsonParser.Entity.Nothi
{
    public class NothijatoDataRecordDTO
    {
        public NothijatoDataRecordBasicDTO basic { get; set; }
        public NothijatoDataRecordMulpotroDTO mulpotro { get; set; }
        public NothijatoDataRecordNoteOwnerDTO note_owner { get; set; }
        public NothijatoDataRecordNoteOnucchedDTO note_onucched { get; set; }
    }
}
