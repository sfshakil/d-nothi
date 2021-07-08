using dNothi.Core.Shared;
using System;
using System.ComponentModel.DataAnnotations;

namespace dNothi.Core.Entities
{
    public class EmployeeInfo : BaseEntity
    {
        public int emp_id { get; set; }

        [StringLength(500)]
        public string name_eng { get; set; }
        [StringLength(500)]
        public string name_bng { get; set; }
        [StringLength(500)]
        public string father_name_eng { get; set; }
        [StringLength(500)]
        public string father_name_bng { get; set; }
        [StringLength(500)]
        public string mother_name_eng { get; set; }
        [StringLength(500)]
        public string mother_name_bng { get; set; }
        public DateTime date_of_birth { get; set; }
        [StringLength(50)]
        public string nid { get; set; }
        [StringLength(500)]
        public string bcn { get; set; }
        [StringLength(500)]
        public string ppn { get; set; }
        [StringLength(500)]
        public string personal_email { get; set; }
        [StringLength(50)]
        public string personal_mobile { get; set; }
        public int is_cadre { get; set; }
        public string joining_date { get; set; }
        public int default_sign { get; set; }
    }
}
