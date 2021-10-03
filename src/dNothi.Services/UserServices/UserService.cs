using AutoMapper;
using Newtonsoft.Json;
using dNothi.Core.Entities;
using dNothi.Core.Interfaces;
using dNothi.JsonParser;
using dNothi.JsonParser.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using dNothi.Constants;
using System.Configuration;
using dNothi.Services.DakServices;
using System.Text.RegularExpressions;
using System.Web.Script.Serialization;
using RestSharp;

namespace dNothi.Services.UserServices
{
    public class UserService : IUserService
    {
        IUserMessageParser _userMessageParser;
        IRepository<User> _userrepository;
        IRepository<EmployeeInfo> _employeeRepository;
        IRepository<OfficeInfo> _officeRepository;
        IRepository<UserToken> _userTokenRepository;
        IRepository<UserItem> _userItem;
        private static readonly log4net.ILog _log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public UserService(IUserMessageParser userMessageParser,
        IRepository<User> userrepository,
        IRepository<EmployeeInfo> employeeRepository,
        IRepository<OfficeInfo> officeRepository,
        IRepository<UserToken> userTokenRepository,
        IRepository<UserItem> userItem)
        {
            _userMessageParser = userMessageParser;
            _employeeRepository = employeeRepository;
            _userrepository = userrepository;
            _officeRepository = officeRepository;
            _userTokenRepository = userTokenRepository;
            _userItem = userItem;
        }

       

