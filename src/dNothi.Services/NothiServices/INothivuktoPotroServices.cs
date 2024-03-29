﻿using dNothi.JsonParser.Entity.Nothi;
using dNothi.Services.DakServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Services.NothiServices
{
    public interface INothivuktoPotroServices
    {
        NothivuktoPotroResponse GetNothivuktoPotroInfo(DakUserParam dakuserparam, long id, string potro_subject);
        NothivuktoPotroResponse GetNoteNothivuktoPotroInfo(DakUserParam dakuserparam, long nothi_id, int nothi_noteid, string potro_subject);
    }
}
