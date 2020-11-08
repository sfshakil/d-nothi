using dNothi.Core.Shared;
using System;
using System.ComponentModel.DataAnnotations;

namespace dNothi.Core.Entities
{
    public class OfficeInfo : BaseEntity
    {
        public int employee_record_id { get; set; }
        public int office_id { get; set; }
        public int office_unit_id { get; set; }
        public int office_unit_organogram_id { get; set; }
        [StringLength(500)]
        public string designation { get; set; }
        public int designation_level { get; set; }
        public int designation_sequence { get; set; }
        public int office_head { get; set; }
        [StringLength(500)]
        public string incharge_label { get; set; }
        public DateTime joining_date { get; set; }
        public object last_office_date { get; set; }
        public bool status { get; set; }
        public int show_unit { get; set; }
        [StringLength(500)]
        public string designation_en { get; set; }
        [StringLength(500)]
        public string unit_name_bn { get; set; }
        [StringLength(500)]
        public string office_name_bn { get; set; }
        [StringLength(500)]
        public string unit_name_en { get; set; }
        [StringLength(500)]
        public string office_name_en { get; set; }
        public int protikolpo_status { get; set; }
        [StringLength(500)]
        public string domain { get; set; }
        public bool is_admin { get; set; }
    }
}
