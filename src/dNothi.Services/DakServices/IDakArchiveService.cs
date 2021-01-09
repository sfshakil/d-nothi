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
        DakArchiveResponse GetDakArcivedResponse(DakUserParam dakListUserParam, int dak_id, string dak_type, int is_copied_dak);
        DakListArchiveResponse GetDakList(DakUserParam dakListUserParam);
        void SaveorUpdateDakArchive(DakListArchiveResponse dakListArchiveResponse);
    }
}