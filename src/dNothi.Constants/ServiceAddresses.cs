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
        public const string DakArchiveRevertEndPoint = "/api/dak/revert/archive";
        public const string DakNothivuktoRevertEndPoint = "/api/nothi/dak/revert/nothivukto";
        public const string DakForwardRevertEndPoint = "/api/dak/revert/sent";
        public const string NothivuktoNoteAddEndPoint = "/api/nothi/note/create";
        public const string DakNothijatoEndpoint = "/api/nothi/dak/nothijato";
        public const string DakNothijatoRevertEndpoint = "/api/nothi/dak/revert/nothijato";
        public const string DakDecisionListEndpoint = "/api/dak/decision/list/custom";
        public const string DakArchiveEndPoint = "/api/dak/action/archive";
        public const string DakDecisionAddEndpoint = "/api/dak/decision/add";
        public const string DakDecisionDeleteEndpoint = "/api/dak/decision/delete";
        public const string DakDecisionSetupEndpoint = "/api/dak/decision/setup";
        public const string GetNoteListEndpoint = "/api/nothi/note/list";
        public const string DakNothivuktoEndpointEndPoint = "/api/nothi/dak/nothivukto";
        public const string OCREndpoint = "http://bokshi-img2txt.tappware.com/apiImageToText/";
        public const string DesignationSealDeleteEndpoint = "/api/dak/seal/delete";
        public const string DesignationSealAddEndpoint = "/api/dak/seal/add";
        public const string OfficeListEndpoint = "/api/dak/office/relational-map";
        public const string DraftedDakEditEndpoint = "/api/dak/draft";
        public const string AllDesignationSealEndPoint = "/api/office/organograms";
        public const string DakSendEndpoint = "/api/dak/upload/send";
        public const string DakDraftEndpoint = "/api/dak/upload";
        public const string DraftedDakSendEndpoint = "/api/dak/send";
        public const string DraftedDakDeleteEndpoint = "/api/dak/draft/delete";
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
        public const string NothiInboxNoteEndPoint = "/api/nothi/note/pending";
        public const string NothiCreateEndPoint = "/api/add";
        public const string NothiNotePermissionEndPoint = "/api/nothi/note/permission/save";


    }
}
