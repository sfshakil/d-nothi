using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.JsonParser.Entity.Dak_List_Inbox
{
    public class DakOriginDTO
    {
        [JsonProperty("id")]
        public int dak_origin_id { get; set; }
        public string name_eng { get; set; }
        public string name_bng { get; set; }
        public string sender_name { get; set; }
        public int receiving_office_id { get; set; }
        public string receiving_office_name { get; set; }
        public int receiving_office_unit_id { get; set; }
        public string receiving_office_unit_name { get; set; }
        public int receiving_officer_id { get; set; }
        public int receiving_officer_designation_id { get; set; }
        public string receiving_officer_designation_label { get; set; }
        public string receiving_officer_name { get; set; }
        public int docketing_no { get; set; }
        public string dak_received_no { get; set; }
        public string receiving_date { get; set; }
        public string sender_sarok_no { get; set; }
        public int sender_officer_id { get; set; }
        public string sender_office_name { get; set; }
        public int sender_office_unit_id { get; set; }
        public string sender_office_unit_name { get; set; }
        public int sender_officer_designation_id { get; set; }
        public string sender_officer_designation_label { get; set; }


        // Dak Details

       
        public string dak_subject { get; set; }
        public int dak_type_id { get; set; }
      
        public string dak_priority_level { get; set; }
        public string dak_security_level { get; set; }
       
        public int nothi_master_id { get; set; }
        public string dak_status { get; set; }
        public int uploader_designation_id { get; set; }
        public string application_origin { get; set; }
        public string created { get; set; }
        public string modified { get; set; }
     
        public int sender_office_id { get; set; }
     
        public string sending_date { get; set; }
        public string sender_address { get; set; }
        public string sender_email { get; set; }
        public string sender_phone { get; set; }
        public string sender_mobile { get; set; }
        public string dak_sending_media { get; set; }
        public string dak_cover { get; set; }
        public string dak_description { get; set; }
        public string meta_data { get; set; }
    
        public int is_summary_nothi { get; set; }
        public string previous_receipt_no { get; set; }
        public string previous_docketing_no { get; set; }
        public int is_rollback_to_dak { get; set; }
        public int from_potrojari { get; set; }
        public int potrojari_id { get; set; }
    }
}
