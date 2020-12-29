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
        DakUploadedFileResponse GetDakUploadedFile(DakListUserParam dakListUserParam, DakFileUploadParam dakFileUploadParam);
        OCRResponse GetOCRResponsse(DakListUserParam dakListUserParam, OCRParameter oCRParameter);
        DakFileDeleteResponse GetFileDeleteResponsse(DakListUserParam dakListUserParam, DakUploadFileDeleteParam deleteParam);

        DakUploadResponse GetDakUploadResponse(DakListUserParam dakListUserParam, DakUploadParameter dakUploadParameter);
    }
}
