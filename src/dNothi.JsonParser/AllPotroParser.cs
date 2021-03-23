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
                    record.note_onucchedDTOList = new List<AllPotroDataRecordNoteOnucchedDTO>();
                    var tnote_onucched = JToken.Parse(JsonConvert.SerializeObject(record.note_onucched));
                    if (tnote_onucched is JObject)
                    {
                        AllPotroDataRecordNoteOnucchedDTO note_onucched1 = tnote_onucched.ToObject<AllPotroDataRecordNoteOnucchedDTO>();
                        record.note_onucchedDTOList.Add(note_onucched1);
                    }
                    else if (tnote_onucched is JArray)
                    {
                       List<AllPotroDataRecordNoteOnucchedDTO> note_onuccheddtoList = tnote_onucched.ToObject <List<AllPotroDataRecordNoteOnucchedDTO>>();
                        record.note_onucchedDTOList = note_onuccheddtoList;
                    }
                }

                foreach (var record in messageObject?.data?.records)
                {
                    record.note_ownerDTOList = new List<AllPotroDataRecordNoteOwnerDTO>();
                    var tnote_owner = JToken.Parse(JsonConvert.SerializeObject(record.note_owner));
                    if (tnote_owner is JObject)
                    {
                        AllPotroDataRecordNoteOwnerDTO note_owner1 = tnote_owner.ToObject<AllPotroDataRecordNoteOwnerDTO>();
                        record.note_ownerDTOList.Add(note_owner1);
                    }
                    else if (tnote_owner is JArray)
                    {
                        List<AllPotroDataRecordNoteOwnerDTO> note_onuccheddtoList = tnote_owner.ToObject<List<AllPotroDataRecordNoteOwnerDTO>>();
                        record.note_ownerDTOList = note_onuccheddtoList;
                    }
                }
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
