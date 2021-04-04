using dNothi.Core.Entities;
using dNothi.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Infrastructure.Mappings.Nothi
{
    class NothiItemMap : NothiEntityTypeConfiguration<NothiItem>
    {
        public NothiItemMap()
        {
            this.ToTable("NothiItem");
            this.HasKey(a => a.Id);
        }
    }
}
