﻿using dNothi.Core.Entities;
using dNothi.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Infrastructure.Mappings.Nothi
{
    public class SingleNoteOnuchhedItemMap : NothiEntityTypeConfiguration<SingleNoteOnuchhedItem>
    {
        public SingleNoteOnuchhedItemMap()
        {
            this.ToTable("SingleNoteOnuchhedItem");
            this.HasKey(a => a.Id);
        }
    }
}
