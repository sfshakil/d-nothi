using dNothi.JsonParser.Entity.Nothi;
using dNothi.Services.DakServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Services.NothiServices
{
    public interface INothiNotePermissionService
    {
        NothiNotePermissionResponse GetNothiNotePermission(DakUserParam dakListUserParam, List<onumodonDataRecordDTO> nothiOnumodonRow, NothiListRecordsDTO nothiListRecordsDTO, int other_office_id, string note_Id);

        NothiNotePermissionResponse GetNothiPermission(DakUserParam dakListUserParam, List<onumodonDataRecordDTO> nothiOnumodonRow, NothiListRecordsDTO nothiListRecordsDTO, int other_office_id);
        bool SendNothiNotePermissionFromLocal();
    }
}
