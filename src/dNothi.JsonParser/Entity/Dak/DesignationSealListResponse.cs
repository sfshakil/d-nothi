using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.JsonParser.Entity.Dak
{
   public class DesignationSealListResponse
    {
        public string status { get; set; }
        public DesignationSealDataDTO data { get; set; }
    }
    public class PrapokDTO
    {


        public string designation_bng { get; set; }
        public string designation_eng { get; set; }
        public int designation_id { get; set; }
        public string unit_name_bng { get; set; }
        public string unit_name_eng { get; set; }
        public int unit_id { get; set; }
        public string office_name_eng { get; set; }
        public string office_name_bng { get; set; }
        public int office_id { get; set; }
        public string employee_name_bng { get; set; }
        public string employee_name_eng { get; set; }
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
        }
    }

  

    public class DesignationSealDataDTO
    {
        public List<PrapokDTO> own_office { get; set; }
        public List<PrapokDTO> other_office { get; set; }
    }

  


}
