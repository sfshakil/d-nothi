using dNothi.Core.Shared;
using System;

namespace dNothi.Core.Entities
{
    public class EmployeeInfo : BaseEntity
    {
        public string name_eng { get; set; }
        public string name_bng { get; set; }
        public string father_name_eng { get; set; }
        public string father_name_bng { get; set; }
        public string mother_name_eng { get; set; }
        public string mother_name_bng { get; set; }
        public DateTime date_of_birth { get; set; }
        public string nid { get; set; }
        public string bcn { get; set; }
        public string ppn { get; set; }
        public string personal_email { get; set; }
        public string personal_mobile { get; set; }
        public int is_cadre { get; set; }
        public object joining_date { get; set; }
        public int default_sign { get; set; }
    }
}
