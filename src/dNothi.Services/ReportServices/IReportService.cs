using dNothi.JsonParser.Entity;
using dNothi.Services.DakServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Services.ReportServices
{
    public interface IReportService
    {
        ReportCategoryResponse GetReportCategoryList(DakUserParam userParam, string type);
    }
}
