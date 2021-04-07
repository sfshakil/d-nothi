using dNothi.Core.Entities;
using dNothi.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Infrastructure.Mappings.Nothi
{
    public class NoteInboxSentAllItemMap : NothiEntityTypeConfiguration<NoteInboxSentAllItem>
    {
        public NoteInboxSentAllItemMap()
        {
            this.ToTable("NoteInboxSentAllItem");
            this.HasKey(a => a.Id);
        }
    }
}
