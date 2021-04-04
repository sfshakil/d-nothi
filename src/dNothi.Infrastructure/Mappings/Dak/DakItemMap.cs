using dNothi.Core.Entities;
using dNothi.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Infrastructure.Mappings.Dak
{
  public  class DakItemMap : NothiEntityTypeConfiguration<DakItem>
    {
        public DakItemMap()
        {
            this.ToTable("DakItem");
            this.HasKey(a => a.Id);
        }
    }
}
