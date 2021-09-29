using dNothi.JsonParser.Entity.Nothi;
using dNothi.Services.DakServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Services.NothiServices
{
    public interface INothiReviewerServices
    {
        NothiReviewerDTO GetNothiReviewer(DakUserParam dakuserparam, long nothi_shared_id);
        NothiSharedOffDTO GetNothiSharedOff(DakUserParam dakuserparam, NothiReviewerDTO nothiReviewer);
        NothiSharedSaveDTO GetNothiSharedSave(DakUserParam dakuserparam, NothiListInboxNoteRecordsDTO noteAllListDataRecord, long potrojari_id, long onuchhed_id, List<User> selectedUser);
        NothiShaeredByMeDTO GetNothiSharedByMe(DakUserParam dakuserparam);
        NothiShaeredByMeDTO GetNothiSharedToMe(DakUserParam dakuserparam);
        NothiShaeredByMeDTO GetNothiSharedRecent(DakUserParam dakuserparam);
        NothiSharedEditorDataDTO GetNothiSharedEditorData(DakUserParam dakuserparam, long shared_id);
        NothiSharedEditorDataSendDTO GetNothiSharedEditorSaveData(DakUserParam dakuserparam, NothiShaeredByMeRecord nothiShaeredByMeRecord);
    }
}
