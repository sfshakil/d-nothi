using dNothi.JsonParser.Entity.Dak;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.JsonParser.Entity.Dak_List_Inbox
{
    public class DakUserDTO
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

        public DraftedDecisionDTO draftedDecisionDTO { get
            {
                try
                {

                    DraftedDecisionDTO draftedDecisionDTO = JsonConvert.DeserializeObject<DraftedDecisionDTO>(drafted_decisions);
                    return draftedDecisionDTO;
                }
                catch (Exception Ex)
                {
                   return null;
                }
            }



        }



        [JsonProperty("id")]
        public int dak_user_id { get; set; }
        
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
      
        public int rollback_move_seq { get; set; }
    
        public int is_archive { get; set; }
        public int is_rollback_dak { get; set; }
     
        public int is_summary_nothi { get; set; }
        public int is_nisponno { get; set; }
        public string created { get; set; }
        public string modified { get; set; }
     
        public string dak_receipt_no { get; set; }
        public int? docketing_no { get; set; }
    
        public int drafted_by_designation_id { get; set; }
      
        public int archived_dak_user_id { get; set; }
    }
}
