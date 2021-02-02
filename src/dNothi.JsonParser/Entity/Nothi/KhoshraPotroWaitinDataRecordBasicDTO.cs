using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.JsonParser.Entity.Nothi
{
    public class KhoshraPotroWaitinDataRecordBasicDTO
    {
        public int id { get; set; }
        public int potro_type { get; set; }
        public int nothi_master_id { get; set; }
        public int nothi_note_id { get; set; }
        public int note_onucched_id { get; set; }
        public int nothi_potro_attachment_id { get; set; }
        public int nothi_potro_id { get; set; }
        public int dak_id { get; set; }
        public string is_endorsed { get; set; }
        public string sarok_no { get; set; }
        public string potrojari_date { get; set; }
        public string potro_subject { get; set; }
        public string potro_security_level { get; set; }
        public string potro_priority_level { get; set; }
        public string meta_data { get; set; }
        public string potro_status { get; set; }
        public int receiver_sent { get; set; }
        public int onulipi_sent { get; set; }
        public int is_summary_nothi { get; set; }
        public int digital_sign { get; set; }
        public string sign_info { get; set; }
        public int cloned_potrojari_id { get; set; }
        public int potrojari_internal { get; set; }
        public string potrojari_language { get; set; }
        public int draft_office_id { get; set; }
        public string draft_office_name { get; set; }
        public int draft_unit_id { get; set; }
        public string draft_unit_name { get; set; }
        public int draft_designation_id { get; set; }
        public string draft_designation_name { get; set; }
        public int draft_officer_id { get; set; }
        public string draft_officer_name { get; set; }
        public int shared_nothi_id { get; set; }
        public string noter_potro_json { get; set; }
        public string note_json { get; set; }
        public int attachment_count { get; set; }
        public string created { get; set; }
        public string modified { get; set; }
        public string page_numbers { get; set; }
        public int potro_pages { get; set; }
        public string dak_json { get; set; }
        public string last_update_date { get; set; }
    }
}
