using Autofac;
using Autofac.Core;
using AutoMapper;
using dNothi.Core.Entities;
using dNothi.Core.Interfaces;
using dNothi.Desktop.Interfaces;
using dNothi.Infrastructure;
using dNothi.JsonParser;
using dNothi.Services.AccountServices;
using dNothi.Services.UserServices;
using dNothi.Core.Entities;
using dNothi.Services.DakServices;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using dNothi.Services.NothiServices;
using dNothi.Desktop.UI;
using System.Threading;
using dNothi.Desktop.UI.Dak;
using dNothi.Services.SyncServices;
using dNothi.Desktop.UI.NothiUI;
using dNothi.Services.KhasraService;
using dNothi.Desktop.UI.OtherModule;
using dNothi.Desktop.UI.GuardFileUI.GuardFileUserControls;
using dNothi.Services.GuardFile;
using dNothi.Services.DakServices.DakSharingService;
using dNothi.Services.PotroJariGroup;
using dNothi.Desktop.UI.PotroJariGroups;

namespace dNothi.Desktop
{
    static class Program
    {
        private static IContainer container;
        private static readonly log4net.ILog _log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            log4net.Config.XmlConfigurator.Configure();
            _log.Info("Application Stated!");
            // AppDomain.CurrentDomain.SetData("DataDirectory", Directory.GetCurrentDirectory());
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Database.SetInitializer<AppDbContext>(new DropCreateDatabaseIfModelChanges<AppDbContext>());
            Bootstrap();
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += ApplicationThreadException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomainOnUnhandledException;


            //var form = FormFactory.Create<Nothi>();
            //form.ShowDialog();
            DialogResult result;

            var form = FormFactory.Create<Login>();
            form.ShowDialog();
            //using (var form = FormFactory.Create<Login>())
            //{
            //    result = form.ShowDialog();
            //    if (result == DialogResult.OK)
            //    { form.Hide(); }
            //}
            //if (result == DialogResult.OK)
            //{
            //    //Application.Run(container.Resolve<Dashboard>());

            //    var form1 = FormFactory.Create<Dashboard>();
            //    form1.BringToFront();
            //    form1.ShowDialog();
            //    //form.Shown += delegate (object sr, EventArgs ev) { DoSomethingAsync(sr, ev, 0); };
            //}


            //Application.Run(container.Resolve<UI.Login>());
        }