        public async Task<UserMessage> GetUserMessageAsync(UserParam userParam)
        {
            try
            {
                using (var client = new HttpClient())
                {


                    var loginApi = new RestClient(GetAPIDomain() + GetLoginEndpoint());
                    loginApi.Timeout = -1;
                    var loginRequest = new RestRequest(Method.POST);
                    loginRequest.AddHeader("api-version", GetAPIVersion());
                    loginRequest.AddHeader("device-id", GetDeviceId());
                    loginRequest.AddHeader("device-type", GetDeviceType());
                    loginRequest.AlwaysMultipartFormData = true;
                    loginRequest.AddParameter("username", userParam.username);
                    loginRequest.AddParameter("password", userParam.password);

                    IRestResponse loginResponse = loginApi.Execute(loginRequest);


                    var loginResponseJson = loginResponse.Content;
                    UserMessage userResponse = JsonConvert.DeserializeObject<UserMessage>(loginResponseJson);
                    return userResponse;
                    
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            
        }

        public void GetDoptorToken(UserParam userParam)
        {
            try
            {
                


                    var ndoptorclient = new RestClient(DefaultAPIConfiguration.DoptorDomainAddress+DefaultAPIConfiguration.DoptorLoginEndPoint);
                    ndoptorclient.Timeout = -1;
                    var request = new RestRequest(Method.POST);
                    request.AlwaysMultipartFormData = true;
                    request.AddParameter("username", userParam.username);
                    request.AddParameter("password", "123456");
                    request.AddParameter("client_id", "mgeksheba");
                    IRestResponse loginResponse = ndoptorclient.Execute(request);
                   

                   
                  


                    var loginResponseJson = loginResponse.Content;
                    DoptorTokenResponse userResponse = JsonConvert.DeserializeObject<DoptorTokenResponse>(loginResponseJson);

                    SaveOrUpdateUser(userParam.username, userResponse.data.token);


                 

                
            }
            catch (Exception ex)
            {
               
            }


        }

        public EmployeeInfoDTO GetEmployeeInfo()
        {
            var empInfo = _employeeRepository.Table.FirstOrDefault();
            var config = new MapperConfiguration(cfg =>
                    cfg.CreateMap<EmployeeInfo, EmployeeInfoDTO>()
                );
            var mapper = new Mapper(config);
            var employeeInfoDTO = mapper.Map<EmployeeInfoDTO>(empInfo);
           
            return employeeInfoDTO;
        }



        public OfficeInfoDTO GetOfficeInfo()
        {
            OfficeInfo empInfo = new OfficeInfo();
            try
            {
                empInfo = _officeRepository.Table.FirstOrDefault(a => a.is_current == true);
                if (empInfo == null)
                {
                    empInfo = _officeRepository.Table.FirstOrDefault();
                }
            }
            catch
            {

            }
            

            var config = new MapperConfiguration(cfg =>
                    cfg.CreateMap<OfficeInfo, OfficeInfoDTO>()
                );
            var mapper = new Mapper(config);
            var officeInfoDTO = mapper.Map<OfficeInfoDTO>(empInfo);
            return officeInfoDTO;
        }

        public List<OfficeInfoDTO> GetAllLocalOfficeInfo()
        {
            List<OfficeInfo> officeInfos = _officeRepository.Table.ToList();
            List<OfficeInfoDTO> officeInfoDTOs = new List<OfficeInfoDTO>();

            if(officeInfos.Count>0)
            {
                var config = new MapperConfiguration(cfg =>
                  cfg.CreateMap<OfficeInfo, OfficeInfoDTO>()
              );
                foreach (var office in officeInfos)
                {
                   
                    var mapper = new Mapper(config);
                    var officeInfoDTO = mapper.Map<OfficeInfoDTO>(office);
                    officeInfoDTOs.Add(officeInfoDTO);
                }
            }
            return officeInfoDTOs;
        }

        public void MakeThisOfficeCurrent(int designationId)
        {
            var officeInfo = _officeRepository.Table.FirstOrDefault(a => a.office_unit_organogram_id == designationId);
            if(officeInfo != null)
            {
                officeInfo.is_current = true;
                _officeRepository.Update(officeInfo);

                List<OfficeInfo> officeInfos = _officeRepository.Table.Where(a => a.office_unit_organogram_id != designationId && a.is_current==true).ToList();
                if(officeInfos.Count>0)
                {
                    foreach(var office in officeInfos)
                    {
                        office.is_current = false;
                        _officeRepository.Update(office);
                    }
                }

            }
        }
        public UserDTO GetUserInfo()
        {
            var userInfo = _userrepository.Table.FirstOrDefault();
            var config = new MapperConfiguration(cfg =>
                    cfg.CreateMap<User, UserDTO>()
                );
            var mapper = new Mapper(config);
            var userDTO = mapper.Map<UserDTO>(userInfo);
            return userDTO;
        }
        public void SaveOrUpdateUser(UserDTO userdto)
        {
            var config = new MapperConfiguration(cfg =>
                    cfg.CreateMap<UserDTO, User>()
                );
            var mapper = new Mapper(config);
            var user = mapper.Map<User>(userdto);
            user.userid = userdto.userid;
            user.SignBase64 = userdto.SignBase64;
            user.profile_photo = userdto.profile_photo;
            var dbuser = _userrepository.Table.FirstOrDefault();



            if (dbuser == null)
            {
                _userrepository.Insert(user);
            }
            else
            {
                dbuser.userid = user.userid;
                dbuser.SignBase64 = userdto.SignBase64;
                dbuser.profile_photo = userdto.profile_photo;
                
                _userrepository.Update(dbuser);
            }
        }

        public void SaveOrUpdateUser(string username,string token)
        {
            var dbuser = _userrepository.Table.FirstOrDefault(a=>a.username==username);



            if (dbuser != null)
            {
                dbuser.doptor_token = token;
                _userrepository.Update(dbuser);
            }
            else
            {
                dbuser = new User();
                dbuser.doptor_token = token;
                dbuser.username = username;
                _userrepository.Insert(dbuser);
            }
        }
        public void SaveOrUpdateUserEmployeeInfo(EmployeeInfoDTO employeedto)
        {
            var config = new MapperConfiguration(cfg =>
                    cfg.CreateMap<EmployeeInfoDTO, EmployeeInfo>()
                );
            var mapper = new Mapper(config);
            var empInfo = mapper.Map<EmployeeInfo>(employeedto);
            empInfo.emp_id = employeedto.id;
            var dbemployee = _employeeRepository.Table.FirstOrDefault();
            if (dbemployee == null)
            {
                _employeeRepository.Insert(empInfo);
            }
            else
            {
               

               dbemployee.name_bng=empInfo.name_bng;
               
                _employeeRepository.Update(dbemployee);
            }
        }

        protected string GetAPIDomain()
        {
            return ReadAppSettings("api-endpoint") ?? DefaultAPIConfiguration.DefaultAPIDomainAddress;
        }
        protected string GetLoginEndpoint()
        {
            return DefaultAPIConfiguration.LoginEndPoint;
        }
        protected string GetAPIVersion()
        {
            return ReadAppSettings("api-version") ?? DefaultAPIConfiguration.DefaultAPIversion;
        }

        protected string GetDeviceId()
        {
            return ReadAppSettings("device-id") ?? DefaultAPIConfiguration.DefaultDeviceId;
        }
        protected string GetDeviceType()
        {
            return ReadAppSettings("device-type") ?? DefaultAPIConfiguration.DefaultDeviceType;
        }

        protected string ReadAppSettings(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
        public void SaveOrUpdateUserOfficeInfo(List<OfficeInfoDTO> officeinfodtos)
        {

            var config = new MapperConfiguration(cfg =>
                    cfg.CreateMap<OfficeInfoDTO, OfficeInfo>()
                );
            var mapper = new Mapper(config);


            foreach (var officeinfodto in officeinfodtos)
            {
                var ofcInfo = mapper.Map<OfficeInfo>(officeinfodto);
               // var dboffice = _officeRepository.Table.FirstOrDefault();
                //if (dboffice == null)
                //{
                    _officeRepository.Insert(ofcInfo);
                //}
                //else
                //{
                //    dboffice.office_id = ofcInfo.office_id;

                //    dboffice.office_unit_id = ofcInfo.office_unit_id;
                //    dboffice.office_unit_organogram_id = ofcInfo.office_unit_organogram_id;
                //    dboffice.office_name_bn = ofcInfo.office_name_bn;
                //    dboffice.unit_name_bn = ofcInfo.unit_name_bn;
                 
                //    dboffice.employee_record_id = ofcInfo.employee_record_id;

                //    dboffice.designation=ofcInfo.designation;
                //    dboffice.incharge_label=ofcInfo.incharge_label;

                //    dboffice.office_unit_organogram_id = ofcInfo.office_unit_organogram_id;
                //    dboffice.office_id = ofcInfo.office_id;

                //    _officeRepository.Update(dboffice);
                //}
            }
        }
        public void DeleteLocalOfficeInfo()
        {

           
                var dboffices = _officeRepository.Table.ToList();
                if (dboffices.Count>0)
                {
                    _officeRepository.Delete(dboffices);
                }
                
            
        }
        public void SaveOrUpdateToken(string token)
        {
            var dbtoken = _userTokenRepository.Table.FirstOrDefault();
            if (dbtoken == null)
            {
                _userTokenRepository.Insert(new UserToken {Token=token});
            }
            else
            {
                dbtoken.Token = token;
                _userTokenRepository.Update(dbtoken);
            }
        }

        public string GetToken()
        {
            var dbtoken = _userTokenRepository.Table.FirstOrDefault();
            return dbtoken.Token;
        }

        public DakUserParam GetLocalDakUserParam()
        {
           
            OfficeInfoDTO officeInfo = GetOfficeInfo();
            EmployeeInfoDTO employeeInfoDTO = GetEmployeeInfo();
            UserDTO userDTO = GetUserInfo();



            DakUserParam dakListUserParam = new DakUserParam();


            try
            {
                dakListUserParam.token = GetToken();
                dakListUserParam.office_id = officeInfo.office_id;
             
                dakListUserParam.unit_id = officeInfo.office_unit_id;
                dakListUserParam.designation_id = officeInfo.office_unit_organogram_id;
                dakListUserParam.office_label = officeInfo.office_name_bn;
                dakListUserParam.unit_label = officeInfo.unit_name_bn;
                dakListUserParam.SignBase64 = userDTO.SignBase64;
                dakListUserParam.profile_photo = userDTO.profile_photo;

              //  dakListUserParam.office_id = officeInfo.office_id;
                dakListUserParam.employee_record_id = officeInfo.employee_record_id;

                dakListUserParam.designation_label = officeInfo.designation;
                dakListUserParam.incharge_label = officeInfo.incharge_label;

                dakListUserParam.officer_name = employeeInfoDTO.name_bng;
                dakListUserParam.designation_level = officeInfo.designation_level;
                dakListUserParam.user_id = userDTO.userid;
                dakListUserParam.json_String = new JavaScriptSerializer().Serialize(dakListUserParam);

                dakListUserParam.fatherName = employeeInfoDTO.father_name_bng;
                dakListUserParam.motherName = employeeInfoDTO.mother_name_bng;
                dakListUserParam.DateofBirth = employeeInfoDTO.date_of_birth.ToString("dd-MM-yyyy");
                dakListUserParam.nationalId = employeeInfoDTO.nid;
                dakListUserParam.birthCertificate = employeeInfoDTO.bcn;
                dakListUserParam.loginId = userDTO.username;
                dakListUserParam.doptor_token = userDTO.doptor_token;
                if (employeeInfoDTO.joining_date != null)
                {
                    dakListUserParam.joiningDate = employeeInfoDTO.joining_date.ToString();
                }
              

              

            }
            catch
            {

            }

            return dakListUserParam;
        }

        public bool ValidatePassword(char passChar)
        {
            var regexItem = new Regex("^[a-zA-Z0-9$@$!%*?&#^-_. +\b]+$");
            string pressedChar = passChar.ToString();
            if (!regexItem.IsMatch(pressedChar))
            {
                return false;
               
            }
            else
            {
                return true;
            }
        }

        public string InvalidPasswordMessage()
        {
            return "দয়া করে শুধু মাত্র ইংরেজি কীবোর্ড ব্যাবহার করুন!";
        }
        protected string GetDakNothiCountEndPoint()
        {
            return DefaultAPIConfiguration.DakNothiCountEndPoint;
        }
        protected string GetNotificationSettingsEndPoint()
        {
            return DefaultAPIConfiguration.NotificationSettingsEndPoint;
        }
        protected string GetNotificationSettingsSaveEndPoint()
        {
            return DefaultAPIConfiguration.NotificationSettingsSaveEndPoint;
        }
        public EmployeDakNothiCountResponse GetDakNothiCountResponseUsingEmployeeDesignation(DakUserParam userParam)
        {
            EmployeDakNothiCountResponse dakNothiCount = new EmployeDakNothiCountResponse();
            if (!dNothi.Utility.InternetConnection.Check())
            {
                var nothiList = _userItem.Table.FirstOrDefault(a => a.office_unit_id == userParam.office_unit_id && a.office_id == userParam.office_id && a.designation_id == userParam.designation_id);

                if (nothiList != null)
                {
                    dakNothiCount = JsonConvert.DeserializeObject<EmployeDakNothiCountResponse>(nothiList.responseJson);

                }
                return dakNothiCount;
            }
            try
            {
                var dakNothiCountAPI = new RestClient(GetAPIDomain() + GetDakNothiCountEndPoint());
                dakNothiCountAPI.Timeout = -1;
                var dakNothiCountAPIRequest = new RestRequest(Method.POST);
                dakNothiCountAPIRequest.AddHeader("api-version", GetAPIVersion());
                dakNothiCountAPIRequest.AddHeader("Authorization", "Bearer " + userParam.token);
                dakNothiCountAPIRequest.AlwaysMultipartFormData = true;
                dakNothiCountAPIRequest.AddParameter("designation_id", userParam.designation_id);
                dakNothiCountAPIRequest.AddParameter("office_id", userParam.office_id);
                IRestResponse dakNothiCountAPIResponse = dakNothiCountAPI.Execute(dakNothiCountAPIRequest);


                var dakNothiCountAPIJson = dakNothiCountAPIResponse.Content;
                SaveOrUpdateGetDakNothiCountResponse(userParam, dakNothiCountAPIJson);
                dakNothiCount = JsonConvert.DeserializeObject<EmployeDakNothiCountResponse>(dakNothiCountAPIJson);
                return dakNothiCount;
            }
            catch (Exception ex)
            {
                return dakNothiCount;
            }
        }
        public void SaveOrUpdateGetDakNothiCountResponse(DakUserParam dakUserParam, string responseJson)
        {
            var userItemDB = _userItem.Table.FirstOrDefault(a => a.office_unit_id == dakUserParam.office_unit_id && a.office_id == dakUserParam.office_id && a.designation_id == dakUserParam.designation_id);

            if (userItemDB != null)
            {
                userItemDB.responseJson = responseJson;
                _userItem.Update(userItemDB);
            }
            else
            {
                UserItem userItem = new UserItem();
                userItem.office_unit_id = dakUserParam.office_unit_id;
                userItem.designation_id = dakUserParam.designation_id;
                userItem.office_id = dakUserParam.office_id;
                userItem.responseJson = responseJson;
                _userItem.Insert(userItem);

            }
        }

        public NotificationSettingsResponse GetNotificationSettings(DakUserParam dakUserParam)
        {
            NotificationSettingsResponse notificationSettingsResponse = new NotificationSettingsResponse();
            try
            {
                var client = new RestClient(GetAPIDomain() + GetNotificationSettingsEndPoint());
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("api-version", GetAPIVersion());
                request.AddHeader("Authorization", "Bearer " + dakUserParam.token);
                request.AlwaysMultipartFormData = true;
                var serializedObject = JsonConvert.SerializeObject(dakUserParam);
                request.AddParameter("cdesk", serializedObject);
                IRestResponse response = client.Execute(request);


                var responseJson = response.Content;
                notificationSettingsResponse = JsonConvert.DeserializeObject<NotificationSettingsResponse>(responseJson);
                return notificationSettingsResponse;
            }
            catch (Exception ex)
            {
                return notificationSettingsResponse;
            }
        }

        public NotificationSettingsSaveResponse SaveNotificationSettings(DakUserParam dakUserParam, NotificationSettingsData notificationSettingsData)
        {
            NotificationSettingsSaveResponse notificationSettingsResponse = new NotificationSettingsSaveResponse();
            try
            {
                var client = new RestClient(GetAPIDomain() + GetNotificationSettingsSaveEndPoint());
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("api-version", GetAPIVersion());
                request.AddHeader("Authorization", "Bearer " + dakUserParam.token);
                request.AlwaysMultipartFormData = true;
                var serializedObject = JsonConvert.SerializeObject(dakUserParam);
                var notificationSerializedObject = JsonConvert.SerializeObject(notificationSettingsData);
                request.AddParameter("cdesk", serializedObject);
                request.AddParameter("actions", notificationSerializedObject);
                IRestResponse response = client.Execute(request);


                var responseJson = response.Content;
                notificationSettingsResponse = JsonConvert.DeserializeObject<NotificationSettingsSaveResponse>(responseJson);
                return notificationSettingsResponse;
            }
            catch (Exception ex)
            {
                return notificationSettingsResponse;
            }
        }
    }
}