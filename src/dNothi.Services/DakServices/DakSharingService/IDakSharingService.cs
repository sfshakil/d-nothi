using dNothi.Core.Entities;
using dNothi.JsonParser.Entity.Dak;
using dNothi.Services.DakServices.DakSharingService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Services.DakServices.DakSharingService
{
   public interface IDakSharingService<ResponseData> where ResponseData : class
    {
        ResponseData GetList(DakUserParam dakUserParam,int actionlink, int? assignor_designation_id);
        ResponseModel Delete(DakUserParam dakUserParam,int assignee_designation_id);
        List<DakBacaiKaran> LocalDakSortingList(DakUserParam userParam, int dak_id);

        ResponseModel Add(DakUserParam assignor,PrapokDTO assignee);
        ResponseModel AddDakSorting(DakUserParam userParam,DakSorting daksortParam);
        ResponseModel DakSortingDelete(DakUserParam userParam, DakSorting daksortParam);

        bool SendLocalDataToServer(DakUserParam userParam);
        bool SendDakSortingLocalDataToServer(DakUserParam userParam);
       

        //ShareList  DakList
    }
}
