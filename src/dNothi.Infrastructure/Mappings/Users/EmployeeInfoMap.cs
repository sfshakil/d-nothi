using dNothi.Core.Entities;
using dNothi.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Infrastructure.Mappings.Users
{
    public class EmployeeInfoMap : NothiEntityTypeConfiguration<EmployeeInfo>
    {
        public EmployeeInfoMap()
        {
            this.ToTable("EmployeeInfos");
            this.HasKey(a => a.Id);
        }
    }
}
