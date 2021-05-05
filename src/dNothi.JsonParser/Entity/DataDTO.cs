using Newtonsoft.Json;
using System.Collections.Generic;

namespace dNothi.JsonParser.Entity
{
    public class DataDTO
    {
        [JsonProperty("User")]
        public UserDTO user { get; set; }
        public EmployeeInfoDTO employee_info { get; set; }

        public List<OfficeInfoDTO> office_info { get; set; }
        public string token { get; set; }

        public SignatureDTO signature { get; set; }

        public int office_sync { get; set; }

    }
}
