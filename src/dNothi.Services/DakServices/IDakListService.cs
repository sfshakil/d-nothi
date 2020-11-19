using dNothi.JsonParser.Entity.Dak_List_Inbox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Services.DakServices
{
   public interface IDakListService
    {
        

        long SaveOrUpdateDakInbox(DakListDTO dakListDTO);
        //void SaveOrUpdateFrom(FromDTO fromdto);
        //void SaveOrUpdateTo(ToDTO todto);
        //void SaveOrUpdateOther(OtherDTO otherdto);
        //void SaveOrUpdateMovementStatus(MovementStatusDTO movementStatus);
        //void SaveOrUpdateMovementStatusTo(int movementStatusId, int toId);
        //void SaveOrUpdateMovementStatusTo(int movementStatusId, int toId);

    }
}
