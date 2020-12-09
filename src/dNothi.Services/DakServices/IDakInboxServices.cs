using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dNothi.Core.Entities;
using dNothi.Core.Interfaces;
using dNothi.JsonParser.Entity.Dak_List_Inbox;

namespace dNothi.Services.DakServices
{
   public interface IDakInboxServices
    {
       
        DakListInboxResponse GetDakInbox(DakListUserParam dakListUserParam);
        DakListInboxResponse GetLocalDakInbox(DakListUserParam dakListUserParam);
        void SaveorUpdateDakInbox(DakListInboxResponse dakListInboxResponse);
    }
}
