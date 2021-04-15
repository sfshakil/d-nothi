using AutoMapper;
using dNothi.Constants;
using dNothi.Core.Entities;
using dNothi.Core.Interfaces;
using dNothi.JsonParser.Entity;
using dNothi.JsonParser.Entity.Dak;
using dNothi.JsonParser.Entity.Dak_List_Inbox;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace dNothi.Services.DakServices
{
  public class DakListService:IDakListService
    {
        IRepository<DakTag> _dakTagsRepo;
        IRepository<DakItem> _dakItems;
        IRepository<DakItemDetails> _dakItemDetails;
        IRepository<DakAttachment> _dakAttachment;
        IRepository<DakUser> _dakUserRepo;
        IRepository<DakType> _dakTypeRepo;
        IRepository<PotroTemplateList> _potroTemplateLocalList;
       
        IRepository<DakList> _dakListRepo;
     
        IRepository<DakOrigin> _dakOriginRepo;
        IRepository<Officer> _fromRepo;
        IRepository<To> _toRepo;
        IRepository<Other> _otherRepo;
        IRepository<MovementStatus> _movementStatusRepo;
       
        IDakForwardService _dakForwardService { get; set; }
        IRepository<DakNothi> _dakNothiRepo;
        public DakListService(IRepository<DakTag> daktags,
            IRepository<DakUser> dakuser,
              IRepository<PotroTemplateList> potroTemplateLocalList,
            IRepository<Officer> from,
            IRepository<Other> other,
            IRepository<To> to,
             IDakForwardService dakForwardService,
            IRepository<MovementStatus> movementStatus,
            IRepository<DakAttachment> dakAttachment,
            IRepository<DakItem> dakItems,
            IRepository<DakItemDetails> dakItemDetails,
            IRepository<DakNothi> dakNothi,
            IRepository<DakOrigin> dakOrigin,
            IRepository<DakType> daktype,
          
            IRepository<DakList> dakList
           
        
            )
        {
            this._dakTagsRepo = daktags;
            this._dakUserRepo = dakuser;
            this._fromRepo = from;
            this._otherRepo = other;
            this._dakAttachment = dakAttachment;
            _potroTemplateLocalList = potroTemplateLocalList;
            this._toRepo = to;
            this._movementStatusRepo = movementStatus;
            this._dakTypeRepo = daktype;
            this._dakNothiRepo = dakNothi;
            this._dakOriginRepo = dakOrigin;
       
            this._dakListRepo = dakList;
            _dakItems = dakItems;
            _dakItemDetails=dakItemDetails;
            _dakForwardService = dakForwardService;
        
        }


        public void DakDeleteUsingId(long id)
        {
             var dbdak = _dakListRepo.Table.Where(q => q.dak_user.dak_id == id).FirstOrDefault();
            if (dbdak != null)
            {
                _dakListRepo.Delete(dbdak);
            }
        }




        private long SaveOrUpdateNothi(NothiDTO nothiDTO)
        {
            var config = new MapperConfiguration(cfg =>
                      cfg.CreateMap<NothiDTO, DakNothi>()
                  );
            var mapper = new Mapper(config);
            var dakNothi = mapper.Map<DakNothi>(nothiDTO);
            dakNothi.nothi_id = nothiDTO.nothi_id;
            var dbdakNothi = _dakNothiRepo.Table.Where(q => q.dak_id == nothiDTO.dak_id).FirstOrDefault();
            if (dbdakNothi == null)
            {
                _dakNothiRepo.Insert(dakNothi);
            }
            else
            {
                dakNothi.Id = dbdakNothi.Id;
                _dakNothiRepo.Update(dakNothi);
            }

            return dakNothi.Id;
        }

        private long? SaveOrUpdateMovementStatus(MovementStatusDTO movement_statusDTO)
        {
            MovementStatus movementStatus = new MovementStatus();
          
           if(movement_statusDTO.from!=null)

            {
                movementStatus.from_id = SaveOrUpdateOfficer(movement_statusDTO.from);
            } 
            
            if(movement_statusDTO.other!=null)

            {
                movementStatus.other_id = SaveOrUpdateOther(movement_statusDTO.other);

                var dbmovementstatus = _movementStatusRepo.Table.FirstOrDefault(a => a.other.otherId == movement_statusDTO.other.dak_origin_id);
                if (dbmovementstatus != null)
                {
                    movementStatus.Id = dbmovementstatus.Id;
                    _movementStatusRepo.Update(movementStatus);
                }
                else
                {
                    _movementStatusRepo.Insert(movementStatus);

                }
            }

           

            if (movementStatus.to != null && movementStatus.Id!=0)
            {
                foreach(ToDTO to in movement_statusDTO.to)
                {
                    SaveOrUpdateTo(to, movementStatus.Id);
                }
            }

            // Place code for deleting some To list from MovementStatus

            if(movementStatus.Id!=0)
            {
                return movementStatus.Id;
            }
            else
            {
                return null;
            }
          

        }

       

        private long SaveOrUpdateTo(ToDTO toDTO, long id)
        {
            var config = new MapperConfiguration(cfg =>
                      cfg.CreateMap<ToDTO, FromDTO>()
                  );
            var mapper = new Mapper(config);
            var officer = mapper.Map<FromDTO>(toDTO);

            To to = new To();
            to.attention_type = toDTO.attention_type;
            to.to_id = SaveOrUpdateOfficer(officer);






            var dbto = _toRepo.Table.FirstOrDefault(a => a.to_id == to.to_id && a.movement_status_id == to.movement_status_id);
            
            if(dbto != null)
            {
                to.Id = dbto.Id;
                _toRepo.Update(to);
            }
            else
            {
                _toRepo.Insert(to);
            }
               
          
            return to.Id;
        }

        private long SaveOrUpdateOther(OtherDTO otherDTO)
        {
            var config = new MapperConfiguration(cfg =>
                      cfg.CreateMap<OtherDTO, Other>()
                  );
            var mapper = new Mapper(config);
            var other = mapper.Map<Other>(otherDTO);
            other.otherId = otherDTO.dak_origin_id;
            var dbother = _otherRepo.Table.Where(q => q.otherId == otherDTO.dak_origin_id).FirstOrDefault();
            if (dbother == null)
            {
                _otherRepo.Insert(other);
            }
            else
            {
                other.Id = dbother.Id;
                _otherRepo.Update(other);
            }

            return other.Id;
        }

        private long SaveOrUpdateOfficer(FromDTO fromDTO)
        {
            var config = new MapperConfiguration(cfg =>
                      cfg.CreateMap<FromDTO, Officer>()
                  );
            var mapper = new Mapper(config);
            var from = mapper.Map<Officer>(fromDTO);
            var dbfrom = _fromRepo.Table.FirstOrDefault(a => a.designation_id == fromDTO.designation_id);
            if(dbfrom != null)
            {
                from.Id = dbfrom.Id;
                _fromRepo.Update(from);
            }
            else
            {
                _fromRepo.Insert(from);
            }
           
               
           

            return from.Id;
        }

        private long SaveOrUpdateDakOrigin(DakOriginDTO dak_origin)
        {
            var config = new MapperConfiguration(cfg =>
                     cfg.CreateMap<DakOriginDTO, DakOrigin>()
                 );
            var mapper = new Mapper(config);
            var dakorigin = mapper.Map<DakOrigin>(dak_origin);
            dakorigin.dak_origin_id = dak_origin.dak_origin_id;
            var dbdakOrigin = _dakOriginRepo.Table.Where(q => q.dak_origin_id == dak_origin.dak_origin_id).FirstOrDefault();
            if (dbdakOrigin == null)
            {
                _dakOriginRepo.Insert(dakorigin);
            }
            else
            {
                dakorigin.Id = dbdakOrigin.Id;
                _dakOriginRepo.Update(dakorigin);
            }

            return dakorigin.Id;
        }

        private long SaveOrUpdateDakTag(DakTagDTO dak_Tagsdto, long id)
        {
            var config = new MapperConfiguration(cfg =>
                    cfg.CreateMap<DakTagDTO, DakTag>()
                );
            var mapper = new Mapper(config);
            var daktag = mapper.Map<DakTag>(dak_Tagsdto);
            daktag.dak_tag_id = dak_Tagsdto.id;
            daktag.dak_list_id = id;
            var dbdaktag = _dakTagsRepo.Table.Where(q => q.dak_tag_id == dak_Tagsdto.id ).FirstOrDefault();
            if (dbdaktag == null)
            {
                _dakTagsRepo.Insert(daktag);
            }
            else
            {
                daktag.Id = dbdaktag.Id;
                _dakTagsRepo.Update(daktag);
            }

            return daktag.Id;
        }

        private long SaveOrUpdateAttachment(DakAttachmentDTO attachmentDTO, long id)
        {
            var config = new MapperConfiguration(cfg =>
                    cfg.CreateMap<DakAttachmentDTO, DakAttachment>()
                );
            var mapper = new Mapper(config);
            var attachment = mapper.Map<DakAttachment>(attachmentDTO);
            attachment.attachment_id = attachmentDTO.id;
            attachment.dak_list_id = id;           
            var dbattachment = _dakAttachment.Table.FirstOrDefault(q => q.attachment_id == attachmentDTO.id);
            if (dbattachment == null)
            {
                _dakAttachment.Insert(attachment);
            }
            else
            {
                attachment.Id = dbattachment.Id;
                _dakAttachment.Update(attachment);
            }

            return attachment.Id;
        }

        private long SaveOrUpdateDakUser(DakUserDTO dak_Userdto)
        {
            var config = new MapperConfiguration(cfg =>
                     cfg.CreateMap<DakUserDTO, DakUser>()
                 );
            var mapper = new Mapper(config);
            var dakuser = mapper.Map<DakUser>(dak_Userdto);
            var dbdaktuser = _dakUserRepo.Table.Where(q => q.dak_id == dak_Userdto.dak_id).FirstOrDefault();
            if (dbdaktuser == null)
            {
                _dakUserRepo.Insert(dakuser);
            }
            else
            {
                dakuser.Id = dbdaktuser.Id;
                _dakUserRepo.Update(dakuser);
            }

            return dakuser.Id;
        }

        public void SaveOrUpdateDakList(DakListDTO data, long dakTypeId)
        {
           
          
            if(data != null)
            {
                if(data.records.Count > 0)
                {
                    foreach (DakListRecordsDTO dakListRecordsDTO in data.records)
                    {
                        if (dakListRecordsDTO != null)
                        {
                            DakList dakList = new DakList();

                            
                            dakList.attachment_count = dakListRecordsDTO.attachment_count;
                            dakList.dak_List_type_Id = dakTypeId;


                            if (dakListRecordsDTO.dak_origin != null)
                            {
                                dakList.dak_origin_id = SaveOrUpdateDakOrigin(dakListRecordsDTO.dak_origin);
                            }
                            else
                            {
                                dakList.dak_origin_id = null;
                            }

                            if (dakListRecordsDTO.movement_status != null)
                            {
                                dakList.movement_status_id = SaveOrUpdateMovementStatus(dakListRecordsDTO.movement_status);
                            }
                            else
                            {
                                dakList.movement_status_id = null;
                            }

                            if (dakListRecordsDTO.dak_user != null)
                            {
                                dakList.dak_user_id = SaveOrUpdateDakUser(dakListRecordsDTO.dak_user);
                            }

                            else
                            {
                                dakList.dak_user_id = null;
                            }

                            if (dakListRecordsDTO.nothi != null)
                                {
                                    dakList.dak_nothi_id = SaveOrUpdateNothi(dakListRecordsDTO.nothi);
                                }
                            else
                            {
                                dakList.dak_nothi_id = null;
                            }

                            var dbdaklist = _dakListRepo.Table.FirstOrDefault(a => a.dak_user.dak_id == dakListRecordsDTO.dak_user.dak_id);
                            if(dbdaklist == null)
                            {
                                _dakListRepo.Insert(dakList);
                            }
                            else
                            {
                                dakList.Id = dbdaklist.Id;
                                _dakListRepo.Update(dakList);
                            }
                            


                            if (dakListRecordsDTO.dak_Tags != null)
                            {
                                foreach (DakTagDTO dakTagDTO in dakListRecordsDTO.dak_Tags)
                                {
                                    SaveOrUpdateDakTag(dakTagDTO, dakList.Id);
                                }
                            }

                            if (dakListRecordsDTO.dak_Tags != null)
                            {
                                foreach (DakTagDTO dakTagDTO in dakListRecordsDTO.dak_Tags)
                                {
                                    SaveOrUpdateDakTag(dakTagDTO, dakList.Id);
                                }
                            }
                        }
                    }
                }
            }

            
        }

       public void SaveOrUpdateDakList(List<DakListWithDetailsRecordDTO> records)
        {


            if (records.Count > 0)
            {
                foreach (DakListWithDetailsRecordDTO dakListRecordsDTO in records)
                {
                    if (dakListRecordsDTO != null)
                    {
                        DakList dakList = new DakList();


                        dakList.attachment_count = dakListRecordsDTO.attachment_count;
                        dakList.dak_List_type_Id = 1;


                        if (dakListRecordsDTO.dak_origin != null)
                        {
                            dakList.dak_origin_id = SaveOrUpdateDakOrigin(dakListRecordsDTO.dak_origin);
                        }
                        else
                        {
                            dakList.dak_origin_id = null;
                        }

                        if (dakListRecordsDTO.movement_status != null)
                        {
                            dakList.movement_status_id = SaveOrUpdateMovementStatus(dakListRecordsDTO.movement_status);
                        }
                        else
                        {
                            dakList.movement_status_id = null;
                        }

                        if (dakListRecordsDTO.dak_user != null)
                        {
                            dakList.dak_user_id = SaveOrUpdateDakUser(dakListRecordsDTO.dak_user);
                        }

                        else
                        {
                            dakList.dak_user_id = null;
                        }

                        if (dakListRecordsDTO.nothi != null)
                        {
                            dakList.dak_nothi_id = SaveOrUpdateNothi(dakListRecordsDTO.nothi);
                        }
                        else
                        {
                            dakList.dak_nothi_id = null;
                        }

                        var dbdaklist = _dakListRepo.Table.FirstOrDefault(a => a.dak_user.dak_id == dakListRecordsDTO.dak_user.dak_id);
                        if (dbdaklist == null)
                        {
                            _dakListRepo.Insert(dakList);
                        }
                        else
                        {
                            dakList.Id = dbdaklist.Id;
                            _dakListRepo.Update(dakList);
                        }



                        if (dakListRecordsDTO.dak_Tags != null)
                        {
                            foreach (DakTagDTO dakTagDTO in dakListRecordsDTO.dak_Tags)
                            {
                                SaveOrUpdateDakTag(dakTagDTO, dakList.Id);
                            }
                        }

                        if (dakListRecordsDTO.dak_Tags != null)
                        {
                            foreach (DakTagDTO dakTagDTO in dakListRecordsDTO.dak_Tags)
                            {
                                SaveOrUpdateDakTag(dakTagDTO, dakList.Id);
                            }
                        }
                        if (dakListRecordsDTO.attachment.Count > 0)
                        {
                            foreach (DakAttachmentDTO attachmentDTO in dakListRecordsDTO.attachment)
                            {
                                SaveOrUpdateAttachment(attachmentDTO, dakList.Id);
                            }
                        }
                    }
                }
            }
            


        }

        public List<DakList> GetDakList()
        {
            var dbdakType = _dakTypeRepo.Table.FirstOrDefault(a => a.is_inbox == true);
            var dakList=_dakListRepo.Table.Where(d => d.dak_List_type_Id == dbdakType.Id).ToList();
            return dakList;
        }

        public List<DakItem> GetLocalDakIdList(int page)
        {


            var dakItems = _dakItems.Table.Where(a => a.page == page).ToList();

          
            return dakItems;
        }

        public DakListDTO GetLocalDakListbyType(long dakTypeId, DakUserParam dakListUserParam)
        {
            DakListDTO dakListDTO = new DakListDTO();
            var dbdaklist = _dakListRepo.Table.Include(a=>a.dak_origin).Include(a => a.dak_user).Include(a => a.dak_Tags).Include(a => a.nothi).Include(a => a.movement_status).Where(a => a.dak_List_type_Id == dakTypeId).ToList();
            List<DakListRecordsDTO> dakListRecords = new List<DakListRecordsDTO>();

            if (dbdaklist.Count>0)
            {
                
               dakListDTO.total_records = dbdaklist.Count;
               dbdaklist = dbdaklist.Take(dakListUserParam.limit + 1).ToList();
               
                foreach(DakList dakList in dbdaklist)
                {
                    DakListRecordsDTO dakListRecordsDTO = new DakListRecordsDTO();
                    dakListRecordsDTO.attachment_count = dakList.attachment_count;
                    dakListRecordsDTO.dak_origin = MapDakOrigintoDakOriginDTO(dakList.dak_origin);
                    dakListRecordsDTO.dak_user = MapDakUsertoDakUserDTO(dakList.dak_user);
                    dakListRecordsDTO.dak_Tags = MapDakTagtoDakTagDTO(dakList.dak_Tags);
                    dakListRecordsDTO.movement_status = MapMovementStatustoMovementStatusDTO(dakList.movement_status);
                    dakListRecordsDTO.nothi = MapNothitoNothiDTO(dakList.nothi);

                    dakListRecords.Add(dakListRecordsDTO);
                }

            }

            dakListDTO.records=(dakListRecords);
            return dakListDTO;

        }

        private NothiDTO MapNothitoNothiDTO(DakNothi nothi)
        {
            var config = new MapperConfiguration(cfg =>
                     cfg.CreateMap<DakNothi, NothiDTO>()
                 );
            var mapper = new Mapper(config);
            var nothiDTO = mapper.Map<NothiDTO>(nothi);

            return nothiDTO;
        }

        private MovementStatusDTO MapMovementStatustoMovementStatusDTO(MovementStatus movement_status)
        {
            MovementStatusDTO movementStatusDTO = new MovementStatusDTO();
            if(movement_status.from != null)
            {
                movementStatusDTO.from = MapFromtoFromDTO(movement_status.from);
                movementStatusDTO.to = MapTotoToDTO(movement_status.to);
                movementStatusDTO.other = MapOthertoOtherDTO(movement_status.other);
            }
            return movementStatusDTO;
        }

        private OtherDTO MapOthertoOtherDTO(Other other)
        {
            var config = new MapperConfiguration(cfg =>
                   cfg.CreateMap<Other, OtherDTO>()
               );
            var mapper = new Mapper(config);
            var otherDTO = mapper.Map<OtherDTO>(other);

            return otherDTO;
        }

        private List<ToDTO> MapTotoToDTO(ICollection<To> to)
        {
            List<ToDTO> toDTOs = new List<ToDTO>();
            if(to.Count>0)
            {
                foreach(To to1 in to)
                {
                   
                    var config = new MapperConfiguration(cfg =>
                  cfg.CreateMap<Officer, ToDTO>()
                      );
                    var mapper = new Mapper(config);
                    var toDTO = mapper.Map<ToDTO>(to1.to);
                    toDTO.attention_type = to1.attention_type;

                    toDTOs.Add(toDTO);
                }
            }

            return toDTOs;
        }

        private FromDTO MapFromtoFromDTO(Officer from)
        {
            var config = new MapperConfiguration(cfg =>
                   cfg.CreateMap<Officer, FromDTO>()
               );
            var mapper = new Mapper(config);
            var fromDTO = mapper.Map<FromDTO>(from);

            return fromDTO;
        }

        private List<DakTagDTO> MapDakTagtoDakTagDTO(ICollection<DakTag> dak_Tags)
        {
            List<DakTagDTO> dakTagDTOs = new List<DakTagDTO>();
            if (dak_Tags.Count > 0)
            {
                foreach (DakTag dakTag in dak_Tags)
                {

                    var config = new MapperConfiguration(cfg =>
                  cfg.CreateMap<DakTag, DakTagDTO>()
                      );
                    var mapper = new Mapper(config);
                    var dakTagDTO = mapper.Map<DakTagDTO>(dakTag);


                    dakTagDTOs.Add(dakTagDTO);
                }
            }
            return dakTagDTOs;
        }

        private DakUserDTO MapDakUsertoDakUserDTO(DakUser dak_user)
        {
            var config = new MapperConfiguration(cfg =>
                    cfg.CreateMap<DakUser, DakUserDTO>()
                );
            var mapper = new Mapper(config);
            var dakUserDTO = mapper.Map<DakUserDTO>(dak_user);

            return dakUserDTO;
        }

        private DakOriginDTO MapDakOrigintoDakOriginDTO(DakOrigin dak_origin)
        {
            var config = new MapperConfiguration(cfg =>
                    cfg.CreateMap<DakOrigin, DakOriginDTO>()
                );
            var mapper = new Mapper(config);
            var dak_originDTO = mapper.Map<DakOriginDTO>(dak_origin);

            return dak_originDTO;
        }

        public DakDetailsResponse GetDakDetailsbyDakId(int dak_id,string dak_type, int is_copied_dak,  DakUserParam dakListUserParam)
        {
            DakDetailsResponse dakDetailsResponse = new DakDetailsResponse();
            if (!dNothi.Utility.InternetConnection.Check())
            {
                var dakDetails = _dakItemDetails.Table.FirstOrDefault(a => a.dak_id == dak_id && a.is_copied_dak == is_copied_dak && a.dak_type == dak_type);

                if (dakDetails != null && dakDetails.dak_details_Json !=null)
                {
                    dakDetailsResponse = JsonConvert.DeserializeObject<DakDetailsResponse>(dakDetails.dak_details_Json);

                }
                return dakDetailsResponse;
            }

            try
            {

                var dakInboxApi = new RestClient(GetAPIDomain() + GetDakDetailsEndpoint());
                dakInboxApi.Timeout = -1;
                var dakInboxRequest = new RestRequest(Method.POST);
                dakInboxRequest.AddHeader("api-version", GetAPIVersion());
                dakInboxRequest.AddHeader("Authorization", "Bearer " + dakListUserParam.token);
                dakInboxRequest.AlwaysMultipartFormData = true;
                dakInboxRequest.AddParameter("designation_id", dakListUserParam.designation_id);
                dakInboxRequest.AddParameter("office_id", dakListUserParam.office_id);
                dakInboxRequest.AddParameter("dak_id", dak_id);
                dakInboxRequest.AddParameter("dak_type", dak_type);
                dakInboxRequest.AddParameter("is_copied_dak", is_copied_dak);
                IRestResponse dakdetailsResponseAPI = dakInboxApi.Execute(dakInboxRequest);


                var dakdetailsResponseJson = dakdetailsResponseAPI.Content;
                SaveorUpdateDakItemDetails(dak_id,is_copied_dak,dak_type,dakdetailsResponseJson);
                dakDetailsResponse = JsonConvert.DeserializeObject<DakDetailsResponse>(dakdetailsResponseJson);
                return dakDetailsResponse;
            }
            catch (Exception ex)
            {
                throw;
            }


        }

        protected string GetAPIVersion()
        {
            return ReadAppSettings("newapi-version") ?? DefaultAPIConfiguration.NewAPIversion;
        }
        protected string GetOldAPIVersion()
        {
            return ReadAppSettings("api-version") ?? DefaultAPIConfiguration.NewAPIversion;
        }
        protected string ReadAppSettings(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }


        protected string GetAPIDomain()
        {
            return ReadAppSettings("api-endpoint") ?? DefaultAPIConfiguration.DefaultAPIDomainAddress;
        }


        protected string GetDakDetailsEndpoint()
        {
            return DefaultAPIConfiguration.DakDetailsEndpoint;
        }
        protected string GetDakAttachmentEndpoint()
        {
            return DefaultAPIConfiguration.DakAttachmentEndpoint;
        }
        protected string GetDakMovementStatusListEndpoint()
        {
            return DefaultAPIConfiguration.DakMovementStatusListEndpoint;
        }
        protected string GetDakListFromFolderEndPoint()
        {
            return DefaultAPIConfiguration.DakListFromFolderEndPoint;
        }

        protected string GetPotroTemplateEndpoint()
        {
            return DefaultAPIConfiguration.PotroTemplateEndPoint;
        }
        public PotroTemplateResponse GetPotroTemplate(DakUserParam dakListUserParam)
        {
            PotroTemplateResponse potroTemplateResponse = new PotroTemplateResponse();
            try
            {
                if (!dNothi.Utility.InternetConnection.Check())
                {
                    var potroTemplateList = _potroTemplateLocalList.Table.FirstOrDefault(a => a._designationId == dakListUserParam.designation_id && a._officeId == dakListUserParam.office_id);

                    if (potroTemplateList != null && potroTemplateList.jsonResponse != null)
                    {
                        potroTemplateResponse = JsonConvert.DeserializeObject<PotroTemplateResponse>(potroTemplateList.jsonResponse);

                    }
                    return potroTemplateResponse;
                }

                var potroTemplateApi = new RestClient(GetAPIDomain() + GetPotroTemplateEndpoint());
                potroTemplateApi.Timeout = -1;
                var potroTemplateRequest = new RestRequest(Method.POST);
                potroTemplateRequest.AddHeader("api-version", GetOldAPIVersion());
                potroTemplateRequest.AddHeader("Authorization", "Bearer " + dakListUserParam.token);
                potroTemplateRequest.AlwaysMultipartFormData = true;
                potroTemplateRequest.AddParameter("cdesk", "{\"office_id\":\"" + dakListUserParam.office_id + "\",\"office_unit_id\":\"" + dakListUserParam.office_unit_id + "\",\"designation_id\":\"" + dakListUserParam.designation_id + "\"}");
                IRestResponse potroTemplateResponseAPI = potroTemplateApi.Execute(potroTemplateRequest);


                var potroTemplateResponseJson = potroTemplateResponseAPI.Content;
                SavePotroTemplateLocally(dakListUserParam, potroTemplateResponseJson);
                potroTemplateResponse = JsonConvert.DeserializeObject<PotroTemplateResponse>(potroTemplateResponseJson);
                 
                
                return potroTemplateResponse;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private void SavePotroTemplateLocally(DakUserParam dakListUserParam, string potroTemplateResponseJson)
        {
            var potroTemplateList = _potroTemplateLocalList.Table.FirstOrDefault(a => a._designationId == dakListUserParam.designation_id && a._officeId == dakListUserParam.office_id);
            if(potroTemplateList == null)
            {
                potroTemplateList = new PotroTemplateList 
                { _designationId = dakListUserParam.designation_id, 
                    _officeId = dakListUserParam.office_id, 
                    jsonResponse = potroTemplateResponseJson };
                _potroTemplateLocalList.Insert(potroTemplateList);
            }
            else
            {
                potroTemplateList.jsonResponse = potroTemplateResponseJson;
                _potroTemplateLocalList.Update(potroTemplateList);
            }
        }

        public DakAttachmentResponse GetDakAttachmentbyDakId(int dak_id, string dak_type, int is_copied_dak, DakUserParam dakListUserParam)
        {

            DakAttachmentResponse dakAttachmentResponse = new DakAttachmentResponse();
            if (!dNothi.Utility.InternetConnection.Check())
            {
                var dakDetails = _dakItemDetails.Table.FirstOrDefault(a => a.dak_id == dak_id && a.is_copied_dak == is_copied_dak && a.dak_type == dak_type);

                if (dakDetails != null && dakDetails.dak_attachment_Json !=null)
                {
                    dakAttachmentResponse = JsonConvert.DeserializeObject<DakAttachmentResponse>(dakDetails.dak_attachment_Json);

                }
                return dakAttachmentResponse;
            }

            try
            {

                var dakAttachmentApi = new RestClient(GetAPIDomain() + GetDakAttachmentEndpoint());
                dakAttachmentApi.Timeout = -1;
                var dakAttachmentRequest = new RestRequest(Method.POST);
                dakAttachmentRequest.AddHeader("api-version", GetOldAPIVersion());
                dakAttachmentRequest.AddHeader("Authorization", "Bearer " + dakListUserParam.token);
                dakAttachmentRequest.AlwaysMultipartFormData = true;
                dakAttachmentRequest.AddParameter("designation_id", dakListUserParam.designation_id);
                dakAttachmentRequest.AddParameter("office_id", dakListUserParam.office_id);
                dakAttachmentRequest.AddParameter("dak_id", dak_id);
                dakAttachmentRequest.AddParameter("dak_type", dak_type);
                dakAttachmentRequest.AddParameter("is_copied_dak", is_copied_dak);
                IRestResponse dakAttachmentResponseAPI = dakAttachmentApi.Execute(dakAttachmentRequest);


                var dakAttachmentResponseJson = dakAttachmentResponseAPI.Content;
                SaveorUpdateDakItemAttachment(dak_id, is_copied_dak, dak_type, dakAttachmentResponseJson);
                dakAttachmentResponse = JsonConvert.DeserializeObject<DakAttachmentResponse>(dakAttachmentResponseJson);
                return dakAttachmentResponse;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DakMovementStatusResponse GetDakMovementStatusListbyDakId(int dak_id, string dak_type, int is_copied_dak, DakUserParam dakListUserParam)
        {
            DakMovementStatusResponse dakMovementStatusResponse = new DakMovementStatusResponse();
            if (!dNothi.Utility.InternetConnection.Check())
            {
                var dakDetails = _dakItemDetails.Table.FirstOrDefault(a => a.dak_id == dak_id && a.is_copied_dak == is_copied_dak && a.dak_type == dak_type);

                if (dakDetails != null && dakDetails.dak_movement_status_Json !=null)
                {
                    dakMovementStatusResponse = JsonConvert.DeserializeObject<DakMovementStatusResponse>(dakDetails.dak_movement_status_Json);

                }
                return dakMovementStatusResponse;
            }
            try
            {

                var dakMovementStatusApi = new RestClient(GetAPIDomain() + GetDakMovementStatusListEndpoint());
                dakMovementStatusApi.Timeout = -1;
                var dakMovementStatusRequest = new RestRequest(Method.POST);
                dakMovementStatusRequest.AddHeader("api-version", GetOldAPIVersion());
                dakMovementStatusRequest.AddHeader("Authorization", "Bearer " + dakListUserParam.token);
                dakMovementStatusRequest.AlwaysMultipartFormData = true;
                dakMovementStatusRequest.AddParameter("designation_id", dakListUserParam.designation_id);
                dakMovementStatusRequest.AddParameter("office_id", dakListUserParam.office_id);
                dakMovementStatusRequest.AddParameter("dak_id", dak_id);
                dakMovementStatusRequest.AddParameter("dak_type", dak_type);
                dakMovementStatusRequest.AddParameter("is_copied_dak", is_copied_dak);
                IRestResponse dakMovementStatusResponseAPI = dakMovementStatusApi.Execute(dakMovementStatusRequest);


                var dakMovementStatusResponseJson = dakMovementStatusResponseAPI.Content;

                SaveorUpdateDakItemMovementStatus(dak_id, is_copied_dak, dak_type, dakMovementStatusResponseJson);

                dakMovementStatusResponse = JsonConvert.DeserializeObject<DakMovementStatusResponse>(dakMovementStatusResponseJson);
                return dakMovementStatusResponse;
            }
            catch (Exception ex)
            {
                return dakMovementStatusResponse;
            }
        }

        public DakIdListResponse GetRemoteDakIdList(DakUserParam dakUserParam)
        {
            DakIdListResponse dakIdListResponse = new DakIdListResponse();

            // Call API

            // Local Fake Json
            using (StreamReader r = new StreamReader("H:\\Faisal\\E-Nothi\\src\\dNothi.Services\\FakeJsonData\\FakeDakList.json"))
            {
                string json = r.ReadToEnd();
                dakIdListResponse = JsonConvert.DeserializeObject<DakIdListResponse>(json);
                
            }
            return dakIdListResponse;

        }

        public DakListWithDetailsResponse GetRemoteDakListDetails(DakUserParam dakUserParam)
        {
            DakListWithDetailsResponse dakDetailsResponse = new DakListWithDetailsResponse();

            // Call API

            // Local Fake Json
            using (StreamReader r = new StreamReader("H:\\Faisal\\E-Nothi\\src\\dNothi.Services\\FakeJsonData\\FakeDakDetails.json"))
            {
                string json = r.ReadToEnd();
                dakDetailsResponse = JsonConvert.DeserializeObject<DakListWithDetailsResponse>(json);

            }
            return dakDetailsResponse;

        }


        public DakSearchResponse GetDakListFromFolderResponse(DakUserParam dakListUserParam, int  folder_id)
        {
            DakSearchResponse dakSearchResponse = new DakSearchResponse();
            try
            {


                var dakSearchApi = new RestClient(GetAPIDomain() + GetDakListFromFolderEndPoint());
                dakSearchApi.Timeout = -1;
                var dakSearchRequest = new RestRequest(Method.POST);
                dakSearchRequest.AddHeader("api-version", GetOldAPIVersion());
                dakSearchRequest.AddHeader("Authorization", "Bearer " + dakListUserParam.token);
                dakSearchRequest.AlwaysMultipartFormData = true;
                dakSearchRequest.AddParameter("designation_id", dakListUserParam.designation_id);
                dakSearchRequest.AddParameter("office_id", dakListUserParam.office_id);
                dakSearchRequest.AddParameter("page", dakListUserParam.page);
                dakSearchRequest.AddParameter("limit", dakListUserParam.limit);
                dakSearchRequest.AddParameter("custom_folder_id", folder_id);
            
                IRestResponse dakInboxResponse = dakSearchApi.Execute(dakSearchRequest);


                var dakResponseJson = dakInboxResponse.Content;
               // int firstStringIndex = dakResponseJson.IndexOf("{\"status\":");

               // var jsonStringDiscardedGarbage = dakResponseJson.Substring(firstStringIndex, dakResponseJson.Length - firstStringIndex);
                //var data2 = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseJson2)["data"].ToString();
                // var rec = JsonConvert.DeserializeObject<Dictionary<string, object>>(data2)["records"].ToString();
                dakSearchResponse = JsonConvert.DeserializeObject<DakSearchResponse>(dakResponseJson);
                return dakSearchResponse;
            }
            catch (Exception ex)
            {
                return dakSearchResponse;
            }
        }

        public void SaveDakItemLocally(List<DakIdListRecordDTO> data)
        {
            
            if (data.Count > 0)
            {
                foreach (DakIdListRecordDTO dakIdListRecordDTO in data)
                {

                    var config = new MapperConfiguration(cfg =>
                  cfg.CreateMap<DakItem, DakIdListRecordDTO>()
                      );
                    var mapper = new Mapper(config);
                    var dakItem = mapper.Map<DakItem>(dakIdListRecordDTO);


                    _dakItems.Insert(dakItem);

                   
                }
            }
            
        }

        public void UpdateDakItemLocally(List<DakIdListRecordDTO> data)
        {

            List<long> ids = new List<long>();  

            if (data.Count > 0)
            {
                foreach (DakIdListRecordDTO dakIdListRecordDTO in data)
                {

                    var dakItem = _dakItems.Table.FirstOrDefault(a => a.dak_id == dakIdListRecordDTO.dak_id);
                    if(dakItem != null)
                    {
                        dakItem.dak_type = dakIdListRecordDTO.dak_type;
                        dakItem.is_copied_dak = dakIdListRecordDTO.is_copied_dak;
                        dakItem.page = dakIdListRecordDTO.page;
                        dakItem.dak_category = dakIdListRecordDTO.dak_category;
                        if(dakItem.dak_hash != dakIdListRecordDTO.dak_hash)
                        {
                            ids.Add(dakItem.dak_id);
                           
                        }

                        dakItem.dak_hash = dakIdListRecordDTO.dak_hash;
                        _dakItems.Update(dakItem);
                    }

                  


                }

                if(ids.Count>0)
                {
                  //  SaveorUpdateDakItemDetails(ids);
                }
            }
        }

        private void SaveorUpdateDakItemDetails(int dak_id, int is_copied_dak, string dak_type, string jsonResponse)
        {
            DakItemDetails dakItemDB = _dakItemDetails.Table.FirstOrDefault(a => a.dak_id == dak_id && a.is_copied_dak == is_copied_dak && a.dak_type == dak_type );

            if (dakItemDB != null)
            {
                dakItemDB.dak_details_Json = jsonResponse;
                _dakItemDetails.Update(dakItemDB);
            }
            else
            {
                DakItemDetails dakItem = new DakItemDetails();
                dakItem.dak_id = dak_id;
                dakItem.is_copied_dak = is_copied_dak;
                dakItem.dak_type = dak_type;
                dakItem.dak_details_Json = jsonResponse;
                _dakItemDetails.Insert(dakItem);

            }
        }
        private void SaveorUpdateDakItemAttachment(int dak_id, int is_copied_dak, string dak_type, string jsonResponse)
        {
            DakItemDetails dakItemDB = _dakItemDetails.Table.FirstOrDefault(a => a.dak_id == dak_id && a.is_copied_dak == is_copied_dak && a.dak_type == dak_type);

            if (dakItemDB != null)
            {
                dakItemDB.dak_attachment_Json = jsonResponse;
                _dakItemDetails.Update(dakItemDB);
            }
            else
            {
                DakItemDetails dakItem = new DakItemDetails();
                dakItem.dak_id = dak_id;
                dakItem.is_copied_dak = is_copied_dak;
                dakItem.dak_type = dak_type;
                dakItem.dak_attachment_Json = jsonResponse;
                _dakItemDetails.Insert(dakItem);

            }
        }
        private void SaveorUpdateDakItemMovementStatus(int dak_id, int is_copied_dak, string dak_type, string jsonResponse)
        {
            DakItemDetails dakItemDB = _dakItemDetails.Table.FirstOrDefault(a => a.dak_id == dak_id && a.is_copied_dak == is_copied_dak && a.dak_type == dak_type);

            if (dakItemDB != null)
            {
                dakItemDB.dak_movement_status_Json = jsonResponse;
                _dakItemDetails.Update(dakItemDB);
            }
            else
            {
                DakItemDetails dakItem = new DakItemDetails();
                dakItem.dak_id = dak_id;
                dakItem.is_copied_dak = is_copied_dak;
                dakItem.dak_type = dak_type;
                dakItem.dak_movement_status_Json = jsonResponse;
                _dakItemDetails.Insert(dakItem);

            }
        }

        public void DeleteDakItemLocally(List<DakItem> data)
        {
            throw new NotImplementedException();
        }

        public void SaveorUpdateDakItemDetailsLocally(long dak_id, string DakDetails)
        {
            throw new NotImplementedException();
        }
    }
}
