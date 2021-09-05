using dNothi.Core.Entities;
using dNothi.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Infrastructure.Mappings.GuardFile
{
    public class GuardFileUploadMap : NothiEntityTypeConfiguration<GuardFileUpload>
    {
        public GuardFileUploadMap()
        {
          
            this.ToTable("GuardFileUpload");
            this.HasKey(a => a.Id);
        }
    }
}
