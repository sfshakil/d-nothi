using dNothi.Core.Entities;
using dNothi.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Infrastructure.Mappings.Dak
{
  public  class DakNothivuktoMap : NothiEntityTypeConfiguration<DakNothivukto>
    {
        public DakNothivuktoMap()
        {
            this.ToTable("DakNothivukto");

        }
    }
}