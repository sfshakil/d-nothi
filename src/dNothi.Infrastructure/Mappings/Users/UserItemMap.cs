using dNothi.Core.Entities;
using dNothi.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Infrastructure.Mappings.Users
{
    public class UserItemMap : NothiEntityTypeConfiguration<UserItem>
    {
        public UserItemMap()
        {
            this.ToTable("UserItem");
            this.HasKey(a => a.Id);
        }
    }
}
