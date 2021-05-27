using dNothi.JsonParser.Entity.Dak;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Services.DakServices
{
   public interface IDakListSortedService
    {
        DakListSortedResponse GetDakList(DakUserParam dakListUserParam);
        DakListSortedResponse GetDakList(DakUserParam dakListUserParam, string searchParam);
        void SaveorUpdateDakSorted(DakListSortedResponse dakListArchiveResponse);
        DakForwardResponse GetDakForwardResponse(DakForwardRequestParam dakForwardParam);
    }
}
