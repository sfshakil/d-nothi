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
    public class AllPotroParser : IAllPotroParser
    {
        public AllPotroResponse ParseMessage(string messageString)
        {
            try
            {
                AllPotroResponse messageObject = JsonConvert.DeserializeObject<AllPotroResponse>(messageString);

                foreach (var record in messageObject?.data?.records)
                {
                    record.note_onucchedDTOList = new AllPotroDataRecordNoteOnucchedDTO();
                    var tdesk = JToken.Parse(JsonConvert.SerializeObject(record.note_onucched));
                    if (tdesk is JObject)
                    {
                        AllPotroDataRecordNoteOnucchedDTO note_onucched1 = tdesk.ToObject<AllPotroDataRecordNoteOnucchedDTO>();
                        record.note_onucchedDTOList = note_onucched1;
                    }
                    else if (tdesk is JArray)
                    {
                        AllPotroDataRecordNoteOnucchedDTO note_onuccheddtoList = tdesk.ToObject<AllPotroDataRecordNoteOnucchedDTO>();
                        record.note_onucchedDTOList = note_onuccheddtoList;
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
