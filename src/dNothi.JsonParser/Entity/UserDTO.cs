﻿
using Newtonsoft.Json;

namespace dNothi.JsonParser.Entity
{
    public class UserDTO
    {
       

        [JsonProperty("id")]
        public int userid { get; set; }
        public string username { get; set; }
        public string user_alias { get; set; }
        public bool active { get; set; }
        public int employee_record_id { get; set; }
        public string SignBase64 { get; set; }
        public string doptor_token { get; set; }
        public string profile_photo { get; set; }

    


    }
}
