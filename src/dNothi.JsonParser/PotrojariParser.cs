using dNothi.JsonParser.Entity.Nothi;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.JsonParser
{
    public class PotrojariParser : IPotrojariParser
    {
        public PotrojariResponse ParseMessage(string messageString)
        {
            try
            {
                PotrojariResponse messageObject = JsonConvert.DeserializeObject<PotrojariResponse>(messageString);

                foreach (var record in messageObject?.data?.records)
                {
                    record.mulpotro.buttonsDTOList = new List<String>();
                    var tbuttons = JToken.Parse(JsonConvert.SerializeObject(record.mulpotro.buttons));
                    if (tbuttons is JObject)
                    {
                        String buttons1 = tbuttons.ToString(); //tbuttons.ToObject<String>();
                        record.mulpotro.buttonsDTOList.Add(buttons1);
                    }
                    else if (tbuttons is JArray)
                    {
                        List<String> buttons1 = tbuttons.ToObject<List<String>>();
                        record.mulpotro.buttonsDTOList = buttons1;
                    }
                }

                return messageObject;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
