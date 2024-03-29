﻿using dNothi.JsonParser.Entity.Dak;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Services.DakServices
{
   public interface IDakArchiveService
    {
        bool Is_Locally_ArchiveReverted(int dak_id);
        bool DakArchiveRevertFromLocal();
        bool Is_Locally_Archived(int dak_id);
        bool DakArchivedFromLocal();
        DakArchiveRevertResponse GetDakArcivedRevertResponse(DakUserParam dakListUserParam, int dak_id, string dak_type, int is_copied_dak);

        DakArchiveResponse GetDakArcivedResponse(DakUserParam dakListUserParam, int dak_id, string dak_type, int is_copied_dak);
        DakListArchiveResponse GetDakList(DakUserParam dakListUserParam);
        DakListArchiveResponse GetDakList(DakUserParam dakListUserParam, string searchParam);
        void SaveorUpdateDakArchive(DakListArchiveResponse dakListArchiveResponse);
    }
}
