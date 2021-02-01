using dNothi.JsonParser.Entity.Nothi;
using dNothi.Services.DakServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Services.NothiServices
{
    public interface IKhoshraPotroServices
    {
        KhoshraPotroResponse GetKhoshraPotroInfo(DakUserParam dakuserparam, long id);
    }
}
