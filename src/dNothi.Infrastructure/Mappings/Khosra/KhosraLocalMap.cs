using dNothi.Core.Entities;
using dNothi.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Infrastructure.Mappings.Khosra
{
   public class KhosraLocalMap : NothiEntityTypeConfiguration<KhosraLocal>
    {
        public KhosraLocalMap()
        {
            this.ToTable("KhosraLocal");
            this.HasKey(a => a.Id);
        }
    
    }
}
