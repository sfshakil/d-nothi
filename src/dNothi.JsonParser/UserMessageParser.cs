using Newtonsoft.Json;
using dNothi.JsonParser.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.JsonParser
{
    public class UserMessageParser : IUserMessageParser
    {
        public UserMessage ParseMessage(string messageString)
        {
            try
            {
                UserMessage messageObject = JsonConvert.DeserializeObject<UserMessage>(messageString);
                return messageObject;
            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}
