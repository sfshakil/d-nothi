using dNothi.JsonParser.Entity.Khosra;
using dNothi.JsonParser.Entity.Nothi;
using dNothi.Services.DakServices;
using dNothi.Services.KasaraPatraDashBoardService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Services.NothiServices
{
    public interface IPotrojariServices
    {
        PotrojariCompleteResponse GetPotrojariResponse(DakUserParam userParam, PotrojariParameter potrojariParameter);
        PotroApproveResponse GetPotroOnumodonResponse(DakUserParam userParam, int potrojari_id, string potro_status, string potro_description);
        PotrojariResponse GetPotrojariListInfo(DakUserParam _dakuserparam, long id);
        PrapakerTalika GetPrapakerTalika(DakUserParam dakListUserParam, int potro);
    }
}
