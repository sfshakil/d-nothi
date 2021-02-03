using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.JsonParser.Entity.Nothi
{
    public class NotePotrojariDataRecordDTO
    {
        public NotePotrojariDataRecordBasicDTO basic { get; set; }
        public NotePotrojariDataRecordMulpotroDTO mulpotro { get; set; }
        public NotePotrojariDataRecordNoteOwnerDTO note_owner { get; set; }
        public NotePotrojariDataRecordNoteOnucchedDTO note_onucched { get; set; }
    }
}
