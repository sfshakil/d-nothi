using dNothi.JsonParser.Entity.Dak;
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
        

     
        void SaveOrUpdateDakList(DakListDTO data, long dakTypeId);
        DakListDTO GetLocalDakListbyType(long dakTypeId, DakListUserParam dakListUserParam);

        DakDetailsResponse GetDakDetailsbyDakId(int dak_id, string dak_type, int is_copied_dak, DakListUserParam dakListUserParam);
        DakAttachmentResponse GetDakAttachmentbyDakId(int dak_id, string dak_type, int is_copied_dak, DakListUserParam dakListUserParam);
        DakMovementStatusResponse GetDakMovementStatusListbyDakId(int dak_id, string dak_type, int is_copied_dak, DakListUserParam dakListUserParam);


        //void SaveOrUpdateFrom(FromDTO fromdto);
        //void SaveOrUpdateTo(ToDTO todto);
        //void SaveOrUpdateOther(OtherDTO otherdto);
        //void SaveOrUpdateMovementStatus(MovementStatusDTO movementStatus);
        //void SaveOrUpdateMovementStatusTo(int movementStatusId, int toId);
        //void SaveOrUpdateMovementStatusTo(int movementStatusId, int toId);

    }
}
