using dNothi.JsonParser.Entity.Nothi;
using dNothi.Services.DakServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Services.NothiServices
{
    public interface INothiInboxServices
    {
        NothiListInboxResponse GetNothiInbox(DakUserParam dakUserParam);
        NothiListInboxResponse GetSearchNothiInbox(DakUserParam dakUserParam, String search_params);
        OthersOfficeNothiListInboxResponse GetOthersOfficeNothiInbox(DakUserParam dakUserParam, String search_params);
        //void SaveOrUpdateNothiRecords(List<NothiListRecordsDTO> nothi_list_record);
    }
}
