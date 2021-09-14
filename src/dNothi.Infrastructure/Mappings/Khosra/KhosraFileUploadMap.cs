using dNothi.Core.Entities.Khosra;
using dNothi.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Infrastructure.Mappings.Khosra
{
   public class KhosraFileUploadMap : NothiEntityTypeConfiguration<KhosraFileUpload>
    {
        public KhosraFileUploadMap()
        {
            this.ToTable("KhosraFileUpload");
            this.HasKey(a => a.Id);
        }

    }
}
