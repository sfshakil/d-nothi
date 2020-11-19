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

namespace dNothi.Desktop
{
    static class Program
    {
        private static IContainer container;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
           // AppDomain.CurrentDomain.SetData("DataDirectory", Directory.GetCurrentDirectory());
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Database.SetInitializer<AppDbContext>(new DropCreateDatabaseIfModelChanges<AppDbContext>());
            Bootstrap();
            Application.Run(container.Resolve<UI.Login>());
        }
        private static void Bootstrap()
        {
            var builder = new ContainerBuilder();

            // Usually you're only interested in exposing the type
            // via its interface:
            builder.RegisterType<AppDbContext>().As<IDbContext>();
            builder.RegisterType<EfRepository<AppUser>>().As<IRepository<AppUser>>();
            builder.RegisterType<EfRepository<User>>().As<IRepository<User>>();
            builder.RegisterType<EfRepository<dNothi.Core.Entities.DakArchive>>().As<IRepository<dNothi.Core.Entities.DakArchive>>();
            builder.RegisterType<EfRepository<dNothi.Core.Entities.DakNothijato>>().As<IRepository<dNothi.Core.Entities.DakNothijato>>();
            builder.RegisterType<EfRepository<dNothi.Core.Entities.DakNothivukto>>().As<IRepository<dNothi.Core.Entities.DakNothivukto>>();
            builder.RegisterType<EfRepository<dNothi.Core.Entities.DakTag>>().As<IRepository<dNothi.Core.Entities.DakTag>>();
            builder.RegisterType<EfRepository<dNothi.Core.Entities.DakOutbox>>().As<IRepository<dNothi.Core.Entities.DakOutbox>>();
            builder.RegisterType<EfRepository<dNothi.Core.Entities.DakInbox>>().As<IRepository<dNothi.Core.Entities.DakInbox>>();
            builder.RegisterType<EfRepository<dNothi.Core.Entities.DakList>>().As<IRepository<dNothi.Core.Entities.DakList>>();
            builder.RegisterType<EfRepository<dNothi.Core.Entities.DakListDakListRecord>>().As<IRepository<dNothi.Core.Entities.DakListDakListRecord>>();
            builder.RegisterType<EfRepository<dNothi.Core.Entities.DakListRecord>>().As<IRepository<dNothi.Core.Entities.DakListRecord>>();
            builder.RegisterType<EfRepository<dNothi.Core.Entities.DakListRecordDakTag>>().As<IRepository<dNothi.Core.Entities.DakListRecordDakTag>>();
            builder.RegisterType<EfRepository<dNothi.Core.Entities.From>>().As<IRepository<dNothi.Core.Entities.From>>();
            builder.RegisterType<EfRepository<dNothi.Core.Entities.To>>().As<IRepository<dNothi.Core.Entities.To>>();
            builder.RegisterType<EfRepository<dNothi.Core.Entities.Other>>().As<IRepository<dNothi.Core.Entities.Other>>();
            builder.RegisterType<EfRepository<dNothi.Core.Entities.Other>>().As<IRepository<dNothi.Core.Entities.Other>>();
            builder.RegisterType<EfRepository<dNothi.Core.Entities.MovementStatus>>().As<IRepository<dNothi.Core.Entities.MovementStatus>>();
            builder.RegisterType<EfRepository<dNothi.Core.Entities.MovementStatusTo>>().As<IRepository<dNothi.Core.Entities.MovementStatusTo>>();
            builder.RegisterType<EfRepository<dNothi.Core.Entities.DakNothi>>().As<IRepository<dNothi.Core.Entities.DakNothi>>();
            builder.RegisterType<EfRepository<dNothi.Core.Entities.DakUser>>().As<IRepository<dNothi.Core.Entities.DakUser>>();
            builder.RegisterType<EfRepository<dNothi.Core.Entities.DakInbox>>().As<IRepository<dNothi.Core.Entities.DakInbox>>();
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
            builder.RegisterType<DakNothijatoService>().As<IDakNothijatoService>();
            builder.RegisterType<DakNothivuktoService>().As<IDakNothivuktoService>();
            builder.RegisterType<DakListArchiveService>().As<IDakListArchiveService>();
            builder.RegisterType<NothiInboxService>().As<INothiInboxServices>();
            builder.RegisterType<NothiOutboxService>().As<INothiOutboxServices>();
            builder.RegisterType<NothiAllService>().As<INothiAllServices>();
            
            builder.RegisterType<UserMessageParser>().As<IUserMessageParser>();
            builder.RegisterType<AutofacFormFactory>().As<IFormFactory>();

            builder.RegisterType<UI.Login>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<UI.Nothi>().AsSelf();
            builder.RegisterType<UI.Dashboard>().AsSelf();
            container = (builder.Build());
            FormFactory.Use(container.Resolve<IFormFactory>());
        }
    }
}
