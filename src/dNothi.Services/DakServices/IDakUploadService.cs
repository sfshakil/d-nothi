using dNothi.JsonParser.Entity.Dak;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Services.DakServices
{
    public interface IDakUploadService
    {
        OfficeListResponse GetAllOffice(DakUserParam dakListUserParam);
        AllDesignationSealListResponse GetAllDesignationSeal(DakUserParam dakListUserParam, int office_id);

        DakUploadedFileResponse GetDakUploadedFile(DakUserParam dakListUserParam, DakFileUploadParam dakFileUploadParam);
        OCRResponse GetOCRResponsse(DakUserParam dakListUserParam, OCRParameter oCRParameter);
        DakFileDeleteResponse GetFileDeleteResponsse(DakUserParam dakListUserParam, DakUploadFileDeleteParam deleteParam);

        DakUploadResponse GetDakUploadResponse(DakUserParam dakListUserParam, DakUploadParameter dakUploadParameter);
    }
}
