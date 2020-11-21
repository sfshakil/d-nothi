using AutoMapper;
using dNothi.Core.Entities;
using dNothi.Core.Interfaces;
using dNothi.JsonParser.Entity.Dak_List_Inbox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Services.DakServices
{
  public class DakListService:IDakListService
    {
        IRepository<DakTag> _daktags;
        IRepository<DakUser> _dakuser;
        IRepository<DakList> _dakList;
        IRepository<DakListDakListRecord> _dakListDakListRecord;
        IRepository<DakListRecord> _dakListRecord;
        IRepository<DakListRecordDakTag> _dakListRecordDakTag;
        IRepository<DakOrigin> _dakOrigin;
        IRepository<From> _from;
        IRepository<To> _to;
        IRepository<Other> _other;
        IRepository<MovementStatus> _movementStatus;
        IRepository<MovementStatusTo> _movementStatusTo;
        IRepository<DakNothi> _dakNothi;
        public DakListService(IRepository<DakTag> daktags,
            IRepository<DakUser> dakuser,
            IRepository<From> from,
            IRepository<Other> other,
            IRepository<To> to,
            IRepository<MovementStatus> movementStatus,
            
            IRepository<DakNothi> dakNothi,
            IRepository<DakOrigin> dakOrigin,
            IRepository<DakList> dakList,
            IRepository<DakListDakListRecord> dakListDakListRecord,
            IRepository<DakListRecord> dakListRecord,
            IRepository<DakListRecordDakTag> dakListRecordDakTag,
            IRepository<MovementStatusTo> movementStatusTo
            )
        {
            this._daktags = daktags;
            this._dakuser = dakuser;
            this._from = from;
            this._other = other;
            this._movementStatusTo = movementStatusTo;
            this._to = to;
            this._movementStatus = movementStatus;
            this._dakList = dakList;
            this._dakNothi = dakNothi;
            this._dakOrigin = dakOrigin;
            this._dakListDakListRecord = dakListDakListRecord;
            this._dakListRecord = dakListRecord;
            this._dakListRecordDakTag = dakListRecordDakTag;
        }

        public long SaveOrUpdateDakInbox( DakListDTO dakListDTO)
        {
            DakList dakList = new DakList();
            dakList.total_records = dakListDTO.total_records;
           _dakList.Insert(dakList);
           
            if (dakListDTO.total_records > 0)
            {
                foreach (DakListRecordsDTO dakListRecordsDTO in dakListDTO.records)
                {
                    SaveOrUpdateDakListDakListRecord(dakListRecordsDTO, dakList.Id);
                }

            }
           
            return dakList.Id;
        }

        private void SaveOrUpdateDakListDakListRecord(DakListRecordsDTO dakListRecordsDTO, long dakListId)
        {
            DakListDakListRecord dakListDakListRecord = new DakListDakListRecord();
            dakListDakListRecord.dakListId = dakListId;
            dakListDakListRecord.dakListRecordId = SaveOrUpdateDakListRecord(dakListRecordsDTO);

            _dakListDakListRecord.Insert(dakListDakListRecord);

        }

        private long SaveOrUpdateDakListRecord(DakListRecordsDTO dakListRecordsDTO)
        {
            DakListRecord dakListRecord = new DakListRecord();
            dakListRecord.attachment_count = dakListRecordsDTO.attachment_count;
           
           
           
            if (dakListRecordsDTO.dak_origin!=null)
            {
                dakListRecord.dak_origin_id = SaveOrUpdateDakOrigin(dakListRecordsDTO.dak_origin);
            }

            if (dakListRecordsDTO.movement_status!=null)
            {
                dakListRecord.movement_status_id = SaveOrUpdateMovementStatus(dakListRecordsDTO.movement_status);
            }

           if (dakListRecordsDTO.dak_user!=null)
            {
                dakListRecord.dak_user_id = SaveOrUpdateDakUser(dakListRecordsDTO.dak_user);
            }

            try
            {
                if (dakListRecordsDTO.nothi != null)
                {
                    dakListRecord.dak_nothi_id = SaveOrUpdateNothi(dakListRecordsDTO.nothi);
                }
            }
            catch
            {

            }


            _dakListRecord.Insert(dakListRecord);


            if(dakListRecordsDTO!= null)
            {
                foreach(DakTagDTO dakTagDTO in dakListRecordsDTO.dak_Tags)
                {
                    SaveOrUpdateDakListDakTag(dakTagDTO, dakListRecord.Id);
                }
            }

            return dakListRecord.Id;



        }

        private void SaveOrUpdateDakListDakTag(DakTagDTO dakTagDTO, long id)
        {
            DakListRecordDakTag dakListRecordDakTag = new DakListRecordDakTag();
            dakListRecordDakTag.DakListRecordId = id;
            dakListRecordDakTag.DakTagId = SaveOrUpdateDakTag(dakTagDTO);

            _dakListRecordDakTag.Insert(dakListRecordDakTag);
        }

       

        private long SaveOrUpdateNothi(NothiDTO nothiDTO)
        {
            var config = new MapperConfiguration(cfg =>
                      cfg.CreateMap<DakNothi, NothiDTO>()
                  );
            var mapper = new Mapper(config);
            var dakNothi = mapper.Map<DakNothi>(nothiDTO);
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

        private long SaveOrUpdateMovementStatus(MovementStatusDTO movement_statusDTO)
        {
            MovementStatus movementStatus = new MovementStatus();
          
           if(movement_statusDTO.from!=null)

            {
                movementStatus.from_id = SaveOrUpdateFrom(movement_statusDTO.from);
            } 
            
            if(movement_statusDTO.other!=null)

            {
                movementStatus.other_id = SaveOrUpdateOther(movement_statusDTO.other);
            }
            _movementStatus.Insert(movementStatus);
            
           if(movementStatus.to != null)
            {
                foreach(ToDTO to in movement_statusDTO.to)
                {
                    SaveOrUpdateMovementStatusTo(to, movementStatus.Id);
                }
            }
            return movementStatus.Id;

        }

        private void SaveOrUpdateMovementStatusTo(ToDTO to, long id)
        {
            MovementStatusTo movementStatusTo = new MovementStatusTo();
            movementStatusTo.MovStatusId = id;

            movementStatusTo.ToId = SaveOrUpdateTo(to);
            _movementStatusTo.Insert(movementStatusTo);

        }

        private long SaveOrUpdateTo(ToDTO toDTO)
        {
            var config = new MapperConfiguration(cfg =>
                      cfg.CreateMap<ToDTO, To>()
                  );
            var mapper = new Mapper(config);
            var to = mapper.Map<To>(toDTO);
          
                _to.Insert(to);
          
            return to.Id;
        }

        private long SaveOrUpdateOther(OtherDTO otherDTO)
        {
            var config = new MapperConfiguration(cfg =>
                      cfg.CreateMap<OtherDTO, Other>()
                  );
            var mapper = new Mapper(config);
            var other = mapper.Map<Other>(otherDTO);
            other.otherId = otherDTO.id;
            var dbother = _other.Table.Where(q => q.otherId == otherDTO.id).FirstOrDefault();
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

        private long SaveOrUpdateFrom(FromDTO fromDTO)
        {
            var config = new MapperConfiguration(cfg =>
                      cfg.CreateMap<FromDTO, From>()
                  );
            var mapper = new Mapper(config);
            var from = mapper.Map<From>(fromDTO);
           
           
                _from.Insert(from);
           

            return from.Id;
        }

        private long SaveOrUpdateDakOrigin(DakOriginDTO dak_origin)
        {
            var config = new MapperConfiguration(cfg =>
                     cfg.CreateMap<DakOriginDTO, DakOrigin>()
                 );
            var mapper = new Mapper(config);
            var dakorigin = mapper.Map<DakOrigin>(dak_origin);
            var dbdakOrigin = _dakOrigin.Table.Where(q => q.Id == dak_origin.id).FirstOrDefault();
            if (dbdakOrigin == null)
            {
                _dakOrigin.Insert(dakorigin);
            }
            else
            {
                _dakOrigin.Update(dakorigin);
            }

            return dakorigin.Id;
        }

        private long SaveOrUpdateDakTag(DakTagDTO dak_Tagsdto)
        {
            var config = new MapperConfiguration(cfg =>
                    cfg.CreateMap<DakTagDTO, DakTag>()
                );
            var mapper = new Mapper(config);
            var daktag = mapper.Map<DakTag>(dak_Tagsdto);
            var dbdaktag = _daktags.Table.Where(q => q.dak_id == dak_Tagsdto.dak_id).FirstOrDefault();
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

       
    }
}
