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

namespace dNothi.Services.UserServices
{
    public class UserService : IUserService
    {
        IUserMessageParser _userMessageParser;
        IRepository<User> _userrepository;
        IRepository<EmployeeInfo> _employeeRepository;
        
        public UserService(IUserMessageParser userMessageParser,
        IRepository<User> userrepository,
        IRepository<EmployeeInfo> employeeRepository)
        {
            _userMessageParser = userMessageParser;
            _employeeRepository = employeeRepository;
            _userrepository = userrepository;
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
                    string result =await response.Content.ReadAsStringAsync();
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
            var empInfo=_userrepository.Table.FirstOrDefault();
            var config = new MapperConfiguration(cfg =>
                    cfg.CreateMap<EmployeeInfo, EmployeeInfoDTO>()
                );
            var mapper = new Mapper(config);
            var employeeInfoDTO = mapper.Map<EmployeeInfoDTO>(empInfo);
            return employeeInfoDTO;
        }

        public void SaveOrUpdateUser(UserDTO userdto)
        {
            var config = new MapperConfiguration(cfg =>
                    cfg.CreateMap<UserDTO, User>()
                );
            var mapper = new Mapper(config);
            var user = mapper.Map<User>(userdto);
            var dbuser=_userrepository.Table.Where(q => q.username == userdto.username).FirstOrDefault();
            if (dbuser == null)
            {
                _userrepository.Insert(user);
            }
            else
            {
                _userrepository.Update(user);
            }
        }
        public void SaveOrUpdateUserEmployeeInfo(EmployeeInfoDTO employeedto)
        {
            var config = new MapperConfiguration(cfg =>
                    cfg.CreateMap<EmployeeInfoDTO, EmployeeInfo>()
                );
            var mapper = new Mapper(config);
            var empInfo = mapper.Map<EmployeeInfo>(employeedto);
            var dbemployee = _employeeRepository.Table.Where(q => q.Id == employeedto.id).FirstOrDefault();
            if (dbemployee == null)
            {
                _employeeRepository.Insert(empInfo);
            }
            else
            {
                _employeeRepository.Update(empInfo);
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
    }
}
