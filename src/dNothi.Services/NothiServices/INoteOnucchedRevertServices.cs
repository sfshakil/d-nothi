using dNothi.JsonParser.Entity.Nothi;
using dNothi.Services.DakServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Services.NothiServices
{
    public interface INoteOnucchedRevertServices
    {
        NoteOnucchedRevertResPonse GetNoteOnucchedRevert(DakUserParam _dakuserparam, NothiListRecordsDTO nothiListRecords, NoteSaveDTO newnotedata);
        NoteFinishedResponse GetNoteFinished(DakUserParam _dakuserparam, string nothi_id , string note_id);
    }
}
