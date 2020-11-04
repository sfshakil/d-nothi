using dNothi.Core.Entities;
using dNothi.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

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
            var user = _userRepository.Table.Where(u => u.Name == username && u.Password == password).FirstOrDefault();

            return user;
        }


    }
}