        /// <summary>
        /// Global exceptions in Non User Interfarce(other thread) antipicated error
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void CurrentDomainOnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var message =
                String.Format(
                    "Sorry, something went wrong.\r\n" + "{0}\r\n" + "{1}\r\n" + "please contact support.",
                    ((Exception)e.ExceptionObject).Message, ((Exception)e.ExceptionObject).StackTrace);
            var logmessage = "Exception: " + ((Exception)e.ExceptionObject).Message + "Stack Trace: " + ((Exception)e.ExceptionObject).StackTrace;
            _log.Error(logmessage);
            MessageBox.Show(message, @"Unexpected error");

        }

        /// <summary>
        /// Global exceptions in User Interfarce antipicated error
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void ApplicationThreadException(object sender, ThreadExceptionEventArgs e)
        {
            var message =
                String.Format(
                    "Sorry, something went wrong.\r\n" + "{0}\r\n" + "{1}\r\n" + "please contact support.",
                    e.Exception.Message, e.Exception.StackTrace);
            var logmessage = "Exception: " + ((Exception)e.Exception).Message + "Stack Trace: " + ((Exception)e.Exception).StackTrace;
            _log.Error(logmessage);
            MessageBox.Show(message, @"Unexpected error");
        }

        private static void Bootstrap()
        {
            var builder = new ContainerBuilder();

            // Usually you're only interested in exposing the type
            // via its interface:
            builder.RegisterType<AppDbContext>().As<IDbContext>();
            builder.RegisterType<EfRepository<AppUser>>().As<IRepository<AppUser>>();
            builder.RegisterType<EfRepository<User>>().As<IRepository<User>>();


            builder.RegisterType<EfRepository<dNothi.Core.Entities.DakTag>>().As<IRepository<dNothi.Core.Entities.DakTag>>();
            builder.RegisterType<EfRepository<dNothi.Core.Entities.LocalUploadedDak>>().As<IRepository<dNothi.Core.Entities.LocalUploadedDak>>();

            builder.RegisterType<EfRepository<dNothi.Core.Entities.DakType>>().As<IRepository<dNothi.Core.Entities.DakType>>();
            builder.RegisterType<EfRepository<dNothi.Core.Entities.SyncStatus>>().As<IRepository<dNothi.Core.Entities.SyncStatus>>();
            builder.RegisterType<EfRepository<dNothi.Core.Entities.LocalOfficeList>>().As<IRepository<dNothi.Core.Entities.LocalOfficeList>>();
            builder.RegisterType<EfRepository<dNothi.Core.Entities.LocalDesignationSealByOffice>>().As<IRepository<dNothi.Core.Entities.LocalDesignationSealByOffice>>();



            builder.RegisterType<EfRepository<dNothi.Core.Entities.DakItem>>().As<IRepository<dNothi.Core.Entities.DakItem>>();
            builder.RegisterType<EfRepository<dNothi.Core.Entities.PotroTemplateList>>().As<IRepository<dNothi.Core.Entities.PotroTemplateList>>();
            builder.RegisterType<EfRepository<dNothi.Core.Entities.DakItemAction>>().As<IRepository<dNothi.Core.Entities.DakItemAction>>();
            builder.RegisterType<EfRepository<dNothi.Core.Entities.LocalDakFolderList>>().As<IRepository<dNothi.Core.Entities.LocalDakFolderList>>();


            builder.RegisterType<EfRepository<dNothi.Core.Entities.UserItem>>().As<IRepository<dNothi.Core.Entities.UserItem>>();
            builder.RegisterType<EfRepository<dNothi.Core.Entities.NothiItem>>().As<IRepository<dNothi.Core.Entities.NothiItem>>();
            builder.RegisterType<EfRepository<dNothi.Core.Entities.NoteItem>>().As<IRepository<dNothi.Core.Entities.NoteItem>>();
            builder.RegisterType<EfRepository<dNothi.Core.Entities.NothiNoteTalikaItem>>().As<IRepository<dNothi.Core.Entities.NothiNoteTalikaItem>>();
            builder.RegisterType<EfRepository<dNothi.Core.Entities.NothiTypeListItem>>().As<IRepository<dNothi.Core.Entities.NothiTypeListItem>>();
            builder.RegisterType<EfRepository<dNothi.Core.Entities.NothiOnumodonItem>>().As<IRepository<dNothi.Core.Entities.NothiOnumodonItem>>();
            builder.RegisterType<EfRepository<dNothi.Core.Entities.NothiNoteOnumodonItem>>().As<IRepository<dNothi.Core.Entities.NothiNoteOnumodonItem>>();
            builder.RegisterType<EfRepository<dNothi.Core.Entities.AllOfficeItem>>().As<IRepository<dNothi.Core.Entities.AllOfficeItem>>();
            builder.RegisterType<EfRepository<dNothi.Core.Entities.NothiPotrangshoItem>>().As<IRepository<dNothi.Core.Entities.NothiPotrangshoItem>>();
            builder.RegisterType<EfRepository<dNothi.Core.Entities.NoteOnuchhedListItem>>().As<IRepository<dNothi.Core.Entities.NoteOnuchhedListItem>>();
            builder.RegisterType<EfRepository<dNothi.Core.Entities.SingleNoteOnuchhedItem>>().As<IRepository<dNothi.Core.Entities.SingleNoteOnuchhedItem>>();
            builder.RegisterType<EfRepository<dNothi.Core.Entities.NoteInboxSentAllItem>>().As<IRepository<dNothi.Core.Entities.NoteInboxSentAllItem>>();
            builder.RegisterType<EfRepository<dNothi.Core.Entities.PotrangshoNothiItem>>().As<IRepository<dNothi.Core.Entities.PotrangshoNothiItem>>();
            builder.RegisterType<EfRepository<dNothi.Core.Entities.PotrangshoNoteItem>>().As<IRepository<dNothi.Core.Entities.PotrangshoNoteItem>>();
            builder.RegisterType<EfRepository<dNothi.Core.Entities.NothiTypeItemAction>>().As<IRepository<dNothi.Core.Entities.NothiTypeItemAction>>();
            builder.RegisterType<EfRepository<dNothi.Core.Entities.NothiCreateItemAction>>().As<IRepository<dNothi.Core.Entities.NothiCreateItemAction>>();
            builder.RegisterType<EfRepository<dNothi.Core.Entities.NoteSaveItemAction>>().As<IRepository<dNothi.Core.Entities.NoteSaveItemAction>>();
            builder.RegisterType<EfRepository<dNothi.Core.Entities.NoteSendItemAction>>().As<IRepository<dNothi.Core.Entities.NoteSendItemAction>>();
            builder.RegisterType<EfRepository<dNothi.Core.Entities.OnuchhedSaveItemAction>>().As<IRepository<dNothi.Core.Entities.OnuchhedSaveItemAction>>();
            builder.RegisterType<EfRepository<dNothi.Core.Entities.FileUploadAction>>().As<IRepository<dNothi.Core.Entities.FileUploadAction>>();


            builder.RegisterType<EfRepository<dNothi.Core.Entities.DakItemDetails>>().As<IRepository<dNothi.Core.Entities.DakItemDetails>>();

            builder.RegisterType<EfRepository<dNothi.Core.Entities.DakList>>().As<IRepository<dNothi.Core.Entities.DakList>>();
            builder.RegisterType<EfRepository<dNothi.Core.Entities.LocalDesignationSeal>>().As<IRepository<dNothi.Core.Entities.LocalDesignationSeal>>();
            builder.RegisterType<EfRepository<dNothi.Core.Entities.Officer>>().As<IRepository<dNothi.Core.Entities.Officer>>();
            builder.RegisterType<EfRepository<dNothi.Core.Entities.To>>().As<IRepository<dNothi.Core.Entities.To>>();
            builder.RegisterType<EfRepository<dNothi.Core.Entities.Other>>().As<IRepository<dNothi.Core.Entities.Other>>();
            builder.RegisterType<EfRepository<dNothi.Core.Entities.Other>>().As<IRepository<dNothi.Core.Entities.Other>>();
            builder.RegisterType<EfRepository<dNothi.Core.Entities.MovementStatus>>().As<IRepository<dNothi.Core.Entities.MovementStatus>>();
            builder.RegisterType<EfRepository<dNothi.Core.Entities.DakNothi>>().As<IRepository<dNothi.Core.Entities.DakNothi>>();
            builder.RegisterType<EfRepository<dNothi.Core.Entities.DakUser>>().As<IRepository<dNothi.Core.Entities.DakUser>>();
            builder.RegisterType<EfRepository<dNothi.Core.Entities.DakOrigin>>().As<IRepository<dNothi.Core.Entities.DakOrigin>>();
            builder.RegisterType<EfRepository<dNothi.Core.Entities.DakAttachment>>().As<IRepository<dNothi.Core.Entities.DakAttachment>>();


            builder.RegisterType<EfRepository<DakBoxSharedToOfficer>>().As<IRepository<DakBoxSharedToOfficer>>();
            builder.RegisterType<EfRepository<DakBoxSharing>>().As<IRepository<DakBoxSharing>>();
            builder.RegisterType<EfRepository<DakBacaiKaranList>>().As<IRepository<DakBacaiKaranList>>();
            builder.RegisterType<EfRepository<DakBacaiKaran>>().As<IRepository<DakBacaiKaran>>();
            

            builder.RegisterType<EfRepository<EmployeeInfo>>().As<IRepository<EmployeeInfo>>();
            builder.RegisterType<EfRepository<OfficeInfo>>().As<IRepository<OfficeInfo>>();
            builder.RegisterType<EfRepository<UserToken>>().As<IRepository<UserToken>>();
            builder.RegisterType<EfRepository<NothiListRecords>>().As<IRepository<NothiListRecords>>();
            builder.RegisterType<AccountService>().As<IAccountService>();
            builder.RegisterType<DakOutboxService>().As<IDakOutboxService>();
            builder.RegisterType<SyncerService>().As<ISyncerService>();
            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<DakInboxService>().As<IDakInboxServices>();
            builder.RegisterType<DakFolderService>().As<IDakFolderService>();
            builder.RegisterType<DakOutboxService>().As<IDakOutboxService>();
            builder.RegisterType<DakListService>().As<IDakListService>();
            builder.RegisterType<DesignationSealService>().As<IDesignationSealService>();
            builder.RegisterType<DakUploadService>().As<IDakUploadService>();
            builder.RegisterType<DakForwardService>().As<IDakForwardService>();
            builder.RegisterType<DakNothijatoService>().As<IDakNothijatoService>();
            builder.RegisterType<DakNothivuktoService>().As<IDakNothivuktoService>();
            builder.RegisterType<DakArchiveService>().As<IDakArchiveService>();
            builder.RegisterType<DakKhosraService>().As<IDakKhosraService>();
            builder.RegisterType<DakListSortedService>().As<IDakListSortedService>();
            builder.RegisterType<NothiCreateService>().As<INothiCreateService>();
            builder.RegisterType<NothiInboxService>().As<INothiInboxServices>();
            builder.RegisterType<NothiInboxNoteServices>().As<INothiInboxNoteServices>();
            builder.RegisterType<NothiOutboxNoteServices>().As<INothiOutboxNoteServices>();
            builder.RegisterType<NothiAllNoteServices>().As<INothiAllNoteServices>();
            builder.RegisterType<NothiOutboxService>().As<INothiOutboxServices>();
            builder.RegisterType<NothiNoteTalikaServices>().As<INothiNoteTalikaServices>();
            builder.RegisterType<NothiAllService>().As<INothiAllServices>();
            builder.RegisterType<NothiTypeListService>().As<INothiTypeListServices>();
            builder.RegisterType<NothiNotePermissionService>().As<INothiNotePermissionService>();
            builder.RegisterType<NoteSaveService>().As<INoteSaveService>();
            builder.RegisterType<OnuchhedSave>().As<IOnucchedSave>();
            builder.RegisterType<NothiTypeSaveService>().As<INothiTypeSaveService>();
            builder.RegisterType<DakSearchService>().As<IDakSearchService>();
            builder.RegisterType<NoteDeleteService>().As<INoteDeleteService>();
            builder.RegisterType<UserMessageParser>().As<IUserMessageParser>();
            builder.RegisterType<NoteListParser>().As<INoteListParser>();
            builder.RegisterType<AutofacFormFactory>().As<IFormFactory>();
            builder.RegisterType<AutofacUserControlFactory>().As<IUserControlFactory>();
            builder.RegisterType<OnumodonService>().As<IOnumodonService>();
            builder.RegisterType<OnuchhedForwardService>().As<IOnuchhedForwardService>();
            builder.RegisterType<OnucchedDelete>().As<IOnucchedDelete>();
            builder.RegisterType<NothiPotrangshoServices>().As<INothiPotrangshoServices>();
            builder.RegisterType<AllPotroServices>().As<IAllPotroServices>();
            builder.RegisterType<KhoshraPotroServices>().As<IKhoshraPotroServices>();
            builder.RegisterType<NothivuktoPotroServices>().As<INothivuktoPotroServices>();
            builder.RegisterType<KhoshraPotroWaitingServices>().As<IKhoshraPotroWaitingServices>();
            builder.RegisterType<PotrojariServices>().As<IPotrojariServices>();
            builder.RegisterType<NothijatoServices>().As<INothijatoServices>();
            builder.RegisterType<NotePotrojariServices>().As<INotePotrojariServices>();
            builder.RegisterType<NoteKhshraWaitingListServices>().As<INoteKhshraWaitingListServices>();
            builder.RegisterType<NoteKhoshraListServices>().As<INoteKhoshraListServices>();
            builder.RegisterType<OnuchhedListServices>().As<IOnuchhedListServices>();
            builder.RegisterType<SingleOnucchedServices>().As<ISingleOnucchedServices>();
            builder.RegisterType<NoteOnucchedRevertServices>().As<INoteOnucchedRevertServices>();
            builder.RegisterType<OnucchedFileUploadService>().As<IOnucchedFileUploadService>();
            builder.RegisterType<NothiDecisionListService>().As<INothiDecisionListService>();

            builder.RegisterType<AllPotroParser>().As<IAllPotroParser>();
            builder.RegisterType<NothivuktoPotroParser>().As<INothivuktoPotroParser>();
            builder.RegisterType<KhasraTemplateService>().As<IKhasraTemplateService>();
            builder.RegisterType<PotrojariParser>().As<IPotrojariParser>();
            builder.RegisterType<RegisterService>().As<IRegisterService>();
            builder.RegisterType<ProtibedonService>().As<IProtibedonService>();
            builder.RegisterType<PotrojariServices>().As<IPotrojariServices>();
            builder.RegisterType<KhosraSaveService>().As<IKhosraSaveService>();
            builder.RegisterType<PotroJariGroupService>().As<IPotroJariGroupService>();
           
            builder.RegisterGeneric(typeof(GuardFileService<,>)).As(typeof(IGuardFileService<,>)).AsSelf();
            builder.RegisterGeneric(typeof(DakSharingService<>)).As(typeof(IDakSharingService<>)).AsSelf();



            builder.RegisterType<UI.Login>().AsSelf().InstancePerLifetimeScope();

            builder.RegisterType<UI.Nothi>().AsSelf();
            builder.RegisterType<UI.KhosraDashboard>().AsSelf();
            builder.RegisterType<UI.PotrojariGroup>().AsSelf();
            builder.RegisterType<PotrojariGroupForm>().AsSelf();
            
            builder.RegisterType<UI.ReviewDashBoard>().AsSelf();
            builder.RegisterType<UI.RvwDashContentShowInEditor>().AsSelf();
            builder.RegisterType<UI.Khosra>().AsSelf();
            builder.RegisterType<UI.Dak.DakBoxSharingForm>().AsSelf();
            builder.RegisterType<UI.Note>().AsSelf();
            builder.RegisterType<DakModuleSokolNothiListUserControl>().AsSelf();
            builder.RegisterType<UI.Dak.CreateNewNotes>().AsSelf();
            builder.RegisterType<UI.Dak.FileUserControl>().AsSelf();
            builder.RegisterType<NothiAll>().AsSelf();
            builder.RegisterType<UI.NothiCreateNextStep>().AsSelf();

            builder.RegisterType<UI.Dak.DakNothiteUposthapitoForm>().AsSelf();
            builder.RegisterType<NothiLevelAddForm>().AsSelf();
            builder.RegisterType<UI.Dak.DakFolderForm>().AsSelf();
            builder.RegisterType<UI.Dak.DakTagForm>().AsSelf();
            builder.RegisterType<UI.Dak.FolderCreatePopUpForm>().AsSelf();
            builder.RegisterType<UI.Dak.AddDesignationSeal>().AsSelf();
            builder.RegisterType<UI.Dak.NothiOnumodonDesignationSeal>().AsSelf();
            builder.RegisterType<UI.Dak.NothiNextStep>().AsSelf();
            builder.RegisterType<UI.Dak.SeparateOnuchhed>().AsSelf();
            builder.RegisterType<UI.Dak.OnucchedSignature>().AsSelf();
            builder.RegisterType<UI.Dak.NothiGuidelines>().AsSelf();
            builder.RegisterType<UI.Dak.NewNothiTypeGuidelines>().AsSelf();
            builder.RegisterType<UI.Dashboard>().AsSelf();
            builder.RegisterType<NothiType>().AsSelf();
            builder.RegisterType<NothiNoteShomuho>().AsSelf();
            builder.RegisterType<NothiOutboxNoteShomuho>().AsSelf();
            builder.RegisterType<NothiInbox>().AsSelf();
            builder.RegisterType<NothiOutbox>().AsSelf();
            builder.RegisterType<DakDecisionTableUserControl>().AsSelf();
            builder.RegisterType<NewNothi>().AsSelf();
            builder.RegisterType<FolderCreatePopUpForm>().AsSelf();
            builder.RegisterType<NothiTypeList>().AsSelf();
            builder.RegisterType<CreateNewNothiType>().AsSelf();
            builder.RegisterType<NothiDecisionListRow>().AsSelf();
            builder.RegisterType<NothiDecisionList>().AsSelf();
            builder.RegisterType<DakForwardUserControl>().AsSelf();
            builder.RegisterType<DakNothijatoForm>().AsSelf();
            builder.RegisterType<DakModuleAgotoNothiList>().AsSelf();
            builder.RegisterType<DakForwardUserControl>().AsSelf();
            builder.RegisterType<GurdFileControl>().AsSelf();
            builder.RegisterType<DakNothiteUposthapitoNewNoteAddUserControl>().AsSelf();
            builder.RegisterType<MultipleDakActionResultForm>().AsSelf();
            builder.RegisterType<MultipleDakSelectedListConfirmForm>().AsSelf();
           
            builder.RegisterType<CreateGuardFileTypeForm>().AsSelf();
            builder.RegisterType<GurdFileControl>().AsSelf();
            builder.RegisterType<UI.OtherModule.GuardFileUserControls.UCGuardFileTypes>().AsSelf();
            builder.RegisterType<UI.OtherModule.GuardFileUserControls.UCGuardFileList>().AsSelf();
            builder.RegisterType<UI.OtherModule.GuardFileUserControls.UCGuardFileUpload>().AsSelf();
            builder.RegisterType<UI.OtherModule.GuardFileUserControls.GuardFileTypeTableUserControl>().AsSelf();
            builder.RegisterType<UI.OtherModule.GuardFileUserControls.GuarFileListViewDeleteUC>().AsSelf();
            builder.RegisterType<UI.OtherModule.GuardFileUserControls.GuardFileBrowseUC>().AsSelf();
            builder.RegisterType<GuardFileRowUserControl>().AsSelf();
            
            builder.RegisterType<GuardFileListRowUserControl>().AsSelf();
            builder.RegisterType<PotrojariGroupContent>().AsSelf();
            

            builder.RegisterGeneric(typeof(GuardFileService<,>)).As(typeof(IGuardFileService<,>)).AsSelf();

           
            container = (builder.Build());
            FormFactory.Use(container.Resolve<IFormFactory>());
            UserControlFactory.Use(container.Resolve<IUserControlFactory>());
        }
    }
}
