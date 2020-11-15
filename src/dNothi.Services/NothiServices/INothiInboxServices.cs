using dNothi.JsonParser.Entity.Nothi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Services.NothiServices
{
    public interface INothiInboxServices
    {
        NothiListInboxResponse GetNothiInbox(string token);
        void SaveOrUpdateNothiRecords(List<NothiListRecordsDTO> nothi_list_record);
    }
}
