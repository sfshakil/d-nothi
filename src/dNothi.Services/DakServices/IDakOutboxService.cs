﻿using dNothi.JsonParser.Entity.Dak;
using dNothi.JsonParser.Entity.Dak_List_Inbox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Services.DakServices
{
    public interface IDakOutboxService
    {
        DakListOutboxResponse GetDakOutbox(DakUserParam dakListUserParam);
        DakListOutboxResponse GetDakOutbox(DakUserParam dakListUserParam, string searchParam);
    
        void SaveorUpdateDakOutbox(DakListOutboxResponse dakListOutboxResponse);
    }
}
