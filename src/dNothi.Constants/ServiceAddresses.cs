using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Constants
{
    public class DefaultAPIConfiguration
    {
        public const string DefaultAPIDomainAddress = "https://dev.nothibs.tappware.com";
        public const string OCREndpoint = "http://bokshi-img2txt.tappware.com/apiImageToText/";
        public const string DakFileDeleteEndPoint = "/api/content/daak/delete";
        public const string NewAPIversion = "2";
        public const string DefaultAPIversion = "1";
        public const string DefaultDeviceId = "1234567890";
        public const string DefaultDeviceType = "android";
        public const string LoginEndPoint = "/api/login";
        public const string NothiListInboxEndPoint = "/api/nothi/list/inbox";
        public const string DakListInboxEndPoint = "/api/dak/inbox";
        public const string DakListOutboxEndPoint = "/api/dak/outbox";
        public const string DakListNothivuktoEndPoint = "/api/dak/nothivukto";
        public const string DakListNothijatoEndPoint = "/api/dak/nothijato";
        public const string DakListOnulipiEndPoint = "/api/dak/onulipi";
        public const string DakListSortedEndPoint = "/api/dak/sorted";
        public const string DakDetailsEndpoint = "/api/dak/view";
        public const string DakAttachmentEndpoint = "/api/dak/attachments";
        public const string DakMovementStatusListEndpoint = "/api/dak/movements";
        public const string GetDesignationSealListEndpoint = "/api/dak/seal/list";
        public const string GetDakForwardEndpoint = "/api/dak/forward";
        public const string DakListKhosraEndPoint = "/api/dak/khoshra";
        public const string DakFileUploadEndPoint = "/api/content/upload";
       
    }
}
