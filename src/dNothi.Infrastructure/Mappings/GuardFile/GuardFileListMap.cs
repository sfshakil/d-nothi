using dNothi.Core.Entities;
using dNothi.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Infrastructure.Mappings.GuardFile
{
    public class GuardFileListMap : NothiEntityTypeConfiguration<GuardFileList>
    {
        public GuardFileListMap()
        {
            this.ToTable("GuardFileList");
            this.HasKey(a => a.Id);
        }
    }
}
