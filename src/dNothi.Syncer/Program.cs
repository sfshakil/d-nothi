using dNothi.Services.DakServices;
using dNothi.Services.UserServices;
using Autofac;
using dNothi.Infrastructure;
using dNothi.Core.Entities;
using dNothi.Core.Interfaces;
using dNothi.Services.AccountServices;
using dNothi.Services.NothiServices;
using dNothi.JsonParser;
using dNothi.Services.SyncServices;
using System;
using System.Threading.Tasks;

namespace dNothi.Syncer
{
    class Program
    {
        private static IContainer container;
        private static readonly log4net.ILog _log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        static async Task Main(string[] args)
        {
            Console.WriteLine("----------------Begin-------------------");
            log4net.Config.XmlConfigurator.Configure();
            _log.Info("Application Stated!");
            var container=Bootstrap();
            try 
            {
                using (var scope = container.BeginLifetimeScope())
                {
                    var svc = scope.Resolve<ISyncerService>();
                    var data = await svc.GetSource();
                    var dbdata = svc.GetDestination();
                    Console.WriteLine("Dak Ids From API");
                    Console.WriteLine(string.Join(",", data.ToArray()));
                    Console.WriteLine("Dak Ids In Database");
                    Console.WriteLine(string.Join(",", dbdata.ToArray()));
                }
            } 
            catch(Exception ex)
            {
                _log.Error(ex.ToString());
            }
            Console.WriteLine("----------------END-------------------");
            Console.ReadLine();


        }
        private static IContainer Bootstrap()
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
            builder.RegisterType<DakNothijatoService>().As<IDakNothijatoService>();
            builder.RegisterType<DakNothivuktoService>().As<IDakNothivuktoService>();
            builder.RegisterType<DakArchiveService>().As<IDakArchiveService>();
            builder.RegisterType<NothiInboxService>().As<INothiInboxServices>();
            builder.RegisterType<NothiOutboxService>().As<INothiOutboxServices>();
            builder.RegisterType<NothiAllService>().As<INothiAllServices>();
            builder.RegisterType<NothiTypeListService>().As<INothiTypeListServices>();
            builder.RegisterType<UserMessageParser>().As<IUserMessageParser>();
            builder.RegisterType<SyncerService>().As<ISyncerService>();

            container = (builder.Build());
            return container;
        }
        
    }
}
