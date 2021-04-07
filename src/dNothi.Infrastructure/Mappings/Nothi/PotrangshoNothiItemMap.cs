using dNothi.Core.Entities;
using dNothi.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Infrastructure.Mappings.Nothi
{
    public class PotrangshoNothiItemMap : NothiEntityTypeConfiguration<PotrangshoNothiItem>
    {
        public PotrangshoNothiItemMap()
        {
            this.ToTable("PotrangshoNothiItem");
            this.HasKey(a => a.Id);
        }
    }
}
