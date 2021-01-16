using dNothi.JsonParser.Entity.Nothi;
using dNothi.Services.DakServices;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Services.NothiServices
{
    public class OnuchhedSave : IOnucchedSave
    {
        public NothiOnuchhedSaveResponse GetNothiOnuchhedSave(DakUserParam dakUserParam, List<FileAttachment> fileattachments, NothiListRecordsDTO nothiListRecordsDTO, NoteSaveDTO newnotedata)
        {
            try
            {
                var client = new RestClient("https://dev.nothibs.tappware.com/api/nothi/note/onucched/save");
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("api-version", "1");
                request.AddHeader("Authorization", "Bearer " + dakUserParam.token);
                request.AlwaysMultipartFormData = true;
                request.AddParameter("cdesk", "{\"office_id\":\"" + dakUserParam.office_id+ "\",\"office_unit_id\":\"" + dakUserParam.office_unit_id+ "\",\"designation_id\":\"" + dakUserParam.designation_id+ "\",\"officer_id\":\"" + dakUserParam.officer_id+ "\",\"user_id\":\"" + dakUserParam.user_id+ "\",\"office\":\"" + dakUserParam.office+ "\",\"office_unit\":\"Technology\",\"designation\":\"" + dakUserParam.designation+ "\",\"officer\":\"" + dakUserParam.officer+ "\",\"designation_level\":\"" + dakUserParam.designation_level+ "\"}");
                request.AddParameter("onucched", "{\"nothi_id\":\""+newnotedata.nothi_id+"\",\"nothi_office\":\""+newnotedata.office_id+"\",\"note_id\":\""+newnotedata.note_id+"\",\"id\":\""+newnotedata.id+"\",\"note_description\":\"PHA+PHNwYW4gaWQ9Im5vdGVfc3ViIj7gpqjgpqXgpr\\/gpqTgp4cg4KaJ4Kaq4Ka44KeN4Kal4Ka+4Kaq4KaoIOCmmuCnh+CmleCmv+Cmgjwvc3Bhbj48L3A+\",\"attachments\":[]}");
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);

                var responseJson = response.Content;
                NothiOnuchhedSaveResponse nothiOnuchhedSaveResponse = JsonConvert.DeserializeObject<NothiOnuchhedSaveResponse>(responseJson);
                return nothiOnuchhedSaveResponse;
            }
            catch (Exception ex)
            {
                throw;
            }
            
        }
    }
}
