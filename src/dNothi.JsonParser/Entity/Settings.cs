using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.JsonParser.Entity
{
    public class Settings
    {
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
