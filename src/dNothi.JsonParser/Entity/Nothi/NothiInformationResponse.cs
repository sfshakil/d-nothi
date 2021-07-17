using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.JsonParser.Entity.Nothi
{
    public partial class NothiInformationResponse
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("data")]
        public Data Data { get; set; }

        [JsonProperty("options")]
        public object[] Options { get; set; }
    }

    public partial class Data
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("office_id")]
        public long OfficeId { get; set; }

        [JsonProperty("office_name")]
        public string OfficeName { get; set; }

        [JsonProperty("office_unit_id")]
        public long OfficeUnitId { get; set; }

        [JsonProperty("office_unit_name")]
        public string OfficeUnitName { get; set; }

        [JsonProperty("office_unit_organogram_id")]
        public long OfficeUnitOrganogramId { get; set; }

        [JsonProperty("office_designation_name")]
        public string OfficeDesignationName { get; set; }

        [JsonProperty("nothi_no")]
        public string NothiNo { get; set; }

        [JsonProperty("subject")]
        public string Subject { get; set; }

        [JsonProperty("nothi_class")]
        public long NothiClass { get; set; }

        [JsonProperty("nothi_type_id")]
        public long NothiTypeId { get; set; }
    }
}
