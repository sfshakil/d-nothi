using dNothi.Core.Entities;
using dNothi.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Infrastructure.Mappings.EmailBox
{
    class EmailListMap : NothiEntityTypeConfiguration<EmailList>
    {
        public EmailListMap()
        {
            this.ToTable("EmailList");
            this.HasKey(a => a.Id);
        }
    }
}
