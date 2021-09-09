using dNothi.JsonParser.Entity.Nothi;
using dNothi.Services.DakServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Services.NothiServices
{
    public interface INothiDecisionListService
    {
        NothiDecisionListResponse GetNothiDecisionList(DakUserParam dakUserParam);
        NothiDecisionListResponse GetNothiALLDecisionList(DakUserParam dakUserParam);
        NothiDecisionListAddResponse GetNothiAddDecisionList(DakUserParam dakUserParam, string decision, long decisions_employee, long id);
        NothiDecisionListDeleteResponse GetNothiDeleteDecisionList(DakUserParam dakUserParam, long nothi_decision_id);
        NothiGaurdFileListResponse GetNothiGaurdFileList(DakUserParam dakUserParam);
        NothiBibechhoPotroResponse GetNothiBibechhoPotroList(DakUserParam dakUserParam, string nothi_id);
        NothiOnuchhedListResponse GetNothiOnuchhedList(DakUserParam dakUserParam, string nothi_id);
        NothiPotakaListResponse GetNothiPotakaList(DakUserParam dakUserParam, string nothi_id, string note_id);
        NothiPotakaResponse GetNothiPotakaSaveResponse(DakUserParam dakUserParam, NothiPotakaData nothiPotakaData, KhoshraPotroWaitinDataRecordDTO khoshraPotroWaitinDataRecordDTO);
    }
}
