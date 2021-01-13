using dNothi.JsonParser.Entity.Dak_List_Inbox;
using dNothi.JsonParser.Entity.Dak;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dNothi.JsonParser.Entity.Nothi;

namespace dNothi.Services.DakServices
{
   public interface IDakNothivuktoService
    {
        DakNothivuktoRevertResponse GetDakNothivuktoRevertResponse(DakUserParam dakListUserParam, int dak_id, string dak_type, int is_copied_dak);

        DakNothivuktoResponse GetDakNothivuktoResponse(DakUserParam dakListUserParam, NoteNothiDTO nothi, int dak_id, string dak_type, int is_copied_dak);

        DakListNothivuktoResponse GetNothivuktoDakList(DakUserParam dakListUserParam);
        void SaveorUpdateDakNothivukto(DakListNothivuktoResponse dakListNothivuktoResponse);
        GetNothivuktoNoteAddResponse GetNothivuktoNoteAddResponse(DakUserParam dakUserParam, DakNothivuktoNoteAddParam dakNothivuktoNoteAddParam);
    }
}
