using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Desktop.View_Model
{
  public  class ViewDesignationSealList
    {
        public int employee_record_id { get; set; }
        public int designation_id { get; set; }
        public string designation_bng { get; set; }
        public string unit_name_bng { get; set; }
        public string office_name_bng { get; set; }
        public string employee_name_bng { get; set; }



        public string designation { get
            {
                return designation_bng + "," + unit_name_bng +","+ office_name_bng;

            } 
        
        }
        public string designationwithname
        {
            get
            {
                return employee_name_bng+","+ designation_bng + "," + unit_name_bng + "," + office_name_bng;

            }

        }

        public bool nij_Office { get; set; }


        public bool mul_prapok { get; set; }
        public bool onulipi_prapok { get; set; }
    }
}
