using AutoMapper;
using dNothi.Constants;
using dNothi.Core.Entities;
using dNothi.Core.Interfaces;
using dNothi.JsonParser.Entity.Dak;
using dNothi.JsonParser.Entity.Dak_List_Inbox;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Services.DakServices
{
  public class DakListService:IDakListService
    {
        IRepository<DakTag> _daktags;
        IRepository<DakUser> _dakuser;
        IRepository<DakType> _daktype;
       
        IRepository<DakList> _daklist;
     
        IRepository<DakOrigin> _dakOrigin;
        IRepository<Officer> _from;
        IRepository<To> _to;
        IRepository<Other> _other;
        IRepository<MovementStatus> _movementStatus;
       
        IRepository<DakNothi> _dakNothi;
        public DakListService(IRepository<DakTag> daktags,
            IRepository<DakUser> dakuser,
            IRepository<Officer> from,
            IRepository<Other> other,
            IRepository<To> to,
            IRepository<MovementStatus> movementStatus,
            
            IRepository<DakNothi> dakNothi,
            IRepository<DakOrigin> dakOrigin,
            IRepository<DakType> daktype,
          
            IRepository<DakList> dakList
           
        
            )
        {
            this._daktags = daktags;
            this._dakuser = dakuser;
            this._from = from;
            this._other = other;
       
            this._to = to;
            this._movementStatus = movementStatus;
            this._daktype = daktype;
            this._dakNothi = dakNothi;
            this._dakOrigin = dakOrigin;
       
            this._daklist = dakList;
        
        }

      
      

     

        private long SaveOrUpdateNothi(NothiDTO nothiDTO)
        {
            var config = new MapperConfiguration(cfg =>
                      cfg.CreateMap<NothiDTO, DakNothi>()
                  );
            var mapper = new Mapper(config);
            var dakNothi = mapper.Map<DakNothi>(nothiDTO);
            dakNothi.nothi_id = nothiDTO.nothi_id;
            var dbdakNothi = _dakNothi.Table.Where(q => q.dak_id == nothiDTO.dak_id).FirstOrDefault();
            if (dbdakNothi == null)
            {
                _dakNothi.Insert(dakNothi);
            }
            else
            {
                dakNothi.Id = dbdakNothi.Id;
                _dakNothi.Update(dakNothi);
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

                var dbmovementstatus = _movementStatus.Table.FirstOrDefault(a => a.other.otherId == movement_statusDTO.other.dak_origin_id);
                if (dbmovementstatus != null)
                {
                    movementStatus.Id = dbmovementstatus.Id;
                    _movementStatus.Update(movementStatus);
                }
                else
                {
                    _movementStatus.Insert(movementStatus);

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






            var dbto = _to.Table.FirstOrDefault(a => a.to_id == to.to_id && a.movement_status_id == to.movement_status_id);
            
            if(dbto != null)
            {
                to.Id = dbto.Id;
                _to.Update(to);
            }
            else
            {
                _to.Insert(to);
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
            var dbother = _other.Table.Where(q => q.otherId == otherDTO.dak_origin_id).FirstOrDefault();
            if (dbother == null)
            {
                _other.Insert(other);
            }
            else
            {
                other.Id = dbother.Id;
                _other.Update(other);
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
            var dbfrom = _from.Table.FirstOrDefault(a => a.designation_id == fromDTO.designation_id);
            if(dbfrom != null)
            {
                from.Id = dbfrom.Id;
                _from.Update(from);
            }
            else
            {
                _from.Insert(from);
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
            var dbdakOrigin = _dakOrigin.Table.Where(q => q.dak_origin_id == dak_origin.dak_origin_id).FirstOrDefault();
            if (dbdakOrigin == null)
            {
                _dakOrigin.Insert(dakorigin);
            }
            else
            {
                dakorigin.Id = dbdakOrigin.Id;
                _dakOrigin.Update(dakorigin);
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
            var dbdaktag = _daktags.Table.Where(q => q.dak_tag_id == dak_Tagsdto.id ).FirstOrDefault();
            if (dbdaktag == null)
            {
                _daktags.Insert(daktag);
            }
            else
            {
                daktag.Id = dbdaktag.Id;
                _daktags.Update(daktag);
            }

            return daktag.Id;
        }

        private long SaveOrUpdateDakUser(DakUserDTO dak_Userdto)
        {
            var config = new MapperConfiguration(cfg =>
                     cfg.CreateMap<DakUserDTO, DakUser>()
                 );
            var mapper = new Mapper(config);
            var dakuser = mapper.Map<DakUser>(dak_Userdto);
            var dbdaktuser = _dakuser.Table.Where(q => q.dak_id == dak_Userdto.dak_id).FirstOrDefault();
            if (dbdaktuser == null)
            {
                _dakuser.Insert(dakuser);
            }
            else
            {
                dakuser.Id = dbdaktuser.Id;
                _dakuser.Update(dakuser);
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

                            var dbdaklist = _daklist.Table.FirstOrDefault(a => a.dak_user.dak_id == dakListRecordsDTO.dak_user.dak_id);
                            if(dbdaklist == null)
                            {
                                _daklist.Insert(dakList);
                            }
                            else
                            {
                                dakList.Id = dbdaklist.Id;
                                _daklist.Update(dakList);
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

        public DakListDTO GetLocalDakListbyType(long dakTypeId, DakUserParam dakListUserParam)
        {
            DakListDTO dakListDTO = new DakListDTO();
            var dbdaklist = _daklist.Table.Include(a=>a.dak_origin).Include(a => a.dak_user).Include(a => a.dak_Tags).Include(a => a.nothi).Include(a => a.movement_status).Where(a => a.dak_List_type_Id == dakTypeId).ToList();
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
                //var data2 = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseJson2)["data"].ToString();
                // var rec = JsonConvert.DeserializeObject<Dictionary<string, object>>(data2)["records"].ToString();
                DakDetailsResponse dakDetailsResponse = JsonConvert.DeserializeObject<DakDetailsResponse>(dakdetailsResponseJson);
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

        public DakAttachmentResponse GetDakAttachmentbyDakId(int dak_id, string dak_type, int is_copied_dak, DakUserParam dakListUserParam)
        {
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
                //var data2 = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseJson2)["data"].ToString();
                // var rec = JsonConvert.DeserializeObject<Dictionary<string, object>>(data2)["records"].ToString();
                DakAttachmentResponse dakAttachmentResponse = JsonConvert.DeserializeObject<DakAttachmentResponse>(dakAttachmentResponseJson);
                return dakAttachmentResponse;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DakMovementStatusResponse GetDakMovementStatusListbyDakId(int dak_id, string dak_type, int is_copied_dak, DakUserParam dakListUserParam)
        {
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
                DakMovementStatusResponse dakMovementStatusResponse = JsonConvert.DeserializeObject<DakMovementStatusResponse>(dakMovementStatusResponseJson);
                return dakMovementStatusResponse;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
