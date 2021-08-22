using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.JsonParser.Entity
{
    public class UserMessage
    {
        public string status { get; set; }
        public DataDTO data { get; set; }
    }

    public class DoptorTokenResponse
    {
        public string status { get; set; }

        public DoptorTokenResponseData data { get; set; }
    }

    public class DoptorTokenResponseData
    {
        public string token { get; set; }

     
    }

}
