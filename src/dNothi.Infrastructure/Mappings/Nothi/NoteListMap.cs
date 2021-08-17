using dNothi.Core.Entities;
using dNothi.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Infrastructure.Mappings.Nothi
{
    public class NoteListMap : NothiEntityTypeConfiguration<NoteList>
    {
        public NoteListMap()
        {
            this.ToTable("NoteList");
            this.HasKey(a => a.Id);
        }
    }
}
