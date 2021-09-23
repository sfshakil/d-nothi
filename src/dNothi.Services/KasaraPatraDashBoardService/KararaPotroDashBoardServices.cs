using dNothi.Constants;
using dNothi.Core.Entities;
using dNothi.Core.Entities.Khosra;
using dNothi.Core.Interfaces;
using dNothi.JsonParser;
using dNothi.JsonParser.Entity.Dak;
using dNothi.Services.DakServices;
using dNothi.Services.DakServices.DakSharingService.Model;
using dNothi.Services.KasaraPatraDashBoardService.Models;
using dNothi.Services.KhasraService;
using dNothi.Utility;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Services.KasaraPatraDashBoardService
{
   public class KararaPotroDashBoardServices : IKasaraPatraDashBoardService
    {
        IRepository<KhosraLocal> _localKhosraLocalRepository;
        IRepository<KhosraListLocal> _localKhosraListLocalRepository;
        IRepository<KhosraFileUpload> _localKhosraFileUploadRepository;

        public KararaPotroDashBoardServices(IRepository<KhosraLocal> localKhosraLocalRepository,
            IRepository<KhosraListLocal> localKhosraListLocalRepository,
            IRepository<KhosraFileUpload> localKhosraFileUploadRepository)
        {
            _localKhosraLocalRepository = localKhosraLocalRepository;
            _localKhosraListLocalRepository = localKhosraListLocalRepository;
            _localKhosraFileUploadRepository = localKhosraFileUploadRepository;
        }
        public KasaraPotro GetList(DakUserParam userParam, int menuNo)
        {
            string cdesk = "{\"office_id\":\"" + userParam.office_id + "\",\"office_unit_id\":\"" + userParam.office_unit_id + "\",\"designation_id\":\"" + userParam.designation_id + "\"}";
            string searchParam = "potro_subject=" + userParam.NameSearchParam + "";

            if (!InternetConnection.Check())
            {
                //int listType;
                var responseJson = GetLocalKhasraList(userParam, menuNo, cdesk, searchParam);

                KasaraPotro nothikhoshrapotrolist = JsonConvert.DeserializeObject<KasaraPotro>(responseJson, NullDeserializeSetting());

                List<KasaraPotro.Record> records = new List<KasaraPotro.Record>();
                //if (menuNo == 3)
                //    listType = 1;
                //else
                //    listType = menuNo;

                var localData = _localKhosraLocalRepository.Table.Where(x=>x.kosra_type== menuNo && x.page== userParam.page).ToList();

                foreach (var kosra in localData)
                {
                    string reciveres, onulipies;
                    KhosraSaveParamPotro potroParam = JsonConvert.DeserializeObject<KhosraSaveParamPotro>(kosra.potro);
                    DakUserParam dakUserParam = JsonConvert.DeserializeObject<DakUserParam>(kosra.cdesk);
                    string modifieddate = string.Empty;
                    if (potroParam.potrojaris.modified != null)
                    {
                         modifieddate = ConversionMethod.BanglaDigittoEngDigit(potroParam.potrojaris.modified);
                        DateTime dateTime2 = Convert.ToDateTime(modifieddate);
                        modifieddate = ConversionMethod.EngDigittoBanDigit(dateTime2.ToString("dd/MM/yy HH:mm tt"));
                    }
                    else
                    {
                        modifieddate = ConversionMethod.EngDigittoBanDigit(DateTime.Now.ToString("dd/MM/yy HH:mm tt"));
                    }
                    KasaraPotro.Basic basic = new KasaraPotro.Basic { PotroPages = potroParam.attachment.Count(), Id=(int)kosra.Id,
                        PotroSubject = potroParam.potrojari.potro_subject, 
                        PotroPriorityLevel= potroParam.potrojari.potro_priority_level.ToString(), 
                        PotroSecurityLevel = potroParam.potrojari.potro_security_level.ToString(),
                        Modified = modifieddate, NoteOnucchedId = potroParam.potrojari.note_onucched_id, PotroType = potroParam.potrojari.potro_type,
                        DakId = 0, PotroStatus = potroParam.potrojari.operation_type!="draft"? potroParam.potrojari.operation_type:"Draft", SarokNo = string.Empty,
                        PotroTypeName = potroParam.potrojaris.potro_type_name, 
                    };
                    KasaraPotro.NoteOwner noteOwner;
                    KasaraPotro.NoteOnucched noteOnucched;
                    
                    if (kosra.kosra_type== 1)
                    {
                        noteOwner = new KasaraPotro.NoteOwner {  NoteNo=0, DesignationId=0};
                        noteOnucched =new KasaraPotro.NoteOnucched { Id=0 };
                    }
                   
                    else
                    {
                         noteOwner = new KasaraPotro.NoteOwner
                        {
                            NothiMasterId = potroParam.potrojari.nothi_master_id,
                            IssueDate = kosra.EntryDate,
                            NoteCurrentStatus = null,
                            NoteSubject = potroParam.potrojari.note_subject,
                            NothiSubject = potroParam.potrojari.note_subject,
                            DesignationId = dakUserParam.designation_id,
                            Designation = dakUserParam.designation,
                            Office = dakUserParam.office,
                            OfficeId = dakUserParam.office_id,
                            OfficeUnit = dakUserParam.office_unit,
                            OfficeUnitId = dakUserParam.office_unit_id,
                            Priority = potroParam.potrojari.potro_priority_level,
                            NothiNoteId = potroParam.potrojari.nothi_note_id,
                            NoteNo = potroParam.potrojaris.note_no

                        };

                         noteOnucched = new KasaraPotro.NoteOnucched { Id = potroParam.potrojari.note_onucched_id };

                    }
                    KasaraPotro.Mulpotro mulpotro=new KasaraPotro.Mulpotro { PotroDescription= potroParam.potrojari.potro_description };

                    List<KasaraPotro.Approver> approvers = new List<KasaraPotro.Approver>();
                    foreach (var item in potroParam.recipient.approver)
                    {
                        KasaraPotro.Approver approver = new KasaraPotro.Approver
                        {
                            Designation = item.Value.designation,
                            DesignationId = Convert.ToInt32(item.Value.designation_id),
                            Id = Convert.ToInt32(item.Value.id),
                            IsSent = Convert.ToInt32(item.Value.is_sent),
                            Label = item.Value.label,
                            Office = item.Value.office,
                            OfficeId = Convert.ToInt32(item.Value.office_id),
                            Officer = item.Value.officer,
                            OfficerEmail = item.Value.officer_email,
                            OfficerId = Convert.ToInt32(item.Value.officer_id),
                            OfficeUnit = item.Value.office_unit,
                            OfficeUnitId = Convert.ToInt32(item.Value.office_unit_id),
                            PotrojariId = Convert.ToInt32(item.Value.potrojari_id),
                            PotroStatus = item.Value.potro_status,
                            PotroType = Convert.ToInt32(item.Value.potro_status),
                            RecipientType = item.Value.recipient_type,
                            VisibleDesignation = null,
                            VisibleName = item.Value.visible_name

                          
                        };
                        approvers.Add(approver);
                    }

                    List<KasaraPotro.Sender> senders = new List<KasaraPotro.Sender>();
                    if (potroParam.recipient.sender.Values.Select(x => x.designation_id).FirstOrDefault() == "0")
                    {
                        
                            senders= MappingModels.MapModel<List<KasaraPotro.Approver>, List <KasaraPotro.Sender>> (approvers);
                        
                    }
                    else
                    {
                        foreach (var item in potroParam.recipient.sender)
                        {
                            KasaraPotro.Sender sender = new KasaraPotro.Sender
                            {
                                Designation = item.Value.designation,
                                DesignationId = Convert.ToInt32(item.Value.designation_id),
                                Id = Convert.ToInt32(item.Value.id),
                                IsSent = Convert.ToInt32(item.Value.is_sent),
                                Label = item.Value.label,
                                Office = item.Value.office,
                                OfficeId = Convert.ToInt32(item.Value.office_id),
                                Officer = item.Value.officer,
                                OfficerEmail = item.Value.officer_email,
                                OfficerId = Convert.ToInt32(item.Value.officer_id),
                                OfficeUnit = item.Value.office_unit,
                                OfficeUnitId = Convert.ToInt32(item.Value.office_unit_id),
                                PotrojariId = Convert.ToInt32(item.Value.potrojari_id),
                                PotroStatus = item.Value.potro_status,
                                PotroType = Convert.ToInt32(item.Value.potro_status),
                                RecipientType = item.Value.recipient_type,
                                VisibleDesignation = null,
                                VisibleName = item.Value.visible_name


                            };
                            senders.Add(sender);
                        }
                    }

                    List<KasaraPotro.Attention> attentions = new List<KasaraPotro.Attention>();
                    if (potroParam.recipient.attention != null)
                    {
                        foreach (var item in potroParam.recipient.attention)
                        {
                            KasaraPotro.Attention attention = new KasaraPotro.Attention
                            {
                                Designation = item.Value.designation,
                                DesignationId = Convert.ToInt32(item.Value.designation_id),
                                Id = Convert.ToInt32(item.Value.id),
                                IsSent = Convert.ToInt32(item.Value.is_sent),
                                Label = item.Value.label,
                                Office = item.Value.office,
                                OfficeId = Convert.ToInt32(item.Value.office_id),
                                Officer = item.Value.officer,
                                OfficerEmail = item.Value.officer_email,
                                OfficerId = Convert.ToInt32(item.Value.officer_id),
                                OfficeUnit = item.Value.office_unit,
                                OfficeUnitId = Convert.ToInt32(item.Value.office_unit_id),
                                PotrojariId = Convert.ToInt32(item.Value.potrojari_id),
                                PotroStatus = item.Value.potro_status,
                                PotroType = Convert.ToInt32(item.Value.potro_status),
                                RecipientType = item.Value.recipient_type,
                                VisibleDesignation = null,
                                VisibleName = item.Value.visible_name


                            };
                            attentions.Add(attention);
                        }
                    }
                    else
                        attentions = null;
                    List<KasaraPotro.Onulipi> onulipis = new List<KasaraPotro.Onulipi>();
                    if (potroParam.recipient.onulipi != null)
                    {
                        foreach (var item in potroParam.recipient.onulipi)
                        {
                            KasaraPotro.Onulipi onulipi = new KasaraPotro.Onulipi
                            {
                                Designation = item.Value.designation,
                                DesignationId = Convert.ToInt32(item.Value.designation_id),
                                Id = Convert.ToInt32(item.Value.id),
                                IsSent = Convert.ToInt32(item.Value.is_sent),
                                Label = item.Value.label,
                                Office = item.Value.office,
                                OfficeId = Convert.ToInt32(item.Value.office_id),
                                Officer = item.Value.officer,
                                OfficerEmail = item.Value.officer_email,
                                OfficerId = Convert.ToInt32(item.Value.officer_id),
                                OfficeUnit = item.Value.office_unit,
                                OfficeUnitId = Convert.ToInt32(item.Value.office_unit_id),
                                PotrojariId = Convert.ToInt32(item.Value.potrojari_id),
                                PotroStatus = item.Value.potro_status,

                                VisibleName = item.Value.visible_name


                            };
                            onulipis.Add(onulipi);
                        }
                        onulipies = JsonParsingMethod.ObjecttoJson(onulipis);
                    }
                    else
                        onulipies = null;
                    List<KasaraPotro.Receiver> receivers = new List<KasaraPotro.Receiver>();
                    if (potroParam.recipient.receiver != null)
                    {

                        foreach (var item in potroParam.recipient.receiver)
                        {
                            KasaraPotro.Receiver receiver = new KasaraPotro.Receiver
                            {
                                Designation = item.Value.designation,
                                DesignationId = Convert.ToInt32(item.Value.designation_id),
                                Id = Convert.ToInt32(item.Value.id),
                                IsSent = Convert.ToInt32(item.Value.is_sent),
                                Label = item.Value.label,
                                Office = item.Value.office,
                                OfficeId = Convert.ToInt32(item.Value.office_id),
                                Officer = item.Value.officer,
                                OfficerEmail = item.Value.officer_email,
                                OfficerId = Convert.ToInt32(item.Value.officer_id),
                                OfficeUnit = item.Value.office_unit,
                                OfficeUnitId = Convert.ToInt32(item.Value.office_unit_id),
                                PotrojariId = Convert.ToInt32(item.Value.potrojari_id),
                                PotroStatus = item.Value.potro_status,

                                VisibleName = item.Value.visible_name


                            };
                            receivers.Add(receiver);
                        }

                        reciveres = JsonParsingMethod.ObjecttoJson(receivers);
                    }
                    else
                        reciveres = string.Empty;

                    KasaraPotro.Recipient recipient = new KasaraPotro.Recipient { Approver= approvers, Sender=senders, Attention=attentions, Onulipi= onulipies, Receiver= reciveres };

                    KasaraPotro.Record record = new KasaraPotro.Record { Basic = basic, NoteOnucched = noteOnucched, NoteOwner = noteOwner, Recipient = recipient,  Mulpotro=mulpotro, isLocal =true};
                   // if(approvers.Where(x=>x.DesignationId==dakUserParam.designation_id).FirstOrDefault())
                    records.Add(record);
                    
                }
                //nothikhoshrapotrolist.data.Records.Count() - localData.Count()


                for (int item=0;item<10;item++)
                {
                    records.Add(nothikhoshrapotrolist.data.Records[item]);
                }
                KasaraPotro.Data data = new KasaraPotro.Data { Records = records, TotalRecords =(nothikhoshrapotrolist.data.TotalRecords+ localData.Count()) };
                KasaraPotro kasaraPotro = new KasaraPotro { data = data, Status = "success" };

                return kasaraPotro;
            }
            
            try
            {
                var Api = new RestClient(GetAPIDomain() + GetEndPoint(menuNo));
                Api.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("api-version", GetAPIVersion());
                request.AddHeader("Authorization", "Bearer " + userParam.token);
                request.AlwaysMultipartFormData = true;

                request.AddParameter("cdesk", cdesk);

                request.AddParameter("page", userParam.page);
                request.AddParameter("limit", userParam.limit);
                if (!string.IsNullOrEmpty(userParam.NameSearchParam))
                {
                    request.AddParameter("search_params", searchParam);
                }
              
                IRestResponse Response = Api.Execute(request);
                var responseJson = Response.Content;

                responseJson = responseJson.Replace("\"recipient\":[]","\"recipient\":\"\"");
                SaveLocalllyKhosraList(responseJson, userParam, menuNo, cdesk, searchParam);
                KasaraPotro nothikhoshrapotrolist = JsonConvert.DeserializeObject<KasaraPotro>(responseJson, NullDeserializeSetting());
                return nothikhoshrapotrolist;
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public PrapakerTalika GetPrapakerTalika(DakUserParam userParam, int potro)
        {
                try
                {
                    var Api = new RestClient(GetAPIDomain() + GetEndPoint(6));
                    Api.Timeout = -1;
                    var request = new RestRequest(Method.POST);
                    request.AddHeader("api-version", GetAPIVersion());
                    request.AddHeader("Authorization", "Bearer " + userParam.token);
                    request.AlwaysMultipartFormData = true;


                    request.AddParameter("cdesk", "{\"office_id\":" + userParam.office_id + ",\"office_unit_id\":" + userParam.office_unit_id + ",\"designation_id\":" + userParam.designation_id + ",\"officer_id\":" + userParam.officer_id + ",\"user_id\":" + userParam.user_id + ",\"office\":\"" + userParam.office + "\",\"office_unit\":\"Technology\",\"designation\":\"" + userParam.designation + "\",\"officer\":\"" + userParam.officer + "\",\"designation_level\":" + userParam.designation_level + "}");
                    request.AddParameter("potro", potro);
                    IRestResponse Response = Api.Execute(request);


                    var responseJson = Response.Content;
                    responseJson = responseJson.Replace("\"data\":[]", "\"data\":\"\"");
                    PrapakerTalika nothikhoshrapotrolist = JsonConvert.DeserializeObject<PrapakerTalika>(responseJson, NullDeserializeSetting());
                    return nothikhoshrapotrolist;
                }
                catch (Exception ex)
                {
                    throw;
                }

             

        }

        public DakAttachmentResponse GetLocalMulpotroSanjukti(int kosraId)
        {
            DakAttachmentResponse dakAttachmentResponse = new DakAttachmentResponse();
            List<DakAttachmentDTO> data = new List<DakAttachmentDTO>();
            var localData = _localKhosraLocalRepository.Table.Where(x => x.Id== kosraId).FirstOrDefault();
            KhosraSaveParamPotro potroParam = JsonConvert.DeserializeObject<KhosraSaveParamPotro>(localData.potro);
            DakAttachmentDTO mulpotro = new DakAttachmentDTO {  potro_description= potroParam.potrojari.potro_description, content_body = potroParam.potrojari.potro_description, is_main = 1, file_name = potroParam.potrojaris.potro_type_name,user_file_name= potroParam.potrojaris.potro_type_name, attachment_type = "txt" };
            data.Add(mulpotro);
            foreach (var attachment in potroParam.attachments)
            {
                if (attachment.nothi_potro_id > 0)
                {
                    DakAttachmentDTO dakAttachment = new DakAttachmentDTO
                    {
                        file_name = attachment.user_file_name,
                        attachment_type = (attachment.user_file_name).Split('.').Last(),
                        user_file_name = attachment.user_file_name,
                        file_size_in_kb = string.Empty,
                        isLocal = true
                    };
                    data.Add(dakAttachment);
                }
            }

            var localAttachments= _localKhosraFileUploadRepository.Table.Where(x => x.KhosraId == kosraId).ToList();
            foreach(var localAttachment in localAttachments)
            {
                var dakAttachmentDTO = new DakAttachmentDTO { user_file_name= localAttachment.user_file_name, 
                    content_body= localAttachment.content,
                    file_size_in_kb = (localAttachment.file_size_in_kb).Split(' ').First(),
                     file_name= localAttachment.user_file_name,
                     attachment_type= (localAttachment.user_file_name).Split('.').Last(),
                    isLocal=true,
                     id= localAttachment.Id

                };
                data.Add(dakAttachmentDTO);
            }
            dakAttachmentResponse.data = data;
            dakAttachmentResponse.status = "localsuccess";
            return dakAttachmentResponse;

        }
        public DakAttachmentResponse GetMulPattraAndSanjukti(DakUserParam userParam, KasaraPotro.Record record)
        {

            try
            {
                var Api = new RestClient(GetAPIDomain() + GetEndPoint(7));
                Api.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("api-version", GetAPIVersion());
                request.AddHeader("Authorization", "Bearer " + userParam.token);
                request.AlwaysMultipartFormData = true;

               
                request.AddParameter("cdesk", "{\"office_id\":" + userParam.office_id + ",\"office_unit_id\":" + userParam.office_unit_id + ",\"designation_id\":" + userParam.designation_id + ",\"officer_id\":" + userParam.officer_id + "," +
                    "\"user_id\":" + userParam.user_id + ",\"office\":\"" + userParam.office + "\"," +
                    "\"office_unit\":\"" + userParam.office_unit + "\",\"designation\":\"" + userParam.designation + "\"," +
                    "\"officer\":\"" + userParam.officer + "\",\"designation_level\":" + userParam.designation_level + "," +
                    "\"officer_email\":" + userParam.officer_email + ",\"officer_mobile\":" + userParam.officer_mobile + "}");
                if (record.Basic.PotroType != 0)
                {
                    request.AddParameter("potro", "{\"nothi_id\":\"" + record.Basic.NothiMasterId + "\",\"nothi_office\":\"" + userParam.office_id + "\"," +
                    "\"note_id\":\"" + record.Basic.NothiNoteId + "\",\"onucched_id\":\"" + record.NoteOnucched.Id + "\"," +
                    "\"nothi_potro_id\":\"" + record.Basic.NothiPotroId + "\",\"potrojari_id\":\"" + record.Basic.Id + "\",\"cloned_potrojari_id\":\"" + record.Basic.ClonedPotrojariId + "\"," +
                    "\"nothi_potro_attachment_id\":\"" + record.Basic.NothiPotroAttachmentId + "\",\"potro_type\":\"" + record.Basic.PotroType + "\",\"sarok_no\":\"" + record.Basic.SarokNo + "\",\"potro_subject\":\"" + record.Basic.PotroSubject + "\"}");

                }
                else
                {
                    request.AddParameter("potro", "{\"sarok_no\": \"" + record.Basic.SarokNo + "\",\"potro_subject\": \" " + record.Basic.PotroSubject + "\",\"nothi_potro_id\": \"" + record.Basic.Id + "\",\"nothi_id\": \"" + record.Basic.NothiMasterId + "\",\"nothi_office\": \"" + userParam.office_id + "\"}");

                }
                IRestResponse Response = Api.Execute(request);


                var responseJson = Response.Content;

                DakAttachmentResponse attachmentlist = JsonConvert.DeserializeObject<DakAttachmentResponse>(responseJson, NullDeserializeSetting());
                return attachmentlist;
            }
            catch (Exception ex)
            {
                throw;
            }



        }

        public ResponseModel KasaraDashBoardRecordCount(DakUserParam userParam)
        {
            try
            {
                var Api = new RestClient(GetAPIDomain() + GetEndPoint(8));
                Api.Timeout = -1;
                var request = new RestRequest(Method.POST);

                request.AddHeader("api-version", "1");

                request.AddHeader("Authorization", "Bearer " + userParam.token);

                request.AlwaysMultipartFormData = true;

                request.AddParameter("cdesk", "{\"office_id\":" + userParam.office_id + ",\"office_unit_id\":" + userParam.office_unit_id + ",\"designation_id\":" + userParam.designation_id + ",\"officer_id\":" + userParam.officer_id + ",\"user_id\":" + userParam.user_id + ",\"office\":\"" + userParam.office + "\",\"office_unit\":\"" + userParam.office_unit + "\",\"designation\":\"" + userParam.designation + "\",\"officer\":\"" + userParam.officer + "\",\"designation_level\":" + userParam.designation_level + "}");

                IRestResponse Response = Api.Execute(request);
              
                var responseJson = Response.Content;

                ResponseModel response = JsonConvert.DeserializeObject<ResponseModel>(responseJson, NullDeserializeSetting());

                return response;
            }
            catch (Exception ex)
            {
                throw;
            }


        }

        private string GetLocalKhasraList(DakUserParam userParam, int menuid,string cdesk,string searchParam)
        {
            var khasraData = _localKhosraListLocalRepository.Table.
                Where(x=>x.cdesk== cdesk && x.limit==userParam.limit && x.MenuId==menuid && x.page==userParam.page && x.search_params== searchParam)
                .FirstOrDefault();

            if (khasraData != null)
            {
                return khasraData.responseData;
            }
            else
            {
                return "";
            }

        }
        private void SaveLocalllyKhosraList(string responseJson, DakUserParam userParam, int menuid, string cdesk, string searchParam)
        {

            var khasraData = _localKhosraListLocalRepository.Table.
                Where(x => x.cdesk == cdesk && x.limit == userParam.limit && x.MenuId == menuid && x.page == userParam.page && x.search_params == searchParam)
                .FirstOrDefault();

            if (khasraData != null)
            {
                khasraData.responseData = responseJson;
                _localKhosraListLocalRepository.Update(khasraData);
            }
            else
            {
                KhosraListLocal localkasraList = new KhosraListLocal
                {
                    cdesk = cdesk,
                    MenuId = menuid,
                    page = userParam.page,
                    limit = userParam.limit,
                    search_params = searchParam,
                    responseData = responseJson,
                    isLocal = true
                     
                };
                _localKhosraListLocalRepository.Insert(localkasraList);
            }

        }

        private JsonSerializerSettings NullDeserializeSetting()
        {
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };
            return settings;
        }
        protected string GetAPIDomain()
        {
            return ReadAppSettings("api-endpoint") ?? DefaultAPIConfiguration.DefaultAPIDomainAddress;
        }
        protected string GetEndPoint(int code)
        {
            string endPoint = string.Empty;
            if (code == 1)
            {
                endPoint = DefaultAPIConfiguration.nothidraftpotrolist;
            }
            if (code == 2)
            {
                endPoint = DefaultAPIConfiguration.nothikhoshrapotrolist;
            }
            if (code == 3)
            {
                endPoint = DefaultAPIConfiguration.nothikhoshrawaitingforapprovallist;
            }
            if (code == 4)
            {
                endPoint = DefaultAPIConfiguration.nothiapprovedpotrolist;
            }
            if (code == 5)
            {
                endPoint = DefaultAPIConfiguration.nothipotrojariassenderapproverlist;
            }
            if (code == 6)
            {
                endPoint = DefaultAPIConfiguration.prapakerTalika;
            }
            if (code == 7)
            {
                endPoint = DefaultAPIConfiguration.mulPattraAndSanjukti;
            }
            if (code == 8)
            {
                endPoint = DefaultAPIConfiguration.kasaraDashboard;
            }
            return endPoint;
        }
        protected string GetAPIVersion()
        {
            return ReadAppSettings("newapi-version") ?? DefaultAPIConfiguration.NewAPIversion;
        }
        protected string ReadAppSettings(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}
