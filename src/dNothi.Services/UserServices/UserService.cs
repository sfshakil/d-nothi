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
        public async Task<UserMessage> GetUserMessageAsync()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var url = "https://a2i.nothibs.tappware.com/api/login";
                    var person = new UserParam();
                    person.username = "200000002986";
                    person.password = "abc123";
                    var json = JsonConvert.SerializeObject(person);
                    var data = new StringContent(json, Encoding.UTF8, "application/json");
                    client.DefaultRequestHeaders.Add("api-version", "1");
                    client.DefaultRequestHeaders.Add("device-id", "1234567890");
                    client.DefaultRequestHeaders.Add("device-type", "android");
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
    }
}
