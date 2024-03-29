﻿using dNothi.JsonParser.Entity;
using dNothi.JsonParser.Entity.Dak;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Services.DakServices
{
    public interface IDesignationSealService
    {
        AllDesignationSealListResponse GetAllDesignationSeal(DakUserParam dakListUserParam, int office_id);
        OfficeListResponse GetAllOffice(DakUserParam dakListUserParam);
        List<LocalOfficesResponse> GetAllLocalOffice();
        DesignationSealListResponse GetOfficerAddedSealList(DakUserParam dakListUserParam);
    }
}
