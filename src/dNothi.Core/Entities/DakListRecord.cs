using dNothi.Core.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Core.Entities
{
    public class DakListRecord: BaseEntity
    {
        [ForeignKey("dakUser")]
        public long dak_user_id { get; set; }
        [ForeignKey("dakOrigin")]
        public long dak_origin_id { get; set; }
        [ForeignKey("movementStatus")]
        public long movement_status_id { get; set; }
        public long attachment_count { get; set; }
        [ForeignKey("nothi")]
        public long nothi_id { get; set; }
        public virtual DakUser dakUser { get; set; }
        public virtual DakOrigin dakOrigin { get; set; }
        public MovementStatus movementStatus { get; set; }
        public virtual Nothi nothi { get; set; }
        public virtual ICollection<DakListRecordDakTag> dak_Tags { get; set; }
    }
}
