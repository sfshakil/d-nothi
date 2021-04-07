using dNothi.Core.Entities;
using dNothi.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Infrastructure.Mappings.Nothi
{
    public class PotrangshoNoteItemMap : NothiEntityTypeConfiguration<PotrangshoNoteItem>
    {
        public PotrangshoNoteItemMap()
        {
            this.ToTable("PotrangshoNoteItem");
            this.HasKey(a => a.Id);
        }
    }
}
