using dNothi.Constants;
using dNothi.Core.Entities;
using dNothi.Core.Interfaces;
using dNothi.JsonParser.Entity.Dak;
using dNothi.JsonParser.Entity.Nothi;
using dNothi.Services.DakServices;
using dNothi.Services.UserServices;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace dNothi.Services.NothiServices
{
    public class OnuchhedSave : IOnucchedSave
    {
        IRepository<OnuchhedSaveItemAction> _onuchhedSaveItemAction;
        IUserService _userService { get; set; }
        public OnuchhedSave(IUserService userService, IRepository<OnuchhedSaveItemAction> onuchhedSaveItemAction)
        {
            _userService = userService;
            _onuchhedSaveItemAction = onuchhedSaveItemAction;
        }
        public NothiOnuchhedSaveResponse GetNothiOnuchhedSave(string onuchhedId, DakUserParam dakUserParam, List<DakUploadedFileResponse> onuchhedSaveWithAttachments, NothiListRecordsDTO nothiListRecordsDTO, NoteSaveDTO newnotedata, string editorEncodedData, string type)
        {
            NothiOnuchhedSaveResponse nothiOnuchhedSaveResponse = new NothiOnuchhedSaveResponse();

            if (!dNothi.Utility.InternetConnection.Check())
            {
                DakUserParam _dakuserparam = _userService.GetLocalDakUserParam();
                OnuchhedSaveItemAction onuchhedSaveDB = _onuchhedSaveItemAction.Table.FirstOrDefault(a => a.onuchhedId == onuchhedId && a.office_id == _dakuserparam.office_id && a.designation_id == _dakuserparam.designation_id);

                int onuchhedID;
                if (_onuchhedSaveItemAction.Table.Count()<=0)
                {
                    onuchhedID = 1;
                }
                else
                {
                    onuchhedID = _onuchhedSaveItemAction.Table.Count() + 1;
                }
                if (onuchhedSaveDB != null)
                {
                    onuchhedSaveDB.editorEncodedData = editorEncodedData;
                    _onuchhedSaveItemAction.Update(onuchhedSaveDB);
                }
                else
                {
                    OnuchhedSaveItemAction onuchhedSaveItemAction = new OnuchhedSaveItemAction();
                    onuchhedSaveItemAction.office_id = dakUserParam.office_id;
                    onuchhedSaveItemAction.designation_id = dakUserParam.designation_id;
                    string dup = JsonConvert.SerializeObject(dakUserParam);
                    string oswa = JsonConvert.SerializeObject(onuchhedSaveWithAttachments);
                    string nlrd = JsonConvert.SerializeObject(nothiListRecordsDTO);
                    string nnd = JsonConvert.SerializeObject(newnotedata);

                    onuchhedSaveItemAction.dakUserParamJson = dup;
                    onuchhedSaveItemAction.onuchhedSaveWithAttachmentsJson = oswa;
                    onuchhedSaveItemAction.nothiListRecordsDTOJson = nlrd;
                    onuchhedSaveItemAction.newnotedataJson = nnd;

                    onuchhedSaveItemAction.onuchhedId = onuchhedID.ToString();
                    onuchhedSaveItemAction.onuchhedType = "Local";
                    onuchhedSaveItemAction.editorEncodedData = editorEncodedData;

                    _onuchhedSaveItemAction.Insert(onuchhedSaveItemAction);

                }
                nothiOnuchhedSaveResponse.status = "success";
                nothiOnuchhedSaveResponse.message = "Local";
                return nothiOnuchhedSaveResponse;
            }
            try
            {
                var client = new RestClient(GetAPIDomain() + GetNoteOnuchhedSaveEndPoint());
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("api-version", GetAPIVersion());
                request.AddHeader("Authorization", "Bearer " + dakUserParam.token);
                request.AlwaysMultipartFormData = true;

                var serializedObject1 = JsonConvert.SerializeObject(dakUserParam);
                request.AddParameter("cdesk", serializedObject1);
                //var attachment = "";
                List<FileInfo> f1s = new List<FileInfo>();
                if (onuchhedSaveWithAttachments.Count > 0)
                {
                    foreach (DakUploadedFileResponse onuchhedSaveWithAttachment in onuchhedSaveWithAttachments)
                    {
                        FileInfo f1 = new FileInfo();
                        //f1.attachment_type = onuchhedSaveWithAttachments[0].data[0].attachment_type;
                        f1.user_file_name = onuchhedSaveWithAttachment.data[0].user_file_name;
                        f1.id = onuchhedSaveWithAttachment.data[0].id;
                        //f1.file_name = onuchhedSaveWithAttachments[0].data[0].file_name;
                        //f1.file_size_in_kb = onuchhedSaveWithAttachments[0].data[0].file_size_in_kb;
                        //f1.img_base64 = onuchhedSaveWithAttachments[0].data[0].img_base64;
                        //f1.url = onuchhedSaveWithAttachments[0].data[0].url;

                        //var fileinfo = JsonConvert.SerializeObject(f1);

                        //attachment = "{" + onuchhedSaveWithAttachments[0].data[0].id + ":" + fileinfo + "}";
                        f1s.Add(f1);
                    }

                }
                //var attachment = JsonConvert.SerializeObject(f1s);

                Onuchhed o1 = new Onuchhed();
                o1.nothi_id = nothiListRecordsDTO.id.ToString();
                o1.nothi_office = nothiListRecordsDTO.office_id.ToString();
                o1.note_description = editorEncodedData;
                o1.note_id = newnotedata.note_id.ToString();
                if (type == "Local")
                {
                    o1.id = "0";
                }
                else
                {
                    o1.id = onuchhedId;
                }
                
                o1.attachments = f1s;

                var onuchhed = JsonConvert.SerializeObject(o1);

                request.AddParameter("onucched", onuchhed);
                
                IRestResponse response = client.Execute(request);
                var responseJson = response.Content;
                responseJson =  System.Text.RegularExpressions.Regex.Replace(responseJson, "<pre.*</pre>", string.Empty, RegexOptions.Singleline);
                nothiOnuchhedSaveResponse = JsonConvert.DeserializeObject<NothiOnuchhedSaveResponse>(responseJson);
                return nothiOnuchhedSaveResponse;
            }
            catch (Exception ex)
            {
                throw;
            }
            
        }
        public bool SendNoteListFromLocal()
        {
            bool isForwarded = false;
            DakUserParam dakUserParam = _userService.GetLocalDakUserParam();
            List< OnuchhedSaveItemAction> onuchhedSaveItemActions = _onuchhedSaveItemAction.Table.Where(a => a.office_id == dakUserParam.office_id && a.designation_id == dakUserParam.designation_id).ToList();
            if (onuchhedSaveItemActions != null && onuchhedSaveItemActions.Count > 0)
            {
                foreach (OnuchhedSaveItemAction onuchhedSaveItemAction in onuchhedSaveItemActions)
                {
                    DakUserParam dakUserParamLocal = JsonConvert.DeserializeObject<DakUserParam>(onuchhedSaveItemAction.dakUserParamJson);
                    dakUserParamLocal.token = dakUserParam.token;



                    List<DakUploadedFileResponse> onuchhedSaveWithAttachments = new List<DakUploadedFileResponse>();
                    try
                    {

                        DakUploadedFileResponse dakUploadedFileResponse = JsonConvert.DeserializeObject<DakUploadedFileResponse>(onuchhedSaveItemAction.onuchhedSaveWithAttachmentsJson);
                        onuchhedSaveWithAttachments.Add(dakUploadedFileResponse);
                    }
                    catch
                    {
                        onuchhedSaveWithAttachments = JsonConvert.DeserializeObject<List<DakUploadedFileResponse>>(onuchhedSaveItemAction.onuchhedSaveWithAttachmentsJson);

                    }

                    NothiListRecordsDTO nothiListRecordsDTO = JsonConvert.DeserializeObject<NothiListRecordsDTO>(onuchhedSaveItemAction.nothiListRecordsDTOJson);
                    NoteSaveDTO newnotedata = JsonConvert.DeserializeObject<NoteSaveDTO>(onuchhedSaveItemAction.newnotedataJson);
                    
                    var onuchhedSaveResponse = GetNothiOnuchhedSave(onuchhedSaveItemAction.onuchhedId, dakUserParamLocal, onuchhedSaveWithAttachments, nothiListRecordsDTO, newnotedata, onuchhedSaveItemAction.editorEncodedData, onuchhedSaveItemAction.onuchhedType);

                    if (onuchhedSaveResponse != null && (onuchhedSaveResponse.status == "error" || onuchhedSaveResponse.status == "success"))
                    {
                        _onuchhedSaveItemAction.Delete(onuchhedSaveItemAction);
                        isForwarded = true;
                    }
                }
            }


            return isForwarded;
        }
        public class FileInfo
        {
            public long id { get; set; }
            public string user_file_name { get; set; }
        }
        public class Onuchhed
        {
            public string nothi_id { get; set; }
            public string nothi_office { get; set; }
            public string note_id { get; set; }
            public string id { get; set; }
            public string note_description { get; set; }
            public List<FileInfo> attachments { get; set; }
        }
        
        protected string GetAPIVersion()
        {
            return ReadAppSettings("api-version") ?? DefaultAPIConfiguration.DefaultAPIversion;
        }
        protected string ReadAppSettings(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }


        protected string GetAPIDomain()
        {
            return ReadAppSettings("api-endpoint") ?? DefaultAPIConfiguration.DefaultAPIDomainAddress;
        }

        protected string GetNoteOnuchhedSaveEndPoint()
        {
            return DefaultAPIConfiguration.NoteOnuchhedSaveEndPoint;
        }
    }
}
