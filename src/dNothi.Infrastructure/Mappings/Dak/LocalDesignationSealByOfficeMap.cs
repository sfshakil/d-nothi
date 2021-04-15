using dNothi.Core.Entities;
using dNothi.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Infrastructure.Mappings.Dak
{
   public class LocalDesignationSealByOfficeMap : NothiEntityTypeConfiguration<LocalDesignationSealByOffice>
    {
        public LocalDesignationSealByOfficeMap()
        {
            this.ToTable("LocalDesignationSealByOffice");
            this.HasKey(a => a.Id);
        }
    }
}
