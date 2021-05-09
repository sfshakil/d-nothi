using dNothi.JsonParser.Entity.Dak;
using dNothi.Services.DakServices.DakSharingService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Services.DakServices.DakSharingService
{
   public interface IDakSharingService<T> where T:class
    {
        T GetList(DakUserParam dakUserParam,int actionlink, int assignor_designation_id);
        ResponseModel Delete(DakUserParam dakUserParam,int assignee_designation_id);

        ResponseModel Add(DakUserParam assignor,PrapokDTO assignee);


        //ShareList  DakList
    }
}
