using dNothi.Infrastructure.Mapping;
using Nothi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nothi.Infrastructure.Mappings.Dak
{
    class DakTagMap : NothiEntityTypeConfiguration<DakTag>
    {
        public DakTagMap()
        {
            this.ToTable("DakTag");

        }
    }
}
