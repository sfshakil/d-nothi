using dNothi.Core.Entities;
using dNothi.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Infrastructure.Mappings.Dak
{
    public class DakListRecordMap : NothiEntityTypeConfiguration<DakListRecord>
    {
        public DakListRecordMap()
        {
            this.ToTable("DakListRecord");
            this.HasMany(t => t.dak_Tags).WithRequired().HasForeignKey(f => f.DakListRecordId);
            this.HasMany(t => t.dak_List).WithRequired().HasForeignKey(f => f.dakListRecordId);
        }
    }
}
