﻿using dNothi.Core.Entities;
using dNothi.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Infrastructure.Mappings.Nothi
{
    public class ReportCategoryItemMap : NothiEntityTypeConfiguration<ReportCategoryItem>
    {
        public ReportCategoryItemMap()
        {
            this.ToTable("ReportCategoryItem");
            this.HasKey(a => a.Id);
        }
    }
}
