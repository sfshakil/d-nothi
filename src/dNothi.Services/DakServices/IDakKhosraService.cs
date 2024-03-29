﻿using dNothi.JsonParser.Entity.Dak;
using dNothi.JsonParser.Entity.Dak_List_Inbox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Services.DakServices
{
    public interface IDakKhosraService
    {
        DakListKhosraResponse GetDakKhosraList(DakUserParam dakListUserParam);
        DakListKhosraResponse GetDakKhosraList(DakUserParam dakListUserParam, string searchParam);
    }
}
