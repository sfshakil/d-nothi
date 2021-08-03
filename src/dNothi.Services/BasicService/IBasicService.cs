

using dNothi.Services.BasicService.Models;
using dNothi.Services.DakServices;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Services.BasicService
{
  public  interface IBasicService
    {
        OfficeUnit GetOfficeUnitList(DakUserParam dakListUserParam);
      
        
    }
}
