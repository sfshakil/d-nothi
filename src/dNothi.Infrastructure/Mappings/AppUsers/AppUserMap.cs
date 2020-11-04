using dNothi.Core.Entities;
using dNothi.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Infrastructure.Mappings.AppUsers
{
    public class AppUserMap : NothiEntityTypeConfiguration<AppUser>
    {
        public AppUserMap()
        {
            this.ToTable("AppUsers");
            this.HasKey(a => a.Id);
        }
    }
}
