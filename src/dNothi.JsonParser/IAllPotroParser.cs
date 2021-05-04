using dNothi.JsonParser.Entity.Nothi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.JsonParser
{
    public interface IAllPotroParser
    {
        AllPotroResponse ParseMessage(string messageString);
        NoteKhoshraListResponse NoteKhoshraParseMessage(string messageString);
        NoteKhshraWaitingListResponse NoteKhoshraWaitingParseMessage(string messageString);
        NotePotrojariResponse NotePotrojariParseMessage(string messageString);
        KhoshraPotroWaitingResponse KhoshraWaitingParseMessage(string messageString);
    }
}
