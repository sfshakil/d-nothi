using dNothi.Infrastructure.Mapping;
using dNothi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nothi.Infrastructure.Mappings.Users
{
    class UserTokenMap : NothiEntityTypeConfiguration<UserToken>
    {
        public UserTokenMap()
        {
            this.ToTable("UserToken");
            this.HasKey(a => a.Id);
        }
    }
}
