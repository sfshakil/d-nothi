using dNothi.Core.Entities;
using dNothi.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Infrastructure.Mappings.Dak
{
    public class ToMap : NothiEntityTypeConfiguration<To>
    {
        public ToMap()
        {
            this.ToTable("To");
            this.HasMany(t => t.moveStatuses).WithRequired().HasForeignKey(f => f.ToId);
        }
    }
}
