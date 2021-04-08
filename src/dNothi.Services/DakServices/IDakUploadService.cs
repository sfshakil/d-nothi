using dNothi.JsonParser.Entity.Dak;
using dNothi.JsonParser.Entity.Dak_List_Inbox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Services.DakServices
{
    public interface IDakUploadService
    {
        List<DakListRecordsDTO> GetPendingDakUpload(bool is_Drafted);
        AddDesignationSealResponse GetDesiognationSealAddResponse(DakUserParam dakListUserParam, string sealInfo);
        DeleteDesignationSealResponse GetDesiognationSealDeleteResponse(DakUserParam dakListUserParam, string remove_designation_ids);

        DraftedDakEditResponse GetDraftedDakEditResponse(DakUserParam dakListUserParam, int dak_id, string dak_type, int is_copied_dak);

        OfficeListResponse GetAllOffice(DakUserParam dakListUserParam);
        DakUploadResponse GetDraftedDakSendResponse(DakUserParam dakListUserParam, int dak_id, string dak_type, int is_copied_dak, bool is_Drafted);
        AllDesignationSealListResponse GetAllDesignationSeal(DakUserParam dakListUserParam, int office_id);

        DakUploadedFileResponse GetDakUploadedFile(DakUserParam dakListUserParam, DakFileUploadParam dakFileUploadParam);
        OCRResponse GetOCRResponsse(DakUserParam dakListUserParam, OCRParameter oCRParameter);
        DakFileDeleteResponse GetFileDeleteResponsse(DakUserParam dakListUserParam, DakUploadFileDeleteParam deleteParam);

        DakDraftedResponse GetDakDraftedResponse(DakUserParam dakListUserParam, DakUploadParameter dakUploadParameter);
        DakUploadResponse GetDakSendResponse(DakUserParam dakListUserParam, DakUploadParameter dakUploadParameter);

        DraftedDakDeleteResponse GetDraftedDakDeleteResponse(DakUserParam dakListUserParam, int dak_id, string dak_type, int is_copied_dak, bool is_Drafted);
     
        bool UploadDakFromLocal();
        bool UploadDakFromLocal(int dak_id);
    }
}
