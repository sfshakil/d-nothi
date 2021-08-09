using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Services.PotroJariGroup.Models
{
   
    public class PotrojariGroupModel
    {
        public class Group
        {
            public int id { get; set; }
            public string group_name { get; set; }
            public string privacy_type { get; set; }
            public string group_value { get; set; }
            public int createdby_officer_id { get; set; }
            public string createdby_officer { get; set; }
            public int createdby_designation_id { get; set; }
            public int createdby_unit_id { get; set; }
            public int createdby_office_id { get; set; }
            public string createdby_designation { get; set; }
            public string createdby_office_unit { get; set; }
            public string createdby_office { get; set; }
            public int total_users { get; set; }
            public string created { get; set; }
            public string modified { get; set; }
        }
        public class OfficerInfo
        {
            
        }

        public class User
        {
            public int id { get; set; }
            public int rowId { get; set; }
            public int group_id { get; set; }
            public string group_name { get; set; }
            public int office_head { get; set; }
            public string privacy_type { get; set; }
            public int office_id { get; set; }
            public string office_eng { get; set; }
            public string office { get; set; }
            public int office_unit_id { get; set; }
            public string office_unit_eng { get; set; }
            public string office_unit { get; set; }
            public int designation_id { get; set; }
            public string designation_eng { get; set; }
            public string designation { get; set; }
            public int officer_id { get; set; }
            public string officer_eng { get; set; }
            public string officer { get; set; }
            public string officer_email { get; set; }
            public string officer_mobile { get; set; }
            public int createdby_officer_id { get; set; }
            public int createdby_designation_id { get; set; }
            public int createdby_unit_id { get; set; }
            public int createdby_office_id { get; set; }
            public string created { get; set; }
            public string modified { get; set; }
            public string incharge_label { get; set; }
            public int designation_level { get; set; }
            public int designation_sequence { get; set; }
            public bool isRemoved { get; set; }
        }

        public class Record
        {
            public Group group { get; set; }
            public List<User> users { get; set; }

            public int id { get; set; }
            public string office { get; set; }
            public int designation_id { get; set; }
            public int office_unit_id { get; set; }
            public string office_unit_eng { get; set; }
            public string office_unit { get; set; }
            public string designation_eng { get; set; }
            public string designation { get; set; }
            public string officer_email { get; set; }
            public int officer_id { get; set; }
            public string officer_mobile { get; set; }
            public string incharge_label { get; set; }
            public int designation_level { get; set; }
            public int designation_sequence { get; set; }
            public string office_eng { get; set; }
            public string officer { get; set; }
            public string created { get; set; }
            public string modified { get; set; }

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
