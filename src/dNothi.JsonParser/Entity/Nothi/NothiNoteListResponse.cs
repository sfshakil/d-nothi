using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.JsonParser.Entity.Nothi
{
  public  class NothiNoteListResponse
    {
        public string status { get; set; }
        public NothiNoteListDataDTO data { get; set; }
    }
    public class NoteDTO
    {
        public int note_no { get; set; }
        public string note_subject { get; set; }
        public object note_status { get; set; }
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



        
        public int office_unit_organogram_id { get; set; }
       

    }
    public class NoteNothiDTO
    {
        public int id { get; set; }
        public int office_id { get; set; }
        public string office_name { get; set; }
        public int office_unit_id { get; set; }
        public string office_unit_name { get; set; }
        public int office_unit_organogram_id { get; set; }
        public string office_designation_name { get; set; }
        public int nothi_type_id { get; set; }
        public string nothi_no { get; set; }
        public string subject { get; set; }
        public string nothi_created_date { get; set; }
        public object description { get; set; }
        public int nothi_class { get; set; }
        public int is_active { get; set; }
        public bool is_deleted { get; set; }
        public bool is_archived { get; set; }
        public object archived_date { get; set; }
        public object archived_organogram_id { get; set; }
        public object archived_designation_name { get; set; }
        public string created { get; set; }
        public string modified { get; set; }
        public int created_by { get; set; }
        public int modified_by { get; set; }
        public string office { get; set; }
        public string office_unit { get; set; }

        public string nothi_id { get { return id.ToString(); } }
        public string note_no { get; set; }
        public string note_subject { get; set; }
        public string note_id { get; set; }




        


    }
    public class NothiNoteDeskDTO
    {
        public int nothi_master_id { get; set; }
        public int nothi_note_id { get; set; }
        public int nothi_office { get; set; }
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
        public int is_migrated { get; set; }



      
        public int is_lock { get; set; }
        public string note_subject { get; set; }





    }
    public class NoteTo
    {
        public int nothi_master_id { get; set; }
        public int nothi_note_id { get; set; }
        public int nothi_office { get; set; }
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
        public int is_migrated { get; set; }
        public int is_lock { get; set; }
        public string note_subject { get; set; }
    }

    public class NothiNoteListRecordDTO
    {
        public  NoteDTO note { get; set; }
        public NothiNoteDeskDTO deskConverted {

            get
            {
                try { return JsonConvert.DeserializeObject<NothiNoteDeskDTO>(desk.ToString()); }
                catch { return null; }
            } 
        
        }
        public object desk { get; set; }
        public NoteNothiDTO nothi { get; set; }
        public NoteTo to { get; set; }
    }
    public class NothiNoteListDataDTO
    {
        public List<NothiNoteListRecordDTO> records { get; set; }
        public int total_records { get; set; }
    }

   
}
