using Nothi.JsonParser.Entity.Dak;
using Nothi.JsonParser.Entity.Dak_List_Inbox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nothi.Services.DakServices
{
    public interface IDakOutboxService
    {
        DakListOutboxResponse GetDakOutbox(DakListUserParam dakListUserParam);
    }
}
