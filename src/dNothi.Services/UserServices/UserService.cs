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
using Nothi.Core.Entities;

namespace dNothi.Services.UserServices
{
    public class UserService : IUserService
    {
        IUserMessageParser _userMessageParser;
        IRepository<User> _userrepository;
        IRepository<EmployeeInfo> _employeeRepository;
        IRepository<OfficeInfo> _officeRepository;
        IRepository<UserToken> _userTokenRepository;
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
                    var url = "https://a2i.nothibs.tappware.com/api/login";
                    var json = JsonConvert.SerializeObject(userParam);
                    var data = new StringContent(json, Encoding.UTF8, "application/json");
                    client.DefaultRequestHeaders.Add("api-version", "1");
                    client.DefaultRequestHeaders.Add("device-id", "1234567890");
                    client.DefaultRequestHeaders.Add("device-type", "android");
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
            var empInfo = _userrepository.Table.FirstOrDefault();
            var config = new MapperConfiguration(cfg =>
                    cfg.CreateMap<EmployeeInfo, EmployeeInfoDTO>()
                );
            var mapper = new Mapper(config);
            var employeeInfoDTO = mapper.Map<EmployeeInfoDTO>(empInfo);
            return employeeInfoDTO;
        }

        public OfficeInfoDTO GetOfficeInfo()
        {
            var empInfo = _userrepository.Table.FirstOrDefault();
            var config = new MapperConfiguration(cfg =>
                    cfg.CreateMap<OfficeInfo, OfficeInfoDTO>()
                );
            var mapper = new Mapper(config);
            var officeInfoDTO = mapper.Map<OfficeInfoDTO>(empInfo);
            return officeInfoDTO;
        }

        public void SaveOrUpdateUser(UserDTO userdto)
        {
            var config = new MapperConfiguration(cfg =>
                    cfg.CreateMap<UserDTO, User>()
                );
            var mapper = new Mapper(config);
            var user = mapper.Map<User>(userdto);
            var dbuser = _userrepository.Table.Where(q => q.username == userdto.username).FirstOrDefault();
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

        public void SaveOrUpdateUserOfficeInfo(List<OfficeInfoDTO> officeinfodtos)
        {

            var config = new MapperConfiguration(cfg =>
                    cfg.CreateMap<OfficeInfoDTO, OfficeInfo>()
                );
            var mapper = new Mapper(config);


            foreach (var officeinfodto in officeinfodtos)
            {
                var ofcInfo = mapper.Map<OfficeInfo>(officeinfodto);
                var dboffice = _officeRepository.Table.Where(q => q.employee_record_id == officeinfodto.employee_record_id).FirstOrDefault();
                if (dboffice == null)
                {
                    _officeRepository.Insert(ofcInfo);
                }
                else
                {
                    _officeRepository.Update(ofcInfo);
                }
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
    }
}