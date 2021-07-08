using System;

namespace dNothi.JsonParser.Entity
{
    public class OfficeInfoDTO
    {
        public int id { get; set; }
        public int employee_record_id { get; set; }
        public int office_id { get; set; }
        public int office_unit_id { get; set; }
        public int office_unit_organogram_id { get; set; }
        public string designation { get; set; }
        public int designation_level { get; set; }
        public int designation_sequence { get; set; }
        public int office_head { get; set; }
        public string incharge_label { get; set; }
        public string joining_date { get; set; }
        public object last_office_date { get; set; }
        public bool status { get; set; }
        public int show_unit { get; set; }
        public string designation_en { get; set; }
        public string unit_name_bn { get; set; }
        public string office_name_bn { get; set; }
        public string unit_name_en { get; set; }
        public string office_name_en { get; set; }
        public int protikolpo_status { get; set; }
        public string domain { get; set; }
        public string is_admin { get; set; }
          public string office_name_eng { get; set; }
          public string office_name_bng { get; set; }
          public int parent_office_id { get; set; }
          public int dakCount { get; set; }
          public int nothiCount { get; set; }


        public string front_domain { get; set; }
        public int version { get; set; }
        public bool sync_required { get; set; }
        public int designation_id { get; set; }


        public string is_front_desk { get; set; }
        public string is_office_unit_admin { get; set; }
        public string is_office_head { get; set; }
        public string is_office_unit_head { get; set; }




    }
}
