﻿using dNothi.JsonParser.Entity.Nothi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Services.NothiServices
{
    public interface INothiTypeListServices
    {
        NothiTypeListResponse GetNothiTypeList(string token);
    }
}
