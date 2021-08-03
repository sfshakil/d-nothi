using dNothi.Core.Entities;
using dNothi.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Infrastructure.Mappings.Dak
{
    class DakRegisterBookMap : NothiEntityTypeConfiguration<DakRegisterBook>
    {
        public DakRegisterBookMap()
        {
            this.ToTable("DakRegisterBook");
            this.HasKey(a => a.Id);
        }

    }
}
