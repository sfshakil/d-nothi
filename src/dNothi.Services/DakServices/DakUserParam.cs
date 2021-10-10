using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace dNothi.Services.DakServices
{
    public class DakUserParam
    {
        public string loginId { get; set; }
        public string userName { get; set; }

        public string fatherName { get; set; }
        public string motherName { get; set; }
        public string nationalId { get; set; }
        public string birthCertificate { get; set; }
        public string joiningDate { get; set; }

        public string token { get; set; }
        public string designation_label { get; set; }
        public string unit_label { get; set; }
        public string office_label { get; set; }
        public string officer_name { get; set; }
        public string incharge_label { get; set; }

        public int employee_record_id { get; set; }
        public string SignBase64 { get; set; }
        public string profile_photo { get; set; }


        public int designation_id { get; set; }
        public int unit_id { get; set; }
     
      
        public int office_id { get; set; }
        public int user_id { get; set; }
        public string api { get; set; }
        public int page { get; set; }
        public int limit { get; set; }
        public int office_unit_id { get { return unit_id; } }
        public int officer_id { get { return employee_record_id; } }
        public string office { get { return office_label; } }
        public string office_unit { get { return unit_label; } }
        public string designation { get { return designation_label; } }
        public string officer { get { return officer_name; } }
        public int designation_level { get; set; }
        public string officer_email { get; set; }
        public string officer_mobile { get; set; }


        public string  json_String { get; set; }
        public int CategoryId { get; set; }
        public string NameSearchParam { get; set; }
        public string DateofBirth { get; internal set; }
        public string doptor_token { get;  set; }
        public string nothi_type_name { get;  set; }
    }
}
