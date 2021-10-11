using dNothi.Core.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Core.Entities
{
    public class ReportCategoryItem : BaseEntity
    {
        public string type { get; set; }

        [MaxLength]
        public string jsonResponse { get; set; }
    }
    public class ReportCategoryAddItem : BaseEntity
    {
        public string type { get; set; }
        public string category_name { get; set; }
        public string category_id { get; set; }
        public string serial { get; set; }

    }
    public class ReportCategoryDeleteItem : BaseEntity
    {
        public string type { get; set; }
        public string category_name { get; set; }
        public string category_id { get; set; }
        public string serial { get; set; }

    }
    public class ReportCategorySerialUpdateItem : BaseEntity
    {
        public string type { get; set; }
        [MaxLength]
        public string json_serial_data { get; set; }

    }
}
