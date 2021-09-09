using dNothi.Core.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Core.Entities
{
    public class SettingsList : BaseEntity
    {
        public int designation_id { get; set; }
        public int office_id { get; set; }
        
        public int nothiInboxPagination { get; set; }
        public int nothiSentPagination { get; set; }
        public int nothiAllPagination { get; set; }
        public int othersOfficeNothiInboxPagination { get; set; }
        public int othersOfficeNothiSentPagination { get; set; }
        public int dakInboxPagination { get; set; }
        public int dakSentPagination { get; set; }
        public int dakNothiteUposthapitoPagination { get; set; }
        public int dakNothijatoPagination { get; set; }
        public int dakArchaivePagination { get; set; }
        public int dakKhoshraPagination { get; set; }
    }
}
