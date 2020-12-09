using dNothi.Core.Entities;
using dNothi.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Infrastructure.Mappings.Dak
{
  public  class DakListMap : NothiEntityTypeConfiguration<DakList>
    {
        public DakListMap()
        {
            this.ToTable("DakList");
            this.HasKey(a => a.Id);
        }
    }
}
