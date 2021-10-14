using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Services.BasicService.Models
{
    public class dakTrakingModel
    {
        public class DakUser
        {
            public int dak_id { get; set; }
            public string dak_type { get; set; }
            public int is_copied_dak { get; set; }
            public string dak_origin { get; set; }
            public int from_potrojari { get; set; }
            public string dak_view_status { get; set; }
            public string attention_type { get; set; }
            public string dak_priority { get; set; }
            public string dak_security { get; set; }
            public int dak_movement_sequence { get; set; }
            public string last_movement_date { get; set; }
            public string dak_category { get; set; }
            public string dak_subject { get; set; }
            public string dak_decision { get; set; }
            public string drafted_decisions { get; set; }
        }

        public class DakOrigin
        {
            public int id { get; set; }
            public int sender_officer_id { get; set; }
            public string sender_office_name { get; set; }
            public int sender_office_unit_id { get; set; }
            public string sender_office_unit_name { get; set; }
            public int sender_officer_designation_id { get; set; }
            public string sender_officer_designation_label { get; set; }
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
            public string sender_sarok_no { get; set; }
            public string receiving_date { get; set; }
            public string previous_receipt_no { get; set; }
            public string previous_docketing_no { get; set; }
            public int potro_type { get; set; }
            public string name_eng { get; set; }
            public string name_bng { get; set; }
        }

        public class Other
        {
            public string operation_type { get; set; }
            public string attention_type { get; set; }
            public string last_movement_date { get; set; }
            public int dak_priority { get; set; }
            public string dak_security_level { get; set; }
            public int sequence { get; set; }
            public string dak_actions { get; set; }
            public int docketing_no { get; set; }
            public int id { get; set; }
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
            public string attention_type { get; set; }
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
            public string attention_type { get; set; }
        }

        public class MovementStatus
        {
            public Other other { get; set; }
            public From from { get; set; }
            public List<To> to { get; set; }
        }

        public class DakTag
        {
            public int id { get; set; }
            public int dak_custom_label_id { get; set; }
            public int dak_id { get; set; }
            public string dak_type { get; set; }
            public int is_copied_dak { get; set; }
            public string tag { get; set; }
        }

        public class Nothi
        {
            public int? nothi_master_id { get; set; }
            public int? nothi_note_id { get; set; }
            public int? nothi_potro_id { get; set; }
            public int? dak_id { get; set; }
            public string dak_type { get; set; }
            public int? is_copied_dak { get; set; }
            public int? id { get; set; }
            public string nothi_no { get; set; }
            public string subject { get; set; }
            public int? office_id { get; set; }
            public string office_name { get; set; }
            public int? office_unit_id { get; set; }
            public string office_unit_name { get; set; }
        }

        public class Record
        {
            public DakUser dak_user { get; set; }
            public DakOrigin dak_origin { get; set; }
            public MovementStatus movement_status { get; set; }
            public List<DakTag> dak_tags { get; set; }
            public int attachment_count { get; set; }
            public Nothi nothi { get; set; }
        }

        public class Data
        {
            public List<Record> records { get; set; }
            public int total_records { get; set; }
        }

      
            public string status { get; set; }
            public Data data { get; set; }
            public List<object> options { get; set; }
      


    }
}
