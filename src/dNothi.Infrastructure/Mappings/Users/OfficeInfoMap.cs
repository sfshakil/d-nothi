using dNothi.Core.Entities;
using dNothi.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Infrastructure.Mappings.AppUsers
{
    public class OfficeInfoMap : NothiEntityTypeConfiguration<OfficeInfo>
    {
        public OfficeInfoMap()
        {
            this.ToTable("OfficeInfos");
            this.HasKey(a => a.Id);
        }
    }
}
