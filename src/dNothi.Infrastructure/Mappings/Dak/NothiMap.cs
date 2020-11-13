using dNothi.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Infrastructure.Mappings.Dak
{
    public class NothiMap : NothiEntityTypeConfiguration<dNothi.Core.Entities.Nothi>
    {
        public NothiMap()
        {
            this.ToTable("Nothi");

        }
    }
}
