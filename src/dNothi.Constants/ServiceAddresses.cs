using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Constants
{
    public class DefaultAPIConfiguration
    {

        public const string DefaultAPIDomainAddress = "https://dev.nothibs.tappware.com";// dev server
       // public const string DefaultAPIDomainAddress = "https://api-bes.nothi.gov.bd";// Test Server
      
        public const string DakNothiCountEndPoint = "/api/module/pending";
        public const string PermittedPotroEndPoint = "/api/potro/permitted";
        public const string NothijatoProtibedonEndPoint = "/api/reports/dak/nothijato";
        public const string NothiteUposthapitoProtibedonEndPoint = "/api/reports/dak/nothite_uposthapito";
        public const string PotrojariProtibedonEndPoint = "/api/reports/dak/jarikrito";
        public const string PendingProtibedonEndPoint = "/api/reports/dak/pending";
        public const string ResolvesProtibedonEndPoint = "/api/reports/dak/resolved";
        public const string KhosraTemplateEndpoint = "/api/potro/templates";
        public const string DakGrohonEndPoint = "/api/register/dak/grohon";
        public const string DakBiliAddEndPoint = "/api/register/dak/bili";
        public const string DakDiaryEndPoint = "/api/register/dak/diary";
        public const string DakFolderMapEndPoint = "/api/dak/custom/folder/map";
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
        public const string GetNoteSearchListEndpoint = "/api/nothi/note/list";
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
        public const string OnuchhedFileUploadEndPoint = "/api/content/upload";
        public const string NothiInboxListEndPoint = "/api/nothi/list/inbox";
        public const string OtherOfficeNothiInboxListEndPoint = "/api/nothi/list/otheroffice/inbox";
        public const string NothiOutboxListEndPoint = "/api/nothi/list/outbox";
        public const string OtherOfficeNothiOutboxListEndPoint = "/api/nothi/list/otheroffice/outbox";
        public const string NothiAllListEndPoint = "/api/nothi/list/all";
        public const string NothiInboxNoteEndPoint = "/api/nothi/note/pending";
        public const string OtherOfficeNothiInboxNoteEndPoint = "/api/nothi/note/otheroffice/pending";
        public const string NothiInformationEndpoint = "/api/nothi/get_nothi";
        public const string NoteAttachmentsEndPoint = "/api/nothi/note/attachments";
        public const string NoteMovementsEndPoint = "/api/nothi/note/movement/list";

        public const string NothiOutboxNoteEndPoint = "/api/nothi/note/list";
        public const string NothiAllNoteEndPoint = "/api/nothi/note/permitted";

        public const string NothiCreateEndPoint = "/api/add";
        public const string NothiNotePermissionEndPoint = "/api/nothi/note/permission/save";
        public const string NothiPermissionSaveEndPoint = "/api/nothi/permission/save";
        public const string NothiNoteCreateEndPoint = "/api/nothi/note/create";
        public const string NoteOnuchhedSaveEndPoint = "/api/nothi/note/onucched/save";
        public const string NothiTypleListEndPoint = "/api/nothi/type/list";
        public const string NothiBranchListEndPoint = "/api/office/unit";
        public const string NothiNoteTalikaEndPoint = "/api/nothis";
        public const string NothiNumberEndPoint = "/api/nothi/generate/number";
        public const string NothiTypeCreateEndPoint = "/api/add";
        public const string NothiTypeDeleteEndPoint = "/api/delete";
        public const string NothiAuthorityEndPoint = "/api/nothi/authority";
        public const string NothiNoteAuthorityEndPoint = "/api/nothi/note/authority";
        public const string NoteOnuchhedSendEndPoint = "/api/nothi/note/onucched/send";
        public const string NoteOnuchhedDeleteEndPoint = "/api/nothi/note/onucched/delete";
        public const string NothiPotrangshoEndPoint = "/api/nothi/potro/status";
        public const string NothiPotrangshoAllPotroEndPoint = "/api/nothi_all_potro_list";
        public const string NothiPotrangshoKhoshraPotroEndPoint = "/api/nothi_khoshra_potro_list";
        public const string NothiPotrangshoNothivuktoPotroEndPoint = "/api/nothi_nothivukto_potro_list";
        public const string NothiPotrangshoKhoshraPotroWaitingEndPoint = "/api/nothi_khoshra_waiting_for_approval_list";
        public const string NothiPotrangshoPotrojariEndPoint = "/api/nothi_potrojari_list";
        public const string NothiPotrangshoNothijatoEndPoint = "/api/nothi_nothijato_potro_list";
        public const string NothiPotrangshoNotePotrojariEndPoint = "/api/nothi_potrojari_list";
        public const string NothiPotrangshoNoteKhshrapotroEndPoint = "/api/nothi_khoshra_potro_list";
        public const string NothiNoteSingleOnucchedEndPoint = "/api/nothi/note/onucched";
        public const string NothiNoteOnucchedListEndPoint = "/api/nothi/note/onucched/list";
        public const string NothiNoteOnucchedRevertEndPoint = "/api/nothi/note/onucched/revert";
        public const string NothiDecisionListEndpoint = "/api/nothi/decision/list";
        public const string NothiALLDecisionListEndpoint = "/api/nothi/decision/list/all";
        public const string NothiAddDecisionListEndpoint = "/api/nothi/decision/add";
        public const string NothiDeleteDecisionListEndpoint = "/api/nothi/decision/delete";
        public const string NothiGaurdFileListEndpoint = "/api/nothi/guardfile/list";
        public const string NothiBibechhoPotroListEndpoint = "/api/nothi_all_potro_list";
        public const string NothiOnuchhedListEndpoint = "/api/nothi/onucched/list";
        public const string NothiPotakaListEndpoint = "/api/nothi/potaka/list";
        public const string NoteFinishedEndPoint = "/api/nothi/note/finish";
        public const string NothiReportEndPoint = "/api/nothi/nibondhon_bohi";
        public const string NothiProtibedanUnitWiseEndPoint = "/api/nothi/list/unit_wise";
        public const string NothiPotakaSaveEndPoint = "/api/potro/flag/save";
        public const string NothiReviewerEndPoint = "/api/nothi/reviewer";
        public const string NothiSharedOff = "/api/nothi/review/setup";
        public const string NothiSharedByMeEndPoint = "/api/nothi/review/shared_by_me";
        public const string NothiSharedToMeEndPoint = "/api/nothi/review/shared_to_me";
        public const string NothiSharedRecentEndPoint = "/api/nothi/review/shared_recent";
        public const string NothiSharedEditorDataEndPoint = "/api/potro/import";

        public const string DakNibondanBohiEndPoint = "/api/register/dak/nibondhon_bohi";


        //KasaraPattraDashBoardApi
        public const string nothidraftpotrolist = "/api/nothi_draft_khoshra_list";
        public const string nothikhoshrapotrolist = "/api/nothi_khoshra_potro_list";
        public const string nothikhoshrawaitingforapprovallist = "/api/nothi_khoshra_waiting_for_approval_list";
        public const string nothiapprovedpotrolist = "/api/nothi_approved_potro_list";
        public const string nothipotrojariassenderapproverlist = "/api/nothi_potrojari_as_sender_approver_list";

        public const string mulPattraAndSanjukti = "/api/potro/document";
        public const string prapakerTalika = "/api/potrojari/recipient/list";
        public const string kasaraDashboard = "/api/khoshra/statistics/designation";

        //GuardFileApi
        public const string GuardFileCategoryList = "/api/nothi/guardfile/category/list";
        public const string GuardFileList = "/api/nothi/guardfile/list";
        public const string GuardFileCreateEdit = "/api/add";
        public const string GuardFileDelete = "/api/delete";

        public const string guardFileOfficelist= "/api/nothi/guardfile/portal/office/list";
        public const string guardFilePortallist = "/api/nothi/guardfile/portal/list";
        public const string guardFilePortalInsert = "/api/nothi/guardfile/portal/add";

        //DakSharing

        public const string SharingList = "/api/dak/sorting/designation";
        public const string DakInbox = "/api/dak/inbox";
        public const string SharingAdd = "/api/dak/sorting/add";
        public const string SharingDelete = "/api/dak/sorting/delete";
        public const string DakSorting = "/api/dak/sort";
        public const string DakSortingDelete = "/api/dak/sort/delete";
       




        public static string PotroOnumodonEndPoint = "/api/potro/approve";
        public static string PotrojariEndPoint = "/api/potro/dispatch";
       
        
        public static string KhosraSaveEndpoint = "/api/potro/save";

        
        
        // Khosara
        public const string SharokNoEndpoint = "/api/potro/setup/dispatch";

        //potrajari Group

        public const string potraJariTalikaEndpoint = "/api/potrojari/group";
        public const string potraJariTalikaDistrictCommissionerEndpoint = "/api/district_commissioner/all";
        public const string potraJariTalikaDeputyCommissionerEndpoint = "/api/deputy_commissioner/all";
        public const string potraJariTalikaUNOEndpoint = "/api/uno/all";
        public const string potraJariTalikaOfficeHeadEndpoint = "/api/office_head/all";
        public const string potraJariTalikaOfficeAdminEndpoint = "/api/office_admin/all";
        public const string potraJariGroupCreateEndpoint = "/api/potrojari/group/save";
        public const string potraJariGroupDeleteEndpoint = "/api/potrojari/group/delete";

        //BasicApi
        public const string OfficeUintEndpoint = "/api/dak/seal/office/show";


        // Doptor

        public const string DoptorDomainAddress = "https://n-doptor-api-stage.nothi.gov.bd";
        public const string DoptorDomainAddressLocal = "http://127.0.0.1:8000";
        public const string DoptorLoginEndPoint = "/api/client/login";
        public const string DoptorPasswordChangeEndPoint = "/api/user/password/update";
        public const string DoptorPhotoChangeEndPoint = "/api/user/image/update";
        public const string DoptorSignChangeEndPoint = "/api/user/signature/update";
        public const string DoptorSignEndPoint = "/api/user/signatures/";
        public const string DoptorProfilePicEndPoint = "/api/user/images/";



    }
}
