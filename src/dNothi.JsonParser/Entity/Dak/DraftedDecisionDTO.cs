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
        public Recipients recipients { get; set; }
    }
    public class MulPrapok
    {
        public string designation_bng { get; set; }
        public string designation_eng { get; set; }
        public string designation_id { get; set; }
        public string unit_name_bng { get; set; }
        public string unit_name_eng { get; set; }
        public string unit_id { get; set; }
        public string office_name_eng { get; set; }
        public string office_name_bng { get; set; }
        public string office_id { get; set; }
        public string employee_name_bng { get; set; }
        public string employee_name_eng { get; set; }
        public string employee_record_id { get; set; }
        public string incharge_label { get; set; }
    }

    public class  OnulipiPrapok    {
    public string designation_bng { get; set; }
    public string designation_eng { get; set; }
    public string designation_id { get; set; }
    public string unit_name_bng { get; set; }
    public string unit_name_eng { get; set; }
    public string unit_id { get; set; }
    public string office_name_eng { get; set; }
    public string office_name_bng { get; set; }
    public string office_id { get; set; }
    public string employee_name_bng { get; set; }
    public string employee_name_eng { get; set; }
    public string employee_record_id { get; set; }
    public string incharge_label { get; set; }
}

public class Onulipi
{
    public List<OnulipiPrapok> onulipiPrapoks { get; set; }

    
    }

    public class Recipients
{
    public MulPrapok mul_prapok { get; set; }
    public Onulipi onulipi { get; set; }
}


}
