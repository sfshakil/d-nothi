﻿using dNothi.JsonParser.Entity.Dak;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Services.DakServices
{
    public interface IDakNothijatoService
    {
        bool DakNothijatoRevertFromLocal();
        bool Is_Locally_NothijatoReverted(int dak_id);
        bool Is_Locally_Nothijato(int dak_id);
        bool DakNothijatoFromLocal();
        DakNothijatoResponse GetDakNothijatoResponse(DakUserParam dakListUserParam, NothijatoActionParam nothi, int dak_id, string dak_type, int is_copied_dak);
        DakNothijatoRevertResponse GetDakNothijatoRevertResponse(DakUserParam dakListUserParam,int dak_id, string dak_type, int is_copied_dak);

        DakListNothijatoResponse GetNothijatoDak(DakUserParam dakListUserParam);
        DakListNothijatoResponse GetNothijatoDak(DakUserParam dakListUserParam, string searchParam);
        void SaveorUpdateDakNothijato(DakListNothijatoResponse dakListNothijatoResponse);

       
    }
}
