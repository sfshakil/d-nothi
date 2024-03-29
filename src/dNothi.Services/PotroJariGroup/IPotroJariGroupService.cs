﻿

using dNothi.Services.DakServices;

using dNothi.Services.PotroJariGroup.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Services.PotroJariGroup
{
  public  interface IPotroJariGroupService
    {
        PotrojariGroupModel GetList(DakUserParam dakListUserParam, int menuNo);
        PotroJariGroupModels PatroJariGroupCreateUpdate(DakUserParam userParam, PotrojariGroupModel.Group potrojariGroup, List<PotroJariGroupModels.User> users);
        PotroJariGroupModels PatroJariGroupDelete(DakUserParam userParam, int group_id);
        
    }
}
