using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.JsonParser.Entity.Dak
{
    public class DraftedDecisionDTO
    {
        public string id { get; set; }
        public string dak_type { get; set; }
        public string is_copied_dak { get; set; }
        public string dak_subject { get; set; }
        public string sender { get; set; }
        public string sending_date { get; set; }
        public string decision { get; set; }
        public string priority { get; set; }
        public string security { get; set; }

        public int dak_inbox_designation_id { get; set; }

        public RecipientsInfoDTO recipients { get; set; }
    }
    public class MulPrapok
    {
        public int dak_id { get; set; }
        public int to_officer_designation_id { get; set; }
        public object dak_type { get; set; }
        public string designation_bng { get; set; }
        public string designation_eng { get; set; }
        public int designation_id { get; set; }
        public string unit_name_bng { get; set; }
        public string unit_name_eng { get; set; }
        public int unit_id { get; set; }
        public object office_eng { get; set; }
        public string office_name_bng { get; set; }
        public int office_id { get; set; }
        public string employee_name_bng { get; set; }
        public string officer_eng { get; set; }
        public int employee_record_id { get; set; }
        public string incharge_label { get; set; }
        public string designation_label { get; set; }
        public string unit_label { get; set; }
        public string office_label { get; set; }
        public string officer_name { get; set; }
        public int officer_id { get; set; }
        public string office_name { get; set; }
        public string office_unit { get; set; }
        public string designation { get; set; }
        public object office_name_eng { get; set; }
        public int office_ministry_id { get; set; }
        public string ministry_eng { get; set; }
        public string ministry_bng { get; set; }
        public int office_layer_id { get; set; }
        public string layer_name_eng { get; set; }
        public string layer_name_bng { get; set; }
        public int office_origin_id { get; set; }
        public string office_origin_eng { get; set; }
        public string office_origin_bng { get; set; }
        public string office_bng { get; set; }
        public string office_address { get; set; }
        public int office_unit_id { get; set; }
        public string office_unit_bng { get; set; }
        public string office_unit_eng { get; set; }
        public string office_unit_code { get; set; }
        public string unit_level { get; set; }
        public string nothi_code { get; set; }
        public string sarok_no_start { get; set; }
        public int superior_unit_id { get; set; }
        public string superior_office_unit_eng { get; set; }
        public string superior_office_unit_bng { get; set; }
        public string short_name_eng { get; set; }
        public string short_name_bng { get; set; }
        public int designation_level { get; set; }
        public int designation_sequence { get; set; }
        public string designation_description { get; set; }
        public int superior_designation_id { get; set; }
        public string officer_bng { get; set; }
        public string gender { get; set; }
        public string personal_mobile { get; set; }
        public string personal_email { get; set; }
        public int is_cadre { get; set; }
        public string date_of_birth { get; set; }
        public string employee_id { get; set; }
        public bool status { get; set; }
        public string is_admin { get; set; }
        public string is_front_desk { get; set; }
        public string is_office_head { get; set; }
        public string unitWithCode { get; set; }
        public string NameWithDesignation { get; set; }
        public string NameWithOrganogram { get; set; }
        public string office { get; set; }
        public string officer { get; set; }
        public bool isofficerAdded { get; set; }
    }

    public class  OnulipiPrapok    {
        public int dak_id { get; set; }
        public int to_officer_designation_id { get; set; }
        public object dak_type { get; set; }
        public string designation_bng { get; set; }
        public string designation_eng { get; set; }
        public int designation_id { get; set; }
        public string unit_name_bng { get; set; }
        public string unit_name_eng { get; set; }
        public int unit_id { get; set; }
        public object office_eng { get; set; }
        public string office_name_bng { get; set; }
        public int office_id { get; set; }
        public string employee_name_bng { get; set; }
        public string officer_eng { get; set; }
        public int employee_record_id { get; set; }
        public string incharge_label { get; set; }
        public string designation_label { get; set; }
        public string unit_label { get; set; }
        public string office_label { get; set; }
        public string officer_name { get; set; }
        public int officer_id { get; set; }
        public string office_name { get; set; }
        public string office_unit { get; set; }
        public string designation { get; set; }
        public object office_name_eng { get; set; }
        public int office_ministry_id { get; set; }
        public string ministry_eng { get; set; }
        public string ministry_bng { get; set; }
        public int office_layer_id { get; set; }
        public string layer_name_eng { get; set; }
        public string layer_name_bng { get; set; }
        public int office_origin_id { get; set; }
        public string office_origin_eng { get; set; }
        public string office_origin_bng { get; set; }
        public string office_bng { get; set; }
        public string office_address { get; set; }
        public int office_unit_id { get; set; }
        public string office_unit_bng { get; set; }
        public string office_unit_eng { get; set; }
        public string office_unit_code { get; set; }
        public string unit_level { get; set; }
        public string nothi_code { get; set; }
        public string sarok_no_start { get; set; }
        public int superior_unit_id { get; set; }
        public string superior_office_unit_eng { get; set; }
        public string superior_office_unit_bng { get; set; }
        public string short_name_eng { get; set; }
        public string short_name_bng { get; set; }
        public int designation_level { get; set; }
        public int designation_sequence { get; set; }
        public string designation_description { get; set; }
        public int superior_designation_id { get; set; }
        public string officer_bng { get; set; }
        public string gender { get; set; }
        public string personal_mobile { get; set; }
        public string personal_email { get; set; }
        public int is_cadre { get; set; }
        public string date_of_birth { get; set; }
        public string employee_id { get; set; }
        public bool status { get; set; }
        public string is_admin { get; set; }
        public string is_front_desk { get; set; }
        public string is_office_head { get; set; }
        public string unitWithCode { get; set; }
        public string NameWithDesignation { get; set; }
        public string NameWithOrganogram { get; set; }
        public string office { get; set; }
        public string officer { get; set; }
        public bool isofficerAdded { get; set; }
    }



    public class RecipientsInfoDTO
    {
    public OnulipiPrapok mul_prapok { get; set; }
    public object  onulipi { get; set; }


     public Dictionary<string, OnulipiPrapok> onulipiDTO { 
            get
            {
                try
                {
                   return JsonConvert.DeserializeObject<Dictionary<string, OnulipiPrapok>>(onulipi.ToString());

                }
                catch
                {
                    return null;
                }
            }
                
               
        }
   
    
    }


}
