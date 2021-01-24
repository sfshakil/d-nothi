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
    public class NoteListParser : INoteListParser
    {
        public NoteAllListResponse ParseMessage(string messageString)
        {
            try
            {
                NoteAllListResponse messageObject = JsonConvert.DeserializeObject<NoteAllListResponse>(messageString);

                foreach (var record in messageObject?.data?.records)
                {
                    record.deskDtoList = new List<NoteListDataRecordDeskDTO>();
                    var tdesk = JToken.Parse(JsonConvert.SerializeObject(record.desk));
                    if (tdesk is JObject)
                    {
                        NoteListDataRecordDeskDTO desk = tdesk.ToObject<NoteListDataRecordDeskDTO>();
                        record.deskDtoList.Add(desk);
                    }
                    else if (tdesk is JArray)
                    {
                        List<NoteListDataRecordDeskDTO> desksdtoList = tdesk.ToObject<List<NoteListDataRecordDeskDTO>>();
                        record.deskDtoList = desksdtoList;
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
