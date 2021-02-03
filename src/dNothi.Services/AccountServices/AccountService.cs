using dNothi.Core.Entities;
using dNothi.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Security.Cryptography;

namespace dNothi.Services.AccountServices
{
    public class AccountService : IAccountService
    {
        private readonly IRepository<AppUser> _userRepository;
        public AccountService(IRepository<AppUser> userRepository)
        {
            _userRepository = userRepository;
        }
        public AppUser LoginUser(string username, string password)
        {
            var data = Encoding.ASCII.GetBytes(password);
            var sha1 = new SHA1CryptoServiceProvider();
            var sha1data = sha1.ComputeHash(data);
            var user = _userRepository.Table.Where(u => u.UserName == username && u.PasswordHash == sha1data).FirstOrDefault();
            return user;
        }
        public void SaveOrUpdateUser(string username, string password, bool isRemember)
        {
            var user = _userRepository.Table.FirstOrDefault();
            if (user != null)
            {
                var data = Encoding.ASCII.GetBytes(password);
                

                var sha1 = new SHA1CryptoServiceProvider();
                
                var sha1data = sha1.ComputeHash(data);
                user.PasswordHash = sha1data;
                user.isRemember = isRemember;
               
                _userRepository.Update(user);
            }
            else
            {
                SaveUser(username, password, isRemember);
            }
        }
        public void SaveUser(string userName, string password,bool isRemember)
        {
            var data = Encoding.ASCII.GetBytes(password);
            var sha1 = new SHA1CryptoServiceProvider();
            var sha1data = sha1.ComputeHash(data);
            AppUser user = new AppUser { 
                UserName = userName,
                PasswordHash = sha1data,
                isRemember=isRemember
            };
            _userRepository.Insert(user);
        }
        public void DeleteUser(string userName, string password)
        {
            var user = _userRepository.Table.Where(u => u.UserName == userName).FirstOrDefault();
            if (user != null)
            {
                _userRepository.Delete(user);
            }
        }
        public void UpdateUser(string userName, string password, bool isRemember)
        {
            var user = _userRepository.Table.Where(u => u.UserName == userName).FirstOrDefault();
            if (user != null)
            {
                var data = Encoding.ASCII.GetBytes(password);
                var sha1 = new SHA1CryptoServiceProvider();
                var sha1data = sha1.ComputeHash(data);
                user.PasswordHash = sha1data;
                user.isRemember = isRemember;
                
                _userRepository.Update(user);
            }
        }


    }
}
