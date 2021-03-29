using dNothi.Core.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Core.Entities
{
    public class DakList: BaseEntity
    {
        [ForeignKey("dak_user")]
        public long? dak_user_id { get; set; }
        public virtual DakUser dak_user { get; set; }


        [ForeignKey("dak_origin")]
        public long? dak_origin_id { get; set; }
        public virtual DakOrigin dak_origin { get; set; }


        [ForeignKey("movement_status")]
        public long? movement_status_id { get; set; }
        public virtual MovementStatus movement_status { get; set; }



        public int attachment_count { get; set; }

     
        
        [ForeignKey("nothi")]
        public long? dak_nothi_id { get; set; }

        public virtual DakNothi nothi { get; set; }

      

        [ForeignKey("daklistType")]
        public long? dak_List_type_Id { get; set; }
        public virtual DakType daklistType { get; set; }


        public virtual ICollection<DakTag> dak_Tags { get; set; }
        public virtual ICollection<DakAttachment> attachment { get; set; }


        

    }
}
