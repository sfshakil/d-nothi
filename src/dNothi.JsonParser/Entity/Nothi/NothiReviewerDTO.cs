using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.JsonParser.Entity.Nothi
{
    public class NothiReviewerDTO
    {
        public Nothi nothi { get; set; }
        public List<User> users { get; set; }
    }
    public class Nothi
    {
        public int id { get; set; }
        public string shared_status { get; set; }
    }

    public class User
    {
        public string recipient_type { get; set; }
        public string sms_message { get; set; }
        public string group_id { get; set; }
        public string group_name { get; set; }
        public string group_member { get; set; }
        public string group_display { get; set; }
        public string office_id { get; set; }
        public string office_unit_id { get; set; }
        public string designation_id { get; set; }
        public string officer_id { get; set; }
        public string office { get; set; }
        public string office_unit { get; set; }
        public string designation { get; set; }
        public string officer { get; set; }
        public string officer_email { get; set; }
        public string officer_mobile { get; set; }
        public string review_mode { get; set; }
        public string user_id { get; set; }
        public string designation_level { get; set; }
        public string designation_sequence { get; set; }
    }
}
