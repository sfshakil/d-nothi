using dNothi.Core.Entities;
using dNothi.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Infrastructure.Mappings.Report
{
   public class ReportPermissionMap : NothiEntityTypeConfiguration<ReportPermission>
    {
        public ReportPermissionMap()
        {
            this.ToTable("ReportPermission");
            this.HasKey(a => a.Id);
        }
    }
}
