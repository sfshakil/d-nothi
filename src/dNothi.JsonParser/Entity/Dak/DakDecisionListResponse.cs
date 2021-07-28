using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.JsonParser.Entity.Dak
{
   public class DakDecisionDTO
    {
        public int id { get; set; }
        public string dak_decision { get; set; }
        public int status { get; set; }
        public int dak_decision_employee { get; set; }
        public int dak_decision_id { get; set; }
        

    }

    public class DakDecisionDataDTO
    {
        public int id { get; set; }
        public string dak_decision { get; set; }
        public int status { get; set; }
        public int dak_decision_employee { get; set; }
        public int dak_decision_id { get; set; }


    }

    public class DakDecisionListResponse
    {
        public string status { get; set; }
        public List<DakDecisionDTO> data { get; set; }
    }

}
