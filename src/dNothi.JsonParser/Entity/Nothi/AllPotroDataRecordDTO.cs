using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.JsonParser.Entity.Nothi
{
    public class AllPotroDataRecordDTO
    {
        public AllPotroDataRecordBasicDTO basic { get; set; }
        public AllPotroDataRecordMulpotroDTO mulpotro { get; set; }
        public object note_owner { get; set; }
        public List<AllPotroDataRecordNoteOwnerDTO> note_ownerDTOList { get; set; }
        public object note_onucched { get; set; }
        public List<AllPotroDataRecordNoteOnucchedDTO> note_onucchedDTOList { get; set; }
    }
}
