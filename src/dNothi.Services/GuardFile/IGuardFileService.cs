using dNothi.JsonParser.Entity;
using dNothi.Services.DakServices;
using dNothi.Services.GuardFile.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Services.GuardFile
{
   public interface IGuardFileService<ResponseData, InputParam> where ResponseData : class where InputParam : class 
    {
        ResponseData GetList(DakUserParam obj, int actionLink);
        ResponseEdit Insert(DakUserParam userParam, int actionLink, string model, InputParam data);
        DeleteResponse Delete(DakUserParam obj, int actionLink,int id,string model);
        GuardFileAttachment UploadedFile(DakUserParam dakListUserParam, DakFileUploadParam dakFileUploadParam, int actionLink);

        GuardFilePortal GuardFilePortalList(DakUserParam userParam,string name,string type);
        GuardFileOffice GuardFilePortalOfficeList(DakUserParam userParam, int layer_id, string type);
       
    }
}
