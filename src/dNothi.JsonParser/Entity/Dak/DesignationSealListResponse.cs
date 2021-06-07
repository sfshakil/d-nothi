using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.JsonParser.Entity.Dak
{
    public class OfficeListResponse
    {
        public string status { get; set; }
        public Dictionary<string,List<OfficeInfoDTO>> data { get; set; }
        
    }
    public class OfficeDTO
    {
       
        public List<OfficeInfoDTO> officeInfos { get; set; }
    }
//    public class OfficeDakInfoDTO{
//    public int id { get; set; }
//    public string office_name_eng { get; set; }
//    public string office_name_bng { get; set; }
//    public int parent_office_id { get; set; }
//}

public class DesignationSealListResponse
    {
        public string status { get; set; }
        public DesignationSealDataDTO data { get; set; }
    }

    public class PrapokDTO
    {

     
        public int dak_id { get; set; }
        public int to_officer_designation_id { get { return designation_id; } set{ designation_id = value; } }
        public string dak_type { get; set; }
        public string designation_bng { get; set; }
        public string designation_eng { get; set; }
        public int designation_id { get; set; }
      
     
        public string unit_name_bng {
            get
            {
                return office_unit_bng;
            }

            set
            {
                office_unit_bng = value;
            }
                }

     
        public string unit_name_eng {
            get
            {
                return office_unit_eng;
            }


        }

        public int unit_id { get { return office_unit_id; } }

        public string office_eng { get { return office_name_eng; } }

       
   
        public string office_name_bng { get { return office_bng; } }
     
        public int office_id { get; set; }

      
        public string employee_name_bng { get { return officer_bng; } set { officer_bng = value; } }

 
        public string officer_eng { get; set; }


        [JsonProperty("id")]
        public int employee_record_id { get; set; }
        public string incharge_label { get; set; }


        public string designation_label
        {
            get
            {
                return designation_bng;
            }
        }
        public string unit_label
        {
            get
            {
                return unit_name_bng;
            }
            set {
                unit_name_bng = value;
            }
        }
        public string office_label
        {
            get
            {
                return office_name_bng;
            }
        }
        
        public string officer_name
        {
            get
            {
                return employee_name_bng;
            }
            set
            {
                employee_name_bng = value;
            }
        }
         public int officer_id { get; set; }
     

           public string office_name
        {
            get
            {
                return office_label;
            }
        }
        
        public string office_unit
        {
            get
            {
                return unit_label;
            }
            set
            {
                unit_label = value;
            }
        }


         public string designation
        {
            get
            {
                return designation_label;
            }
        }

        public string office_name_eng { get; set; }






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
        public int? superior_designation_id { get; set; }
     
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

        public string unitWithCode { get { return unit_label + " শাখা কোডঃ " + string.Concat(office_unit_code.ToString().Select(c => (char)('\u09E6' + c - '0'))); } }
        public string NameWithDesignation { get { return employee_name_bng + " " + designation_bng; } }
        public string NameWithOrganogram { get { return employee_name_bng + ", " + designation_bng + ", " + unit_name_bng + ", " + office_bng; } }




        public string office { get { return office_bng; } set { office_bng = value; } }
        public string officer { get { return officer_bng; } set { officer_bng = value; } }
      


        public bool isofficerAdded { get; set; }









    }



    public class DesignationSealDataDTO
    {
        public List<PrapokDTO> own_office { get; set; }
        public List<PrapokDTO> other_office { get; set; }
    }

    public class AllDesignationSealListResponse
    {
        public string status { get; set; }
        public List<PrapokDTO> data { get; set; }
    }


}
