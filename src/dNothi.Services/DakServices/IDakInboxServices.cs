using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nothi.JsonParser.Entity.Dak_List_Inbox;

namespace Nothi.Services.DakServices
{
   public interface IDakInboxServices
    {
        DakListInboxResponse GetDakInbox(string token);
        void SaveOrUpdateDakTag(DakTagDTO dak_Tags);
        void SaveOrUpdateDakUser(DakUserDTO dak_Userdto);
    }
}
