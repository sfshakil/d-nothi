using dNothi.Core.Entities;
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
    public class ReportCategoryAddItemMap : NothiEntityTypeConfiguration<ReportCategoryAddItem>
    {
        public ReportCategoryAddItemMap()
        {
            this.ToTable("ReportCategoryAddItem");
            this.HasKey(a => a.Id);
        }
    }
    public class ReportCategoryDeleteItemMap : NothiEntityTypeConfiguration<ReportCategoryDeleteItem>
    {
        public ReportCategoryDeleteItemMap()
        {
            this.ToTable("ReportCategoryDeleteItem");
            this.HasKey(a => a.Id);
        }
    }
    public class ReportCategorySerialUpdateItemMap : NothiEntityTypeConfiguration<ReportCategorySerialUpdateItem>
    {
        public ReportCategorySerialUpdateItemMap()
        {
            this.ToTable("ReportCategorySerialUpdateItem");
            this.HasKey(a => a.Id);
        }
    }
}
