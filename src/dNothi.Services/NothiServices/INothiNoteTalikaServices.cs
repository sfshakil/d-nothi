using dNothi.JsonParser.Entity.Nothi;
using dNothi.Services.DakServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Services.NothiServices
{
    public interface INothiNoteTalikaServices
    {
        NothiNoteTalikaListResponse GetNothiNoteTalika(DakUserParam dakListUserParam, string nothi_type_id);
        NothiNumberResponse GetNothiNumber(DakUserParam dakListUserParam, string nothi_type_id);

        NothiNoteListResponse GetNothiNoteListSent(DakUserParam dakUserParam, int nothi__id);
        NoteListResponse GetNoteListSent(DakUserParam dakUserParam, long nothi__id);
        NoteListResponse GetNoteListInbox(DakUserParam dakUserParam, long nothi__id);
        NoteAllListResponse GetNoteListAll(DakUserParam dakUserParam, long nothi__id);
        NothiNoteListResponse GetNothiNoteListInbox(DakUserParam dakUserParam, int nothi__id);
       

        NothiNoteListResponse GetNothiNoteListAll(DakUserParam dakUserParam, int nothi__id);
    }
}
