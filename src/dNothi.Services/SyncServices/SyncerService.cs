﻿using dNothi.Constants;
using dNothi.Core.Entities;
using dNothi.Core.Interfaces;
using dNothi.JsonParser.Entity;
using dNothi.JsonParser.Entity.Dak;
using dNothi.Services.AccountServices;
using dNothi.Services.DakServices;
using dNothi.Services.UserServices;
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
    public class SyncerService: ISyncerService
    {
        private static readonly log4net.ILog _log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        IUserService _userService;
        IDakInboxServices _dakInboxService;
        IAccountService _accountService;
        IDakListService _dakListService;
        IRepository<SyncStatus> _sycnRepository;
        public SyncerService(IDakInboxServices dakInboxService, IUserService userService, IAccountService accountService, IDakListService dakListService, IRepository<SyncStatus> sycnRepository)
        {
            _userService = userService;
            _dakInboxService = dakInboxService;
            _accountService = accountService;
            _dakListService = dakListService;
            _sycnRepository = sycnRepository;
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


        List<long> RemoteDakIdList(DakUserParam userParam)
        {
            List<long> ids = new List<long>();
            var response = _dakListService.GetRemoteDakIdList(userParam);
           
                if(response.data.records.Count>0)
                {
                    foreach(DakIdListRecordDTO dakIdListRecordDTO in response.data.records)
                    {
                        ids.Add(dakIdListRecordDTO.dak_id);
                    }
                }

            return ids;
            
        }
        public void SyncDak(DakUserParam userParam)
        {
            List<long> src =RemoteDakIdList(userParam);
            List<long> des = _dakListService.GetLocalDakIdList();

            List<long> diff = des.Except(src).ToList();
           // CopyMessageToDest(diff);
           // SaveMessageToStatus(diff);
           // status = GetUpdatedStatus();
            //List<long> diff2 = status.Except(src).ToList();
            DeleteFromDest(diff);
            AddToDest(diff,userParam);
        }


        public void SyncTo(List<long> src, List<long> des, List<long> status )
        {
            List<long> diff = src.Except(status).ToList();

             //AddToDest(diff);
            // SaveMessageToStatus(diff);

            List<long> diff2 = status.Except(src).ToList();
           
            DeleteFromDest(diff2);
            DeleteFromStatus(diff2);// Status Store Only Id
        }

        private void AddToDest(List<long> diff2, DakUserParam dakUserParam)
        {
            DakListWithDetailsResponse dakListWithDetailsResponse = _dakListService.GetRemoteDakListDetails(dakUserParam);
            if(dakListWithDetailsResponse.data.records.Count>0)
            {
               var dakListWithDetailsRecordDTOs =from c in dakListWithDetailsResponse.data.records
                                                                                where !diff2.Any(o => o == c.dak_user.dak_id)
                                                                                             select c;

                if(dakListWithDetailsRecordDTOs != null)
                {
                    _dakListService.SaveOrUpdateDakList(dakListWithDetailsRecordDTOs.ToList());
                }
                
                    
                
            }
        }

        public List<long> GetStatus()
        {
            return _sycnRepository.Table.Select(s => s.Id).ToList();
        }
        private void DeleteFromStatus(List<long> diff2)
        {
            throw new NotImplementedException();
        }

        private void DeleteFromDest(List<long> diff)
        {
            if(diff.Count>0)
            {
                foreach(long id in diff)
                {
                    _dakListService.DakDeleteUsingId(id);

                }
            }
        }

        private List<long> GetUpdatedStatus()
        {
            return _sycnRepository.Table.Select(s => s.Id).ToList();
        }

        private void SaveMessageToStatus(List<long> diff)
        {
            throw new NotImplementedException();
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
                        catch(Exception ex)
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
            var dakInboxList=_dakListService.GetDakList();
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

        private void SaveOrUpdateOffice(List<OfficeInfoDTO> officeInfoDTO)
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
        List<long> GetDestination();
        Task<List<long>> GetSource();
        void SyncDak(DakUserParam userParam);
    }
}
