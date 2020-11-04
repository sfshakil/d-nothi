
using dNothi.Core.Shared;

namespace dNothi.Core.Entities
{
    public class User : BaseEntity
    {
        public string username { get; set; }
        public string user_alias { get; set; }
        public bool active { get; set; }
        public int employee_record_id { get; set; }
    }
}
