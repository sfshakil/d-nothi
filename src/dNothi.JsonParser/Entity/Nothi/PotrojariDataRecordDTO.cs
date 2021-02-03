using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.JsonParser.Entity.Nothi
{
    public class PotrojariDataRecordDTO
    {
        public PotrojariDataRecordBasicDTO basic { get; set; }
        public PotrojariDataRecordMulpotroDTO mulpotro { get; set; }
        public PotrojariDataRecordNoteOwnerDTO note_owner { get; set; }
        public PotrojariDataRecordNoteOnucchedDTO note_onucched { get; set; }
    }
}
