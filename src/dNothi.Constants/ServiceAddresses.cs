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
        public const string DakListFromFolderEndPoint = "/api/dak/personal";
        public const string DakFolderListEndPoint = "/api/dak/customlabel/designation";
        public const string DakFolderDeleteEndPoint = "/api/dak/customlabel/delete";
        public const string DakFolderAddEndPoint = "/api/dak/customlabel/add";
        public const string DakSearchEndPoint = "/api/dak/search";
        public const string PotroTemplateEndPoint = "/api/potro/templates";
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
        public const string GetNoteListAllEndpoint = "/api/nothi/note/permitted";
        public const string GetNoteListInboxEndpoint = "/api/nothi/note/pending";
        public const string GetNoteListSentpoint = "/api/nothi/note/list";
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
        public const string NothiInboxListEndPoint = "/api/nothi/list/inbox";
        public const string NothiOutboxListEndPoint = "/api/nothi/list/outbox";
        public const string NothiAllListEndPoint = "/api/nothi/list/all";
        public const string NothiInboxNoteEndPoint = "/api/nothi/note/pending";
        public const string NothiCreateEndPoint = "/api/add";
        public const string NothiNotePermissionEndPoint = "/api/nothi/note/permission/save";
        public const string NothiPermissionSaveEndPoint = "/api/nothi/permission/save";
        public const string NothiNoteCreateEndPoint = "/api/nothi/note/create";
        public const string NoteOnuchhedSaveEndPoint = "/api/nothi/note/onucched/save";
        public const string NothiTypleListEndPoint = "/api/nothi/type/list";
        public const string NothiNoteTalikaEndPoint = "/api/nothis";
        public const string NothiTypeCreateEndPoint = "/api/add";
        public const string NothiTypeDeleteEndPoint = "/api/delete";
        public const string NothiAuthorityEndPoint = "/api/nothi/authority";
        public const string NoteOnuchhedSendEndPoint = "/api/nothi/note/onucched/send";
        public const string NoteOnuchhedDeleteEndPoint = "/api/nothi/note/onucched/delete";
        public const string NothiPotrangshoEndPoint = "/api/nothi/potro/status";
        public const string NothiPotrangshoAllPotroEndPoint = "/api/nothi_all_potro_list";
        public const string NothiPotrangshoKhoshraPotroEndPoint = "/api/nothi_khoshra_potro_list";
        public const string NothiPotrangshoKhoshraPotroWaitingEndPoint = "/api/nothi_khoshra_waiting_for_approval_list";
        public const string NothiPotrangshoPotrojariEndPoint = "/api/nothi_potrojari_list";
        public const string NothiPotrangshoNothijatoEndPoint = "/api/nothi_nothijato_potro_list";
        public const string NothiPotrangshoNotePotrojariEndPoint = "/api/nothi_potrojari_list";
        public const string NothiPotrangshoNoteKhshrapotroEndPoint = "/api/nothi_khoshra_potro_list";
        public const string NothiNoteSingleOnucchedEndPoint = "/api/nothi/note/onucched";
        public const string NothiNoteOnucchedListEndPoint = "/api/nothi/note/onucched/list";
        public const string NothiNoteOnucchedRevertEndPoint = "/api/nothi/note/onucched/revert";


    }
}
