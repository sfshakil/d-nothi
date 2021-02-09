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

namespace dNothi.Services.UserServices
{
    public class UserService : IUserService
    {
        IUserMessageParser _userMessageParser;
        IRepository<User> _userrepository;
        IRepository<EmployeeInfo> _employeeRepository;
        IRepository<OfficeInfo> _officeRepository;
        IRepository<UserToken> _userTokenRepository;
        private static readonly log4net.ILog _log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public UserService(IUserMessageParser userMessageParser,
        IRepository<User> userrepository,
        IRepository<EmployeeInfo> employeeRepository,
        IRepository<OfficeInfo> officeRepository,
        IRepository<UserToken> userTokenRepository)
        {
            _userMessageParser = userMessageParser;
            _employeeRepository = employeeRepository;
            _userrepository = userrepository;
            _officeRepository = officeRepository;
            _userTokenRepository = userTokenRepository;
        }

       

        public async Task<UserMessage> GetUserMessageAsync(UserParam userParam)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var url = GetAPIDomain() + GetLoginEndpoint();
                    var json = JsonConvert.SerializeObject(userParam);
                    var data = new StringContent(json, Encoding.UTF8, "application/json");
                    client.DefaultRequestHeaders.Add("api-version", GetAPIVersion());
                    client.DefaultRequestHeaders.Add("device-id", GetDeviceId());
                    client.DefaultRequestHeaders.Add("device-type", GetDeviceType());
                    var response = await client.PostAsync(url, data);
                    string result = await response.Content.ReadAsStringAsync();
                    UserMessage responsemessage = _userMessageParser.ParseMessage(result);
                    return responsemessage;
                }
            }
            catch (Exception ex)
            {
                throw;
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
            var empInfo = _officeRepository.Table.FirstOrDefault(a=>a.is_current==true);
            if(empInfo == null)
            {
                empInfo= _officeRepository.Table.FirstOrDefault();
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
            var dbuser = _userrepository.Table.FirstOrDefault();



            if (dbuser == null)
            {
                _userrepository.Insert(user);
            }
            else
            {
                dbuser.userid = user.userid;
                dbuser.SignBase64 = userdto.SignBase64;
                
                _userrepository.Update(dbuser);
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
              //  dakListUserParam.office_id = officeInfo.office_id;
                dakListUserParam.employee_record_id = officeInfo.employee_record_id;

                dakListUserParam.designation_label = officeInfo.designation;
                dakListUserParam.incharge_label = officeInfo.incharge_label;

                dakListUserParam.officer_name = employeeInfoDTO.name_bng;
                dakListUserParam.designation_level = officeInfo.designation_level;
                dakListUserParam.user_id = userDTO.userid;
                dakListUserParam.json_String = new JavaScriptSerializer().Serialize(dakListUserParam);




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
    }
}