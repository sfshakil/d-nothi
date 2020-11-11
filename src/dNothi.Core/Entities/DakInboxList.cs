using dNothi.Core.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nothi.Core.Entities
{
   public class DakInboxList: BaseEntity
    {
        public int dak_tagsid { get; set; }
        [ForeignKey("dak_tagsid")]
        public virtual DakTag Dak_Tags { get; set; }
    }
}
