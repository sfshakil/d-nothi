

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
     
    }
}
