using dNothi.Core.Entities;
using dNothi.JsonParser.Entity;
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
        void DakDeleteUsingId(long id);

        void SaveDakItemLocally(List<DakIdListRecordDTO> data);
        void UpdateDakItemLocally(List<DakIdListRecordDTO> data);
      

         void SaveorUpdateDakItemDetailsLocally(long dak_id, string DakDetails);
      



        void DeleteDakItemLocally(List<DakItem> data);



        List<DakItem> GetLocalDakIdList(int page);
        void SaveOrUpdateDakList(DakListDTO data, long dakTypeId);
        void SaveOrUpdateDakList(List<DakListWithDetailsRecordDTO> records);
        DakListDTO GetLocalDakListbyType(long dakTypeId, DakUserParam dakListUserParam);

        DakDetailsResponse GetDakDetailsbyDakId(int dak_id, string dak_type, int is_copied_dak, DakUserParam dakListUserParam);
        DakAttachmentResponse GetDakAttachmentbyDakId(int dak_id, string dak_type, int is_copied_dak, DakUserParam dakListUserParam);
        DakMovementStatusResponse GetDakMovementStatusListbyDakId(int dak_id, string dak_type, int is_copied_dak, DakUserParam dakListUserParam);
        List<DakList> GetDakList();


        DakIdListResponse GetRemoteDakIdList(DakUserParam dakUserParam);
        DakListWithDetailsResponse GetRemoteDakListDetails(DakUserParam dakUserParam);
        PotroTemplateResponse GetPotroTemplate(DakUserParam dakListUserParam);

        DakSearchResponse GetDakListFromFolderResponse(DakUserParam dakListUserParam, int folder_id);

        //void SaveOrUpdateFrom(FromDTO fromdto);
        //void SaveOrUpdateTo(ToDTO todto);
        //void SaveOrUpdateOther(OtherDTO otherdto);
        //void SaveOrUpdateMovementStatus(MovementStatusDTO movementStatus);
        //void SaveOrUpdateMovementStatusTo(int movementStatusId, int toId);
        //void SaveOrUpdateMovementStatusTo(int movementStatusId, int toId);

    }
}
