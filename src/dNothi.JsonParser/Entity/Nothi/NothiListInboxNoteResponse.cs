using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.JsonParser.Entity.Nothi
{
    public class NothiListInboxNoteResponse
    {
        public string status { get; set; }
        public string message { get; set; }
        public NothiListInboxNoteDTO data { get; set; }

        public class NoteAttachmentsRecord
        {
            public int id { get; set; }
            public int nothi_master_id { get; set; }
            public int nothi_note_id { get; set; }
            public int note_onucched_id { get; set; }
            public string attachment_type { get; set; }
            public string file_name { get; set; }
            public string user_file_name { get; set; }
            public double file_size_in_kb { get; set; }
            public string file_dir { get; set; }
            public int digital_sign { get; set; }
            public string sign_info { get; set; }
            public int created_by { get; set; }
            public int modified_by { get; set; }
            public string created { get; set; }
            public string modified { get; set; }
            public object token { get; set; }
            public string device_type { get; set; }
            public object device_id { get; set; }
            public string url { get; set; }
            public string download_url { get; set; }
            public string thumb_url { get; set; }
        }

        public class NoteAttachmentsData
        {
            public List<NoteAttachmentsRecord> records { get; set; }
            public int total_records { get; set; }
        }

        public class NoteAttachmentsListResponse
        {
            public string status { get; set; }
            public NoteAttachmentsData data { get; set; }
            public List<object> options { get; set; }
        }
        public class From
        {
            public int office_id { get; set; }
            public int office_unit_id { get; set; }
            public int designation_id { get; set; }
            public int officer_id { get; set; }
            public string office { get; set; }
            public string office_unit { get; set; }
            public string designation { get; set; }
            public string officer { get; set; }
            public string thumb { get; set; }
        }

        public class To
        {
            public int office_id { get; set; }
            public int office_unit_id { get; set; }
            public int designation_id { get; set; }
            public int officer_id { get; set; }
            public string office { get; set; }
            public string office_unit { get; set; }
            public string designation { get; set; }
            public string officer { get; set; }
            public int priority { get; set; }
            public string thumb { get; set; }
        }

        public class Other
        {
            public int id { get; set; }
            public int nothi_master_id { get; set; }
            public int nothi_note_id { get; set; }
            public int nothi_office { get; set; }
            public int view_status { get; set; }
            public string note_decision { get; set; }
            public int movement_type { get; set; }
            public string created { get; set; }
            public string modified { get; set; }
        }

        public class NoteMovementsRecord
        {
            public From from { get; set; }
            public List<To> to { get; set; }
            public Other other { get; set; }
        }
        public class NoteMovementsData
        {
            public List<NoteMovementsRecord> records { get; set; }
            public int total_records { get; set; }
        }
        public class NoteMovementsListResponse
        {
            public string status { get; set; }
            public NoteMovementsData data { get; set; }
            public List<object> options { get; set; }
        }

        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
        public class OtherOfficeNothiListInboxNoteDataRecordNothi
        {
            public int id { get; set; }
            public int office_id { get; set; }
            public string office_name { get; set; }
            public int office_unit_id { get; set; }
            public string office_unit_name { get; set; }
            public int office_unit_organogram_id { get; set; }
            public string office_designation_name { get; set; }
            public string nothi_no { get; set; }
            public string subject { get; set; }
            public int nothi_class { get; set; }
            public string modified { get; set; }
            public string last_note_date { get; set; }
        }

        public class OtherOfficeNothiListInboxNoteDataRecordDesk
        {
            public string note_subject { get; set; }
            public int note_no { get; set; }
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
            public int onucched_count { get; set; }
            public int attachment_count { get; set; }
            public int khoshra_potro { get; set; }
            public int khoshra_waiting_for_approval { get; set; }
            public int approved_potro { get; set; }
            public int potrojari { get; set; }
            public int nothivukto_potro { get; set; }
            public int is_archive { get; set; }
            public int is_finished { get; set; }
            public int is_migrated { get; set; }
            public int shared_nothi_count { get; set; }
        }

        public class OtherOfficeNothiListInboxNoteDataRecordNote
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
            public string note_subject { get; set; }
            public int note_no { get; set; }
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
            public int shared_nothi_count { get; set; }
        }

        public class OtherOfficeNothiListInboxNoteDataRecordTo
        {
            public int office_id { get; set; }
            public string office { get; set; }
            public int office_unit_id { get; set; }
            public string office_unit { get; set; }
            public int designation_id { get; set; }
            public string designation { get; set; }
            public int officer_id { get; set; }
            public string officer { get; set; }
            public int view_status { get; set; }
            public string issue_date { get; set; }
            public int priority { get; set; }
        }

        public class OtherOfficeNothiListInboxNoteDataRecordFrom
        {
            public int office_id { get; set; }
            public string office { get; set; }
            public int office_unit_id { get; set; }
            public string office_unit { get; set; }
            public int designation_id { get; set; }
            public string designation { get; set; }
            public int officer_id { get; set; }
            public string officer { get; set; }
            public int view_status { get; set; }
            public string issue_date { get; set; }
            public int priority { get; set; }
        }

        public class OtherOfficeNothiListInboxNoteDataRecord
        {
            public OtherOfficeNothiListInboxNoteDataRecordNothi nothi { get; set; }
            public OtherOfficeNothiListInboxNoteDataRecordDesk desk { get; set; }
            public OtherOfficeNothiListInboxNoteDataRecordNote note { get; set; }
            public OtherOfficeNothiListInboxNoteDataRecordTo to { get; set; }
            public OtherOfficeNothiListInboxNoteDataRecordFrom from { get; set; }
        }

        public class OtherOfficeNothiListInboxNoteData
        {
            public List<OtherOfficeNothiListInboxNoteDataRecord> records { get; set; }
            public int total_records { get; set; }
        }

        public class OtherOfficeNothiListInboxNoteResponse
        {
            public string status { get; set; }
            public OtherOfficeNothiListInboxNoteData data { get; set; }
            public List<object> options { get; set; }
        }


    }
}
