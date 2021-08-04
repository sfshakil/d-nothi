using dNothi.Core.Entities;
using dNothi.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Infrastructure.Mappings.Dak
{
    class NothiRegisterBookMap : NothiEntityTypeConfiguration<NothiRegisterBook>
    {
        public NothiRegisterBookMap()
        {
            this.ToTable("NothiRegisterBook");
            this.HasKey(a => a.Id);
        }

    }
}
