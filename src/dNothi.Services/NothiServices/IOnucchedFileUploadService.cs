using dNothi.JsonParser.Entity.Dak;
using dNothi.Services.DakServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Services.NothiServices
{
    public interface IOnucchedFileUploadService
    {
        DakUploadedFileResponse GetOnuchhedUploadedFile(DakUserParam dakListUserParam, DakFileUploadParam dakFileUploadParam);
        bool SendNoteListFromLocal();
    }
}
