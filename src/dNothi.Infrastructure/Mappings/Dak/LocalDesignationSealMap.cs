using dNothi.Core.Entities;
using dNothi.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Infrastructure.Mappings.Dak
{
    class LocalDesignationSealMap : NothiEntityTypeConfiguration<LocalDesignationSeal>
    {
        public LocalDesignationSealMap()
        {
            this.ToTable("LocalDesignationSeal");
            this.HasKey(a => a.Id);
        }
    }
}
