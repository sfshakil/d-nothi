using dNothi.Core.Entities;
using dNothi.JsonParser.Entity.Nothi;
using dNothi.Services.DakServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Services.NothiServices
{
    public interface INothiOutboxNoteServices
    {
        NothiListOutboxNoteResponse GetNothiOutboxNote(DakUserParam dakListUserParam, string eachNothiId, string note_category);
        List<NoteSaveItemAction> GetNotUploadedNoteFromLocal(DakUserParam dakListUserParam, string eachNothiId, string note_category);
    }
}
