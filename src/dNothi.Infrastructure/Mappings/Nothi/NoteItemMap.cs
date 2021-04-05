using dNothi.Core.Entities;
using dNothi.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Infrastructure.Mappings.Nothi
{
    public class NoteItemMap : NothiEntityTypeConfiguration<NoteItem>
    {
        public NoteItemMap()
        {
            this.ToTable("NoteItem");
            this.HasKey(a => a.Id);
        }
    }
}
