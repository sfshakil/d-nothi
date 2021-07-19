using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Services.NothiReportService.Model
{
    public class NothiRegisterReport
    {
        public class Nothi
        {
            public int id { get; set; }
            public int office_id { get; set; }
            public string office_name { get; set; }
            public int office_unit_id { get; set; }
            public string office_unit_name { get; set; }
            public int office_unit_organogram_id { get; set; }
            public string office_designation_name { get; set; }
            public string nothi_no { get; set; }
            public string subject { get; set; }
            public int nothi_class { get; set; }
            public string modified { get; set; }
            public string last_note_date { get; set; }
        }

        public class Desk
        {
            public int nothi_master_id { get; set; }
            public string issue_date { get; set; }
            public int note_count { get; set; }
            public string note_current_status { get; set; }
            public string priority { get; set; }
        }

        public class Status
        {
            public int nothi_master_id { get; set; }
            public int total { get; set; }
            public int onishponno { get; set; }
            public int nishponno { get; set; }
            public int archived { get; set; }
            public int permitted { get; set; }
        }

        public class Record
        {
            public Nothi nothi { get; set; }
            public Desk desk { get; set; }
            public Status status { get; set; }
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
