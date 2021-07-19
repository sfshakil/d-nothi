using dNothi.JsonParser.Entity.Nothi;
using dNothi.Services.DakServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Services.NothiServices
{
    public interface INothiCreateService
    {
        NothiCreateResponse GetNothiCreate(DakUserParam UserParam, string id, string nothishkha, string nothi_no, string nothi_type_id, string nothi_subject, string nothi_class, string currentYear);
        bool SendNothiCreateListFromLocal();
    }
}
