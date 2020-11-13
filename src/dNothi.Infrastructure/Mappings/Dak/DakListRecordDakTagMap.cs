using dNothi.Infrastructure.Mapping;
using dNothi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nothi.Infrastructure.Mappings.Dak
{
    public class DakListRecordDakTagMap : NothiEntityTypeConfiguration<DakListRecordDakTag>
    {
        public DakListRecordDakTagMap()
        {
            this.ToTable("DakListRecordDakTag");

        }
    }
}
