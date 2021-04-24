using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Services.NothiServices
{
  public  class PotrojariParameter
    {
        public PotrojariSendInfo potrojari { get; set; }
    }

    public class PotrojariSendInfo
    {
        public string id { get; set; }
        public string potro_type { get; set; }
        public string nothi_master_id { get; set; }
        public string nothi_note_id { get; set; }
        public string note_onucched_id { get; set; }
        public string nothi_potro_attachment_id { get; set; }
        public string nothi_potro_id { get; set; }
        public string dak_id { get; set; }
        public string attached_potro { get; set; }
        public string sarok_no { get; set; }
        public string potrojari_date { get; set; }
        public string potro_subject { get; set; }
        public string meta_data { get; set; }
        public string potro_status { get; set; }
        public string receiver_sent { get; set; }
        public string onulipi_sent { get; set; }
        public string is_summary_nothi { get; set; }
        public string digital_sign { get; set; }
        public string sign_info { get; set; }
        public string cloned_potrojari_id { get; set; }
        public string potrojari_internal { get; set; }
        public string potrojari_language { get; set; }
        public string draft_office_id { get; set; }
        public string draft_office_name { get; set; }
        public string draft_unit_id { get; set; }
        public string draft_unit_name { get; set; }
        public string draft_designation_id { get; set; }
        public string draft_designation_name { get; set; }
        public string draft_officer_id { get; set; }
        public string draft_officer_name { get; set; }
        public string shared_nothi_id { get; set; }
        public string noter_potro_json { get; set; }
        public string note_json { get; set; }
        public string attachment_count { get; set; }
        public string created { get; set; }
        public string modified { get; set; }
        public string page_numbers { get; set; }
        public string potro_pages { get; set; }
        public string dak_json { get; set; }
        public string last_update_date { get; set; }
        public string potro_description { get; set; }
        public string potro_cover { get; set; }
        public string orientation { get; set; }
        public string pageSize { get; set; }
        public string marginTop { get; set; }
        public string marginRight { get; set; }
        public string marginBottom { get; set; }
        public string marginLeft { get; set; }


       
        public string potro_security_level { get; set; }
        public string potro_priority_level { get; set; }
       
    }

}
