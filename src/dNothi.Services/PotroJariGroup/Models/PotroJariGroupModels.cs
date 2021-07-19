using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Services.PotroJariGroup.Models
{
    public class PotroJariGroupModels
    {
        public class User
        {
            public string id { get; set; }
            //public string group_id { get; set; }
            //public string group_name { get; set; }
           // public string office_head { get; set; }
           // public string privacy_type { get; set; }
            public string office_id { get; set; }
            public string office_eng { get; set; }
            public string office { get; set; }
            public string office_unit_id { get; set; }
            public string office_unit_eng { get; set; }
            public string office_unit { get; set; }
            public string designation_id { get; set; }
            public string designation_eng { get; set; }
            public string designation { get; set; }
            public string officer_id { get; set; }
            public string officer_eng { get; set; }
            public string officer { get; set; }
            public string officer_email { get; set; }
            public string officer_mobile { get; set; }
            //public string createdby_officer_id { get; set; }
            //public string createdby_designation_id { get; set; }
            //public string createdby_unit_id { get; set; }
            //public string createdby_office_id { get; set; }
            //public string created { get; set; }
            //public string modified { get; set; }
            //public string incharge_label { get; set; }
            public string designation_level { get; set; }
            public string designation_sequence { get; set; }


            // officer,designation_id,designation,office_unit_id,office_unit,office_id,office,officer_email,officer_mobile,designation_sequence,designation_level,id

        }

        public class Data
        {
            public string status { get; set; }
            public string data { get; set; }
            public List<object> options { get; set; }
        }

      
            public string status { get; set; }
            public Data data { get; set; }
            public List<object> options { get; set; }
        

    }
}
