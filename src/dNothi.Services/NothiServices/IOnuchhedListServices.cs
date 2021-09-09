using dNothi.JsonParser.Entity.Nothi;
using dNothi.Services.DakServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Services.NothiServices
{
    public interface IOnuchhedListServices
    {
        OnucchedListResponse GetAllOnucchedList(DakUserParam _dakuserparam, NothiListRecordsDTO nothiListRecordsDTO, long note_id);
    }
}
