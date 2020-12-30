using dNothi.JsonParser.Entity.Dak_List_Inbox;
using dNothi.JsonParser.Entity.Dak;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Services.DakServices
{
   public interface IDakNothivuktoService
    {
        DakListNothivuktoResponse GetNothivuktoDakList(DakUserParam dakListUserParam);
        void SaveorUpdateDakNothivukto(DakListNothivuktoResponse dakListNothivuktoResponse);

    }
}
