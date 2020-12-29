using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace dNothi.Services.DakServices
{
   public class DakForwardRequestParam
    {
        public string token;

        public string dak_type { get; set; }
        public int dak_id { get; set; }
        public int priority { get; set; }
        public string comment { get; set; }
        public int security { get; set; }
        public int is_copied_dak { get; set; }
        public string sender_info { get; set; }
        public string CSharpObjtoJson(object obj)
        {

            var jsonString = new JavaScriptSerializer().Serialize(obj);
            return jsonString;
        }


        public string receiver_info { get; set; }



        public string onulipi_info { get; set; }

    }

    public class DakForwardRequestSenderInfo {

       
        public string designation_label { get; set; }
        public string unit_label { get; set; }
        public string office_label { get; set; }
        public string officer_name { get; set; }
        public string incharge_label { get; set; }
        public int employee_record_id { get; set; }


        public int designation_id { get; set; }
        public int unit_id { get; set; }


        public int office_id { get; set; }
        public string office_name
        { get
            {
                return office_label;
            }
                
                }
        
        public int office_unit_id
        { get
            {
                return unit_id;
            }
                
                }
        
        public string office_unit
        { get
            {
                return unit_label;
            }
                
                
        }
        public int officer_id
        { get
            {
                return employee_record_id;
            }
                
                
        }
         public string designation
        { get
            {
                return designation_label;
            }
                
                
        }
        

    }

}
