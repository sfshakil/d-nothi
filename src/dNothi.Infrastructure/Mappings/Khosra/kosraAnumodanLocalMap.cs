using dNothi.Core.Entities.Khosra;
using dNothi.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Infrastructure.Mappings.Khosra
{
    class kosraAnumodanLocalMap : NothiEntityTypeConfiguration<kosraAnumodanLocal>
    {
        public kosraAnumodanLocalMap()
        {
            this.ToTable("kosraAnumodanLocal");
            this.HasKey(a => a.Id);
        }
    }
}
