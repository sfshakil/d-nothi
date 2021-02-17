using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.JsonParser.Entity.Nothi
{
    public class SingleOnucchedRecordSignatureDTO
    {
        [JsonProperty("1")]
        public SingleOnucchedRecordSignature1DTO Signature1 { get; set; }
        [JsonProperty("2")]
        public SingleOnucchedRecordSignature2DTO Signature2 { get; set; }
        [JsonProperty("3")]
        public SingleOnucchedRecordSignature3DTO Signature3 { get; set; }
        [JsonProperty("4")]
        public SingleOnucchedRecordSignature4DTO Signature4 { get; set; }
    }
}
