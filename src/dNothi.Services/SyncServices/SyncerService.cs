using dNothi.Constants;
using dNothi.Core.Entities;
using dNothi.Core.Interfaces;
using dNothi.JsonParser.Entity;
using dNothi.JsonParser.Entity.Dak;
using dNothi.Services.AccountServices;
using dNothi.Services.DakServices;
using dNothi.Services.DakServices.DakSharingService;
using dNothi.Services.DakServices.DakSharingService.Model;
using dNothi.Services.GuardFile;
using dNothi.Services.GuardFile.Model;
using dNothi.Services.KhasraService;
using dNothi.Services.NothiServices;
using dNothi.Services.UserServices;
using dNothi.Utility;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Services.SyncServices
{
    public class SyncerService : ISyncerService
    {
        private static readonly log4net.ILog _log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        INothiTypeSaveService _nothiTypeSave { get; set; }
        IOnucchedSave _onucchedSave { get; set; }
        IOnuchhedForwardService _onuchhedForwardService { get; set; }
        INoteSaveService _noteSave { get; set; }
        INothiNotePermissionService _nothiNotePermissionSave { get; set; }
        IUserService _userService { get; set; }
        IRegisterService _registerService { get; set; }
        IDakFolderService _dakFolderService { get; set; }
        IDakSearchService _dakSearchService { get; set; }
        IProtibedonService _protibedonService { get; set; }
        IDesignationSealService _designationSealService { get; set; }

        private DakUserParam _dakuserparam = new DakUserParam();
        IDakKhosraService _dakkhosraservice { get; set; }
        IDakListService _dakListService { get; set; }
        IDakOutboxService _dakOutboxService { get; set; }
        IDakUploadService _dakuploadservice { get; set; }
        IDakInboxServices _dakInboxService { get; set; }
        INothiCreateService _nothiCreateServices { get; set; }

        IDakArchiveService _dakArchiveService { get; set; }
        IDakNothijatoService _dakNothijatoService { get; set; }

        IDakNothivuktoService _dakNothivuktoService { get; set; }
        IDakListSortedService _dakListSortedService { get; set; }
        IDakForwardService _dakForwardService { get; set; }
        IAccountService _accountService { get; set; }
        IOnucchedFileUploadService _onucchedFileUploadService { get; set; }
        IDakSharingService<ResponseModel> _dakSharingService { get; set; }
        IRepository<SyncStatus> _sycnRepository;
        IGuardFileService<GuardFileModel, GuardFileModel.Record> _guardFileService;
        IKhosraSaveService _khosraSaveService;
        public SyncerService(
              INoteSaveService noteSave,
              INothiNotePermissionService nothiNotePermissionSave,

            IOnucchedSave onucchedSave,
             IUserService userService,
            IDakOutboxService dakOutboxService,
            IDakNothivuktoService dakNothivuktoService,
            IDakArchiveService dakListArchiveService,
            IDakListService dakListService,
            IDakListSortedService dakListSortedService,
            IDakForwardService dakForwardService,
            IDakKhosraService dakKhosraService,
            IDakUploadService dakUploadService,
            IDesignationSealService designationSealService,
            IDakSearchService dakSearchService,
            IRegisterService registerService,
            IDakFolderService dakFolderService,
            IProtibedonService protibedonService,
            IDakNothijatoService dakNothijatoService,
            IOnuchhedForwardService onuchhedForwardService,
            INothiTypeSaveService nothiTypeSave,
            INothiCreateService nothiCreateServices,
            IOnucchedFileUploadService onucchedFileUploadService,

            IDakInboxServices dakInboxService,

            IAccountService accountService,

            IRepository<SyncStatus> sycnRepository,
            IDakSharingService<ResponseModel> dakSharingService,
            IGuardFileService<GuardFileModel, GuardFileModel.Record> guardFileService,
             IKhosraSaveService khosraSaveService)
        {
            _nothiCreateServices = nothiCreateServices;
            _nothiTypeSave = nothiTypeSave;
            _onuchhedForwardService = onuchhedForwardService;
             _dakNothivuktoService = dakNothivuktoService;
            _noteSave = noteSave;
            _nothiNotePermissionSave = nothiNotePermissionSave;
            _dakSearchService = dakSearchService;
            _registerService = registerService;
            _designationSealService = designationSealService;
            _dakOutboxService = dakOutboxService;

            _dakArchiveService = dakListArchiveService;
            _dakNothijatoService = dakNothijatoService;

            _dakListSortedService = dakListSortedService;
            _dakForwardService = dakForwardService;
            _dakkhosraservice = dakKhosraService;
            _dakuploadservice = dakUploadService;
            _protibedonService = protibedonService;

            _dakFolderService = dakFolderService;
            _onucchedFileUploadService = onucchedFileUploadService;
            _onucchedSave = onucchedSave;
            _userService = userService;
            _dakInboxService = dakInboxService;
            _accountService = accountService;
            _dakListService = dakListService;
            _sycnRepository = sycnRepository;
            _dakSharingService = dakSharingService;
            _guardFileService = guardFileService;
            _khosraSaveService = khosraSaveService;
        }
        /****************=========================================================================***************************
         ****************=========================================================================***************************
        //Define a synchronization operation on a source, destination and status repository syncto(src, dst, status) to be these two steps:

        //Calculate the set difference src - status, and copy these messages to dst and status.
        //Calculate the set difference status - src, and delete these messages from dst and status.
        //The full synchronization algorithm is then:

        //syncto(R, L, S) (download changes)
        //syncto(L, R, S) (upload changes)

        **************************==================================================================********************************
        **************************==================================================================*******************************/


        //src will be Remote and dst will be Local


        public void SyncLocaltoRemoteData()
        {
            LocalChangeData._isDakUploaded = false;
            LocalChangeData._isLocallYDakArchived = false;
            LocalChangeData._isLocallYDakNothijato = false;
            LocalChangeData._isLocallYDakNothivukto = false;
            LocalChangeData._isLocallYDakForwarded = false;
            LocalChangeData._isLocallYDakTagged = false;
            LocalChangeData._isdakForwardReverted = false;
            LocalChangeData._isdakNothijatoReverted = false;
            LocalChangeData._isdakNothivuktoReverted = false;
            LocalChangeData._isdakArchivedReverted = false;

            if (InternetConnection.Check())
            {

                if (_dakuploadservice.UploadDakFromLocal())
                {
                    LocalChangeData._isDakUploaded = true;
                }
                if (_dakForwardService.SendDakForwardFromLocal())
                {
                    LocalChangeData._isLocallYDakForwarded = true;
                }
                if (_dakNothivuktoService.DakNothivuktoFromLocal())
                {
                    LocalChangeData._isLocallYDakNothivukto = true;
                }
                if (_dakArchiveService.DakArchivedFromLocal())
                {
                    LocalChangeData._isLocallYDakArchived = true;
                }
                if (_dakNothijatoService.DakNothijatoFromLocal())
                {
                    LocalChangeData._isLocallYDakNothijato = true;
                }
                if (_dakFolderService.DakTagFromLocal())
                {
                    LocalChangeData._isLocallYDakTagged = true;
                }
                if (_dakForwardService.SendDakForwardRevertedFromLocal())
                {
                    LocalChangeData._isdakForwardReverted = true;
                }
                if (_dakNothivuktoService.DakNothivuktoRevertFromLocal())
                {
                    LocalChangeData._isdakNothivuktoReverted = true;
                }
                if (_dakArchiveService.DakArchiveRevertFromLocal())
                {
                    LocalChangeData._isdakArchivedReverted = true;
                }
                if (_dakNothijatoService.DakNothijatoRevertFromLocal())
                {
                    LocalChangeData._isdakNothijatoReverted = true;
                }
                _nothiTypeSave.SendNothiTypeListFromLocal();
                _nothiCreateServices.SendNothiCreateListFromLocal();
                _noteSave.SendNoteListFromLocal();
                _nothiNotePermissionSave.SendNothiNotePermissionFromLocal();
                _onucchedFileUploadService.SendNoteListFromLocal();
                _onucchedSave.SendNoteListFromLocal();
                _onuchhedForwardService.SendNoteListFromLocal();
                _dakSharingService.SendLocalDataToServer(_userService.GetLocalDakUserParam());
                _dakSharingService.SendDakSortingLocalDataToServer(_userService.GetLocalDakUserParam());
                _guardFileService.SendGuradFileLocalDataTOServer(_userService.GetLocalDakUserParam());
               // _khosraSaveService.SendKosraLocalDataTOServer(_userService.GetLocalDakUserParam());
            }


        }

        public List<DakIdListRecordDTO> RemoteDakIdList(int page, int Limit)
        {
            List<DakIdListRecordDTO> dakIdListRecordDTOs = new List<DakIdListRecordDTO>();
            DakUserParam userParam = _userService.GetLocalDakUserParam();
            List<long> ids = new List<long>();
            var response = _dakListService.GetRemoteDakIdList(userParam);

            if (response.data.records.Count > 0)
            {
                dakIdListRecordDTOs = response.data.records;
            }

            return dakIdListRecordDTOs;

        }
        public void SyncDak(DakUserParam userParam)
        {
            //List<long> src =RemoteDakIdList(userParam);
            //  List<long> des = _dakListService.GetLocalDakIdList();

            //  List<long> diff = des.Except(src).ToList();
            // CopyMessageToDest(diff);
            // SaveMessageToStatus(diff);
            // status = GetUpdatedStatus();
            //List<long> diff2 = status.Except(src).ToList();
            //   DeleteFromDest(diff);
            //AddToDest(diff,userParam);
        }


        public void SyncDakTo(List<DakIdListRecordDTO> src, List<DakItem> des)
        {
            var addItemList = src.Where(p => !des.Any(p2 => p2.dak_id == p.dak_id)).ToList();


            if (addItemList != null || addItemList.Count != 0)
            {
                AddDakItemList(addItemList);
            }

            var deleteItemList = des.Where(p => !src.Any(p2 => p2.dak_id == p.dak_id)).ToList();

            if (deleteItemList != null || deleteItemList.Count != 0)
            {
                DeleteDakItemList(deleteItemList);
            }



            UpdateDakItemList(src);


        }

        private void UpdateDakItemList(List<DakIdListRecordDTO> src)
        {
            throw new NotImplementedException();
        }

        private void DeleteDakItemList(List<DakItem> deleteItemList)
        {

        }

        private void AddDakItemList(List<DakIdListRecordDTO> result)
        {
            throw new NotImplementedException();
        }




        private void AddToDest(List<long> diff2)
        {
            DakUserParam dakUserParam = _userService.GetLocalDakUserParam();
            DakListWithDetailsResponse dakListWithDetailsResponse = _dakListService.GetRemoteDakListDetails(dakUserParam);
            if (dakListWithDetailsResponse.data.records.Count > 0)
            {
                var dakListWithDetailsRecordDTOs = from c in dakListWithDetailsResponse.data.records
                                                   where !diff2.Any(o => o == c.dak_user.dak_id)
                                                   select c;

                if (dakListWithDetailsRecordDTOs != null)
                {
                    _dakListService.SaveOrUpdateDakList(dakListWithDetailsRecordDTOs.ToList());
                }



            }
        }

        public List<long> GetStatus()
        {
            return _sycnRepository.Table.Select(s => s.Id).ToList();
        }
        private void DeleteFromStatus(List<long> diff)
        {
            if (diff.Count > 0)
            {
                foreach (long id in diff)
                {
                    var statusDB = _sycnRepository.Table.FirstOrDefault(a => a.dak_id == id);
                    if (statusDB != null)
                    {
                        _sycnRepository.Delete(statusDB);

                    }

                }
            }
        }

        private void DeleteFromDest(List<long> diff)
        {
            if (diff.Count > 0)
            {
                foreach (long id in diff)
                {
                    _dakListService.DakDeleteUsingId(id);

                }
            }
        }

        private List<long> GetUpdatedStatus()
        {
            return _sycnRepository.Table.Select(s => s.Id).ToList();
        }

        private void SaveToStatus(List<long> diff)
        {
            if (diff.Count > 0)
            {
                foreach (long id in diff)
                {
                    SyncStatus syncStatus = new SyncStatus();
                    syncStatus.dak_id = id;
                    _sycnRepository.Insert(syncStatus);

                }
            }
        }

        private void CopyMessageToDest(List<long> diff)
        {
            throw new NotImplementedException();
        }

        public async Task<List<long>> GetSource()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var userName = "200000033446";
                    var password = "abc123";
                    var isRemember = true;
                    UserParam userParam = new UserParam(userName, password);
                    List<long> dakIds = new List<long>();
                    var resmessage = await _userService.GetUserMessageAsync(userParam);
                    if (resmessage.status == "success")
                    {
                        _accountService.SaveOrUpdateUser(userName, password, isRemember);
                        resmessage.data.user.SignBase64 = resmessage.data.signature.encode_sign;

                        SaveOrUpdateUser(resmessage?.data?.user);
                        SaveOrUpdateEmployee(resmessage?.data?.employee_info);
                        //SaveOrUpdateOffice(resmessage?.data?.office_info);
                        SaveOrUpdateToken(resmessage?.data?.token);


                        DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();
                        dakListUserParam.limit = 20;
                        dakListUserParam.page = 1;
                        try
                        {
                            var dakInbox = await Task.Run(() => _dakInboxService.GetDakInbox(dakListUserParam));
                            if (dakInbox.status == "success")
                            {
                                //_dakInboxService.SaveorUpdateDakInbox(dakInbox);
                                if (dakInbox.data.records.Count > 0)
                                {
                                    foreach (var record in dakInbox.data.records)
                                    {
                                        dakIds.Add(record.dak_user.dak_id);
                                    }
                                }
                                else
                                {
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            _log.Error(ex.ToString());
                        }




                        Console.WriteLine("Get Inbox Data");
                        _log.Info("Get Inbox Data");
                        return dakIds;
                    }
                    else
                    {
                        Console.WriteLine("আপনি ভূল ইউজার নেম অথবা পাসওয়ার্ড ইনপুট দিয়েছেন।");
                        _log.Info("আপনি ভূল ইউজার নেম অথবা পাসওয়ার্ড ইনপুট দিয়েছেন।");
                    }
                }
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
                throw;
            }
            return null;
        }


        public List<long> GetDestination()
        {
            var dakInboxList = _dakListService.GetDakList();
            List<long> dakIds = new List<long>();
            foreach (var dak in dakInboxList)
            {
                dakIds.Add(dak.dak_user.dak_id);
            }
            return dakIds;
        }


        private void SaveOrUpdateToken(string token)
        {
            _userService.SaveOrUpdateToken(token);
        }

        private void SaveOrUpdateUser(UserDTO userDTO)
        {
            _userService.SaveOrUpdateUser(userDTO);
        }
        private void SaveOrUpdateEmployee(EmployeeInfoDTO employeeInfoDTO)
        {
            _userService.SaveOrUpdateUserEmployeeInfo(employeeInfoDTO);
        }

        private void SaveOrUpdateOffice(List<JsonParser.Entity.OfficeInfoDTO> officeInfoDTO)
        {
            _userService.SaveOrUpdateUserOfficeInfo(officeInfoDTO);
        }

        public void Synctolocal(List<long> src, List<long> dst, List<long> status)
        {
            throw new NotImplementedException();
        }


    }

    public interface ISyncerService
    {
        void SyncLocaltoRemoteData();
        List<DakIdListRecordDTO> RemoteDakIdList(int page, int Limit);
        List<long> GetDestination();
        Task<List<long>> GetSource();
        List<long> GetStatus();
        void SyncDak(DakUserParam userParam);
        void SyncDakTo(List<DakIdListRecordDTO> src, List<DakItem> des);
    }
}
