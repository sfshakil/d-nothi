using dNothi.Services.DakServices;
using dNothi.Services.NothiReportService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Services.NothiReportService
{
   public interface INothiReportService
    {
        NothiRegisterReport NothiRegisterBook(DakUserParam dakListUserParam,string fromDate, string toDate, string branchName, bool isNothiPreron, bool isNothiGrahon, bool isNothiReigister);
       
        

        }
}
