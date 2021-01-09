using dNothi.JsonParser.Entity.Nothi;
using dNothi.Services.DakServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Services.NothiServices
{
    public interface INothiAllServices
    {
        NothiListAllResponse GetNothiAll(string token);
        NothiListAllResponse GetNothiAllByUser(DakUserParam dakUserParam);
    }
}
