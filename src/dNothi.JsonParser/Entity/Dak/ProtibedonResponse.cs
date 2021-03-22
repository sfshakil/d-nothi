using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.JsonParser.Entity.Dak
{
   public class ProtibedonResponse
    {
        public string status { get; set; }
        public ProtibedonResponseDataDTO data { get; set; }
    }

    public class ProtibedonResponseRecordDTO
    {
        public string to_office_unit_name { get; set; }
        public int to_office_unit_id { get; set; }
        public string dak_category { get; set; }
        public string movecreated { get; set; }
        public string dak_priority { get; set; }
        public string sender_sarok_no { get; set; }
        public string sender_office_name { get; set; }
        public string sender_office_unit_name { get; set; }
        public string sender_officer_designation_label { get; set; }
        public string sender_name { get; set; }
        public string dakcreted { get; set; }
        public string dak_received_no { get; set; }
        public int docketing_no { get; set; }
        public string dak_subject { get; set; }
        public string dak_security_level { get; set; }
        public string receiving_office_unit_name { get; set; }
        public string receiving_officer_designation_label { get; set; }
        public string receiving_officer_name { get; set; }
        public string last_status_officer_name { get; set; }
        public string last_status_officer_designation_label { get; set; }
        public string last_status_office_unit_name { get; set; }
        public string pending_time { get; set; }
    }

    public class ProtibedonResponseDataDTO
    {
        public List<ProtibedonResponseRecordDTO> records { get; set; }
        public int total_records { get; set; }
    }

   
}
