using dNothi.JsonParser.Entity.Dak;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Services.DakServices
{
    public interface IDesignationSealService
    {
        AllDesignationSealListResponse GetAllDesignationSeal(DakUserParam dakListUserParam, int office_id);
        OfficeListResponse GetAllOffice(DakUserParam dakListUserParam);
        DesignationSealListResponse GetOfficerAddedSealList(DakUserParam dakListUserParam);
    }
}
