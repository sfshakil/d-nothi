using dNothi.JsonParser.Entity.Dak;
using dNothi.JsonParser.Entity.Nothi;
using dNothi.Services.NothiServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Services.DakServices
{
    public interface IOnucchedSave
    {
        NothiOnuchhedSaveResponse GetNothiOnuchhedSave(string onuchhedId, DakUserParam dakUserParam, List<DakUploadedFileResponse> onuchhedSaveWithAttachment, NothiListRecordsDTO nothiListRecordsDTO, NoteSaveDTO newnotedata, string editorEncodedData);
    }
}
