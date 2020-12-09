using dNothi.Infrastructure.Mapping;
using dNothi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Infrastructure.Mappings.Dak
{
    class DakUserMap : NothiEntityTypeConfiguration<DakUser>
    {
        public DakUserMap()
        {
            this.ToTable("DakUser");
            this.HasKey(a => a.Id);
        }
    }
}
