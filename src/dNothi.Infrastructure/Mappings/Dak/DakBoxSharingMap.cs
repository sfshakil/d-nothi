using dNothi.Core.Entities;
using dNothi.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Infrastructure.Mappings.Dak
{
   public class DakBoxSharingMap : NothiEntityTypeConfiguration<DakBoxSharing>
    {
        public DakBoxSharingMap()
        {
            this.ToTable("DakBoxSharing");
            this.HasKey(a => a.Id);
        }
    }
}
