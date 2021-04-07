using dNothi.Core.Entities;
using dNothi.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Infrastructure.Mappings.Nothi
{
    public class NothiNoteTalikaItemMap : NothiEntityTypeConfiguration<NothiNoteTalikaItem>
    {
        public NothiNoteTalikaItemMap()
        {
            this.ToTable("NothiNoteTalikaItem");
            this.HasKey(a => a.Id);
        }
    }
}
