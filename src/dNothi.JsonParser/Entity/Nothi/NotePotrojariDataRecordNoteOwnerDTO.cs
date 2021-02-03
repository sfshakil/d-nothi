using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.JsonParser.Entity.Nothi
{
    public class NotePotrojariDataRecordNoteOwnerDTO
    {
        public int nothi_master_id { get; set; }
        public int nothi_note_id { get; set; }
        public int nothi_office { get; set; }
        public int note_no { get; set; }
        public string note_subject { get; set; }
        public int officer_id { get; set; }
        public string officer { get; set; }
        public int office_id { get; set; }
        public string office { get; set; }
        public int office_unit_id { get; set; }
        public string office_unit { get; set; }
        public int designation_id { get; set; }
        public string designation { get; set; }
        public string issue_date { get; set; }
        public string note_current_status { get; set; }
        public int priority { get; set; }
        public int onucched_count { get; set; }
        public int attachment_count { get; set; }
        public int khoshra_potro { get; set; }
        public int khoshra_waiting_for_approval { get; set; }
        public int approved_potro { get; set; }
        public int potrojari { get; set; }
        public int nothivukto_potro { get; set; }
        public int is_migrated { get; set; }
    }
}
