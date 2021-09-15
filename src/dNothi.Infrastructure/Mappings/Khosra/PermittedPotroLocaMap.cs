using dNothi.Core.Entities.Khosra;
using dNothi.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Infrastructure.Mappings.Khosra
{
   public class PermittedPotroLocalMap : NothiEntityTypeConfiguration<PermittedPotroLocal>
    {
        public PermittedPotroLocalMap()
        {
            this.ToTable("PermittedPotroLocal");
            this.HasKey(a => a.Id);
        }
    }
}
