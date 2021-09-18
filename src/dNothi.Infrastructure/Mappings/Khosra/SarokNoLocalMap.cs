using dNothi.Core.Entities.Khosra;
using dNothi.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Infrastructure.Mappings.Khosra
{
    public class SarokNoLocalMap : NothiEntityTypeConfiguration<SarokNoLocal>
    {
        public SarokNoLocalMap()
        {
            this.ToTable("SarokNoLocal");
            this.HasKey(a => a.Id);
        }
    }
}
