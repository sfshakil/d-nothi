using dNothi.Core.Entities;
using dNothi.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Infrastructure.Mappings.Dak
{
    class DakBacaiKaranListMap : NothiEntityTypeConfiguration<DakBacaiKaranList>
    {
        public DakBacaiKaranListMap()
        {
            this.ToTable("DakBacaiKaranList");
            this.HasKey(a => a.Id);
        }
    
   }
}
