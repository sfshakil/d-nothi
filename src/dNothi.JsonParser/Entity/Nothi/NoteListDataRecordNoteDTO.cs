using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.JsonParser.Entity.Nothi
{
    public class NoteListDataRecordNoteDTO
    {
        public int note_no { get; set; }
        public string note_subject { get; set; }
        public string note_status { get; set; }
        public int onucched_count { get; set; }
        public int attachment_count { get; set; }
        public int khoshra_potro { get; set; }
        public int potrojari { get; set; }
        public int nothivukto_potro { get; set; }
        public int approved_potro { get; set; }
        public int khoshra_waiting_for_approval { get; set; }
        public int finished_count { get; set; }
        public int nothi_note_id { get; set; }
        public int visited { get; set; }
        public string note_subject_sub_text { get; set; }
        public int can_revert { get; set; }
        public int draft_onucched { get; set; }
        public int can_finish { get; set; }
        public int is_editable { get; set; }
        public int new_tab { get; set; }
        public string date { get; set; }
        public long extra_nothi_id { get; set; }
    }
}
