
using dNothi.Core.Shared;
using System.ComponentModel.DataAnnotations;

namespace dNothi.Core.Entities
{
    public class User : BaseEntity
    {
        [StringLength(500)]
        public string username { get; set; }
        [StringLength(500)]
        public string user_alias { get; set; }
        public bool active { get; set; }
        public int employee_record_id { get; set; }
    }
}
