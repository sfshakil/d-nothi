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
        public long? dak_user_id { get; set; }
        [ForeignKey("dakOrigin")]
        public long? dak_origin_id { get; set; }
        [ForeignKey("movementStatus")]
        public long? movement_status_id { get; set; }
        public long attachment_count { get; set; }

        [ForeignKey("dakNothi")]
        public long? dak_nothi_id { get; set; }

        public virtual DakNothi dakNothi { get; set; }
        //[ForeignKey("nothi")]
        //public long? dak_nothi_Id { get; set; }
        public virtual DakUser dakUser { get; set; }
        public virtual DakOrigin dakOrigin { get; set; }
        public virtual MovementStatus movementStatus { get; set; }
        //public virtual DakNothi nothi { get; set; }
        public virtual ICollection<DakListRecordDakTag> dak_Tags { get; set; }
        public virtual ICollection<DakListDakListRecord> dak_List { get; set; }
    }
}
