using dNothi.Core.Entities;
using dNothi.JsonParser.Entity.Nothi;
using dNothi.Services.DakServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static dNothi.JsonParser.Entity.Nothi.NothiListInboxNoteResponse;

namespace dNothi.Services.NothiServices
{
    public interface INothiInboxNoteServices
    {
        NothiListInboxNoteResponse GetNothiInboxNote(DakUserParam dakListUserParam, string eachNothiId, string note_category, string note_order);
        NoteAttachmentsListResponse GetNoteAttachments(DakUserParam dakListUserParam, string nothi_id, string note_id);
        NoteMovementsListResponse GetNoteMovements(DakUserParam dakListUserParam, string nothi_id, string note_id);
        List<NoteSaveItemAction> GetNotUploadedNoteFromLocal(DakUserParam dakListUserParam, string eachNothiId, string note_category);
    }
}
