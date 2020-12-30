using dNothi.JsonParser.Entity.Dak;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Services.DakServices
{
    public interface IDakNothijatoService
    {
        DakListNothijatoResponse GetNothijatoDak(DakUserParam dakListUserParam);
        void SaveorUpdateDakNothijato(DakListNothijatoResponse dakListNothijatoResponse);
    }
}
