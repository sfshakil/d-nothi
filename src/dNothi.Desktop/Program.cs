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
         
            using (var form = FormFactory.Create<Login>())
            {
                result=form.ShowDialog();
            }
            if (result == DialogResult.OK)
            {
                Application.Run(container.Resolve<Dashboard>());
            }

            
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
            var logmessage ="Exception: "+ ((Exception)e.ExceptionObject).Message + "Stack Trace: "+((Exception)e.ExceptionObject).StackTrace;
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
           
            builder.RegisterType<EfRepository<dNothi.Core.Entities.DakType>>().As<IRepository<dNothi.Core.Entities.DakType>>();
           
            builder.RegisterType<EfRepository<dNothi.Core.Entities.DakList>>().As<IRepository<dNothi.Core.Entities.DakList>>();
            builder.RegisterType<EfRepository<dNothi.Core.Entities.Officer>>().As<IRepository<dNothi.Core.Entities.Officer>>();
            builder.RegisterType<EfRepository<dNothi.Core.Entities.To>>().As<IRepository<dNothi.Core.Entities.To>>();
            builder.RegisterType<EfRepository<dNothi.Core.Entities.Other>>().As<IRepository<dNothi.Core.Entities.Other>>();
            builder.RegisterType<EfRepository<dNothi.Core.Entities.Other>>().As<IRepository<dNothi.Core.Entities.Other>>();
            builder.RegisterType<EfRepository<dNothi.Core.Entities.MovementStatus>>().As<IRepository<dNothi.Core.Entities.MovementStatus>>();
            builder.RegisterType<EfRepository<dNothi.Core.Entities.DakNothi>>().As<IRepository<dNothi.Core.Entities.DakNothi>>();
            builder.RegisterType<EfRepository<dNothi.Core.Entities.DakUser>>().As<IRepository<dNothi.Core.Entities.DakUser>>();
            builder.RegisterType<EfRepository<dNothi.Core.Entities.DakOrigin>>().As<IRepository<dNothi.Core.Entities.DakOrigin>>();
       
            builder.RegisterType<EfRepository<EmployeeInfo>>().As<IRepository<EmployeeInfo>>();
            builder.RegisterType<EfRepository<OfficeInfo>>().As<IRepository<OfficeInfo>>();
            builder.RegisterType<EfRepository<UserToken>>().As<IRepository<UserToken>>();
            builder.RegisterType<EfRepository<NothiListRecords>>().As<IRepository<NothiListRecords>>();
            builder.RegisterType<AccountService>().As<IAccountService>();
            builder.RegisterType<DakOutboxService>().As<IDakOutboxService>();
            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<DakInboxService>().As<IDakInboxServices>();
            builder.RegisterType<DakOutboxService>().As<IDakOutboxService>();
            builder.RegisterType<DakListService>().As<IDakListService>();
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
            builder.RegisterType<NothiOutboxService>().As<INothiOutboxServices>(); 
            builder.RegisterType<NothiNoteTalikaServices>().As<INothiNoteTalikaServices>();
            builder.RegisterType<NothiAllService>().As<INothiAllServices>();
            builder.RegisterType<NothiTypeListService>().As<INothiTypeListServices>(); 
            builder.RegisterType<NothiNotePermissionService>().As<INothiNotePermissionService>();
            builder.RegisterType<UserMessageParser>().As<IUserMessageParser>();
            builder.RegisterType<AutofacFormFactory>().As<IFormFactory>();
            builder.RegisterType<AutofacUserControlFactory>().As<IUserControlFactory>();

            builder.RegisterType<UI.Login>().AsSelf().InstancePerLifetimeScope();
           
            builder.RegisterType<UI.Nothi>().AsSelf();
            builder.RegisterType<DakModuleSokolNothiListUserControl>().AsSelf();
            builder.RegisterType<UI.NothiOnumodonkari>().AsSelf();
            builder.RegisterType<UI.NothiCreateNextStep>().AsSelf();

            builder.RegisterType<UI.Dak.DakNothiteUposthapitoForm>().AsSelf();
            builder.RegisterType<UI.Dak.AddDesignationSeal>().AsSelf(); 
            builder.RegisterType<UI.Dak.NothiOnumodonDesignationSeal>().AsSelf();
            builder.RegisterType<UI.Dashboard>().AsSelf();
            builder.RegisterType<NothiType>().AsSelf();
            builder.RegisterType<NothiInbox>().AsSelf();
            builder.RegisterType<NewNothi>().AsSelf();
            builder.RegisterType<CreateNewNothiType>().AsSelf();
            builder.RegisterType<DakNothiteUposthapitoNewNoteAddUserControl>().AsSelf();
         

            container = (builder.Build());
            FormFactory.Use(container.Resolve<IFormFactory>());
            UserControlFactory.Use(container.Resolve<IUserControlFactory>());
        }
    }
}
