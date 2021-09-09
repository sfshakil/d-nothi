using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Services.DakServices.DakReports
{
   public class DakReportModel
    {
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

        public class DakUser
        {
            public int id { get; set; }
            public string dak_type { get; set; }
            public int dak_id { get; set; }
            public int is_copied_dak { get; set; }
            public string dak_origin { get; set; }
            public int action_office_id { get; set; }
            public int from_potrojari { get; set; }
            public int to_office_id { get; set; }
            public string to_office_name { get; set; }
            public int to_office_unit_id { get; set; }
            public string to_office_unit_name { get; set; }
            public string to_office_address { get; set; }
            public int to_officer_id { get; set; }
            public string to_officer_name { get; set; }
            public int to_officer_designation_id { get; set; }
            public string to_officer_designation_label { get; set; }
            public int no_of_times_dak_received { get; set; }
            public string dak_view_status { get; set; }
            public string dak_priority { get; set; }
            public string dak_security { get; set; }
            public string attention_type { get; set; }
            public int dak_movement_sequence { get; set; }
            public int rollback_move_seq { get; set; }
            public string last_movement_date { get; set; }
            public int is_archive { get; set; }
            public int is_rollback_dak { get; set; }
            public string dak_category { get; set; }
            public int is_summary_nothi { get; set; }
            public int is_nisponno { get; set; }
            public int is_uploader { get; set; }
            public string created { get; set; }
            public string modified { get; set; }
            public string dak_subject { get; set; }
            public string dak_receipt_no { get; set; }
            public string docketing_no { get; set; }
            public string dak_decision { get; set; }
            public int drafted_by_designation_id { get; set; }
            public string drafted_decisions { get; set; }
            public int archived_dak_user_id { get; set; }
            public string action_status { get; set; }
            public string action_message { get; set; }
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

        public class Record
        {
            public MovementStatus movement_status { get; set; }
            public DakUser dak_user { get; set; }
            public DakOrigin dak_origin { get; set; }
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
