using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Services.ProfileChangeService
{
    public class PasswordChangeParam
    {
        public string oldPassword { get; set; }
        public string newPassword { get; set; }
    }
}
