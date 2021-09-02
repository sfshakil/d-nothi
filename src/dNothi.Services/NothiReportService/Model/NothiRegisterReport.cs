using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Services.NothiReportService.Model
{
    public class NothiRegisterReport
    {
        public class Nothi
        {
            public int id { get; set; }
            public string nothi_no { get; set; }
            public int nothi_type_id { get; set; }
            public string subject { get; set; }
            public string nothi_created_date { get; set; }
            public int nothi_class { get; set; }
        
            public int office_id { get; set; }
            public string office_name { get; set; }
            public int office_unit_id { get; set; }
            public string office_unit_name { get; set; }
            public int office_unit_organogram_id { get; set; }
            public string office_designation_name { get; set; }
       
            public string modified { get; set; }
            public string last_note_date { get; set; }
           
        }

        public class Desk
        {
            public int nothi_master_id { get; set; }
            public string issue_date { get; set; }
            public int note_count { get; set; }
            public string note_current_status { get; set; }
            public string priority { get; set; }
        }

        public class Status
        {
            public int nothi_master_id { get; set; }
            public int total { get; set; }
            public int onishponno { get; set; }
            public int nishponno { get; set; }
            public int archived { get; set; }
            public int permitted { get; set; }
        }

        public class To
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

        public class Record
        {
            public Nothi nothi { get; set; }
            public To to { get; set; }
            public Desk desk { get; set; }
            public Status status { get; set; }
            public Basic basic { get; set; }
            public Mulpotro mulpotro { get; set; }
            public NoteOwner note_owner { get; set; }
            public NoteOnucched note_onucched { get; set; }
            public Potrojari potrojari { get; set; }

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
            public string created { get; set; }
            public string note_current_status { get; set; }
            public string priority { get; set; }
            public int note_count { get; set; }
            public string issue_date { get; set; }
            public string last_note_date { get; set; }
           
            public int nothi_master_id { get; set; }
            public int nothi_note_id { get; set; }
            public int nothi_office { get; set; }
            public int from_office_id { get; set; }
            public string from_office_name { get; set; }
            public int from_office_unit_id { get; set; }
            public string from_office_unit_name { get; set; }
            public int from_officer_id { get; set; }
            public string from_officer_name { get; set; }
            public int from_officer_designation_id { get; set; }
            public string from_officer_designation_label { get; set; }
            public int to_office_id { get; set; }
            public string to_office_name { get; set; }
            public int to_office_unit_id { get; set; }
            public string to_office_unit_name { get; set; }
            public int to_officer_id { get; set; }
            public string to_officer_name { get; set; }
            public int to_officer_designation_id { get; set; }
            public string to_officer_designation_label { get; set; }
            public int view_status { get; set; }
            public string note_decision { get; set; }
            public int movement_type { get; set; }
           
            public string modified { get; set; }
          
        }

        public class Data
        {
            public List<Record> records { get; set; }
            public int total_records { get; set; }
        }

            public string status { get; set; }
            public Data data { get; set; }
            public List<object> options { get; set; }


        public class Basic
        {
            public int id { get; set; }
            public int nothi_master_id { get; set; }
            public int nothi_note_id { get; set; }
            public int note_onucched_id { get; set; }
            public int dak_id { get; set; }
            public string dak_type { get; set; }
            public int is_copied_dak { get; set; }
            public int nothijato { get; set; }
            public int potrojari_id { get; set; }
            public string potro_media { get; set; }
            public int potro_pages { get; set; }
            public string subject { get; set; }
            public string sarok_no { get; set; }
            public string page_numbers { get; set; }
            public string due_date { get; set; }
            public string issue_date { get; set; }
            public string potro_content { get; set; }
            public string meta_data { get; set; }
            public int is_deleted { get; set; }
            public string application_origin { get; set; }
            public string application_meta_data { get; set; }
            public string created { get; set; }
            public string modified { get; set; }
            public string dak_json { get; set; }
            public string noter_potro_json { get; set; }
            public string note_json { get; set; }
            public int permitted { get; set; }
            public string last_update_date { get; set; }
            public string potro_subject { get; set; }
        }

        public class Mulpotro
        {
            public int id { get; set; }
            public int nothi_master_id { get; set; }
            public int nothi_note_id { get; set; }
            public int nothi_potro_id { get; set; }
            public int nothijato { get; set; }
            public int nothi_potro_page { get; set; }
            public string sarok_no { get; set; }
            public string attachment_type { get; set; }
            public string attachment_description { get; set; }
            public string file_name { get; set; }
            public string user_file_name { get; set; }
            public string file_dir { get; set; }
            public string potro_cover { get; set; }
            public string content_body { get; set; }
            public string meta_data { get; set; }
            public string application_origin { get; set; }
            public int is_main { get; set; }
            public int potrojari_id { get; set; }
            public string url { get; set; }
            public string download_url { get; set; }
            public string thumb_url { get; set; }
            public List<string> buttons { get; set; }
        }

        public class NoteOwner
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
            public int shared_nothi_count { get; set; }
        }

        public class NoteOnucched
        {
            public int id { get; set; }
            public int decision_id { get; set; }
            public string subject { get; set; }
            public string onucched_no { get; set; }
        }

        public class Receiver
        {
            public int id { get; set; }
            public string task_response { get; set; }
            public int potrojari_id { get; set; }
            public string potro_status { get; set; }
            public int is_sent { get; set; }
            public int group_id { get; set; }
            public string group_name { get; set; }
            public int group_member { get; set; }
            public string group_display { get; set; }
            public int office_id { get; set; }
            public string office { get; set; }
            public int office_unit_id { get; set; }
            public string office_unit { get; set; }
            public int officer_id { get; set; }
            public int designation_id { get; set; }
            public string designation { get; set; }
            public string officer { get; set; }
            public string officer_email { get; set; }
            public string visible_name { get; set; }
            public int office_head { get; set; }
            public string label { get; set; }
        }

        public class Onulipi
        {
            public int id { get; set; }
            public string task_response { get; set; }
            public int potrojari_id { get; set; }
            public string potro_status { get; set; }
            public int is_sent { get; set; }
            public int group_id { get; set; }
            public string group_name { get; set; }
            public int group_member { get; set; }
            public string group_display { get; set; }
            public int office_id { get; set; }
            public string office { get; set; }
            public int office_unit_id { get; set; }
            public string office_unit { get; set; }
            public int officer_id { get; set; }
            public int designation_id { get; set; }
            public string designation { get; set; }
            public string officer { get; set; }
            public string officer_email { get; set; }
            public string visible_name { get; set; }
            public int office_head { get; set; }
            public string label { get; set; }
        }

        public class Approver
        {
            public int id { get; set; }
            public int potrojari_id { get; set; }
            public string potro_status { get; set; }
            public int is_sent { get; set; }
            public int potro_type { get; set; }
            public string recipient_type { get; set; }
            public int office_id { get; set; }
            public string office { get; set; }
            public int office_unit_id { get; set; }
            public string office_unit { get; set; }
            public int officer_id { get; set; }
            public string officer { get; set; }
            public string officer_email { get; set; }
            public int designation_id { get; set; }
            public string designation { get; set; }
            public string visible_name { get; set; }
            public string visible_designation { get; set; }
            public string label { get; set; }
        }

        public class Attention
        {
            public int id { get; set; }
            public int potrojari_id { get; set; }
            public string potro_status { get; set; }
            public int is_sent { get; set; }
            public int potro_type { get; set; }
            public string recipient_type { get; set; }
            public int office_id { get; set; }
            public string office { get; set; }
            public int office_unit_id { get; set; }
            public string office_unit { get; set; }
            public int officer_id { get; set; }
            public string officer { get; set; }
            public string officer_email { get; set; }
            public int designation_id { get; set; }
            public string designation { get; set; }
            public string visible_name { get; set; }
            public string visible_designation { get; set; }
            public string label { get; set; }
        }

        public class Sender
        {
            public int id { get; set; }
            public int potrojari_id { get; set; }
            public string potro_status { get; set; }
            public int is_sent { get; set; }
            public int potro_type { get; set; }
            public string recipient_type { get; set; }
            public int office_id { get; set; }
            public string office { get; set; }
            public int office_unit_id { get; set; }
            public string office_unit { get; set; }
            public int officer_id { get; set; }
            public string officer { get; set; }
            public string officer_email { get; set; }
            public int designation_id { get; set; }
            public string designation { get; set; }
            public string visible_name { get; set; }
            public string visible_designation { get; set; }
            public string label { get; set; }
        }

        public class Recipient
        {
            public object drafter { get; set; }
            public object receiver { get; set; }
            public object onulipi { get; set; }
            public object approver { get; set; }
            public object attention { get; set; }
            public object sender { get; set; }
            public int sent_status { get; set; }
        }

        public class Potrojari
        {
            public int id { get; set; }
            public int nothi_master_id { get; set; }
            public int nothi_note_id { get; set; }
            public int note_onucched_id { get; set; }
            public int potro_type { get; set; }
            public string sarok_no { get; set; }
            public string potro_subject { get; set; }
            public Recipient recipient { get; set; }
        }


     

        


    }
}
