using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Services.DakServices.DakSharingService.Model
{
  public  class DakBoxSharingParam
    {
        public int id { get; set; }
        public string dak_type { get; set; }
        public string dak_subject { get; set; }
        public string sender { get; set; }
        public string sending_date { get; set; }
        public string decision { get; set; }
        public string priority { get; set; }
        public string security { get; set; }
        public string recipients { get; set; }
        public int is_copied_dak { get; set; }
    }
}
