using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Services.DakServices
{
  public  class DakSearchParam
    {
        public string dak_subject { get; set; }
        public string dak_security { get; set; }
        public string dak_priority { get; set; }
        public string dak_type { get; set; }
        public string dak_receipt_no { get; set; }
        public string docketing_no { get; set; }
        public string last_modified_date { get; set; }
        public string potro_type { get; set; }
        public string dak_view_status { get; set; }
        public string sender_officer_id { get; set; }
        public string sender_officer_name { get; set; }
        public string sender_office_name { get; set; }
        public string sender_office_id { get; set; }
        public string to_officer_id { get; set; }
        public string to_office_id { get; set; }
    }
}
