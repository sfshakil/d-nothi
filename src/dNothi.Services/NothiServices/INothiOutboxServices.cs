using dNothi.JsonParser.Entity.Nothi;
using dNothi.Services.DakServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Services.NothiServices
{
    public interface INothiOutboxServices
    {
        //NothiListOutboxResponse GetNothiOutbox(string token);
        NothiListOutboxResponse GetNothiOutbox(DakUserParam dakListUserParam);
        NothiListOutboxResponse GetNothiOutbox(DakUserParam dakListUserParam, string searchParam);
        OtherOfficeNothiListOutboxResponse OtherOfficeNothiOutboxListEndPoint(DakUserParam dakListUserParam, string searchParam);
    }
}
