using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Services.AccountServices
{
    public class TokenService
    {
        private HttpClient client;
        public TokenService()
        {
            client = new HttpClient();
        }
        //public async Task<string> GetTokenAsync()
        //{
            

        //    try
        //    {
                
        //    }
        //    catch (Exception ex)
        //    {
        //        //Debug.WriteLine(@"				ERROR {0}", ex.Message);
        //    }

        //   // return _smsLogs;
        //}
    }
}
