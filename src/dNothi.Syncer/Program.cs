using dNothi.Constants;
using dNothi.Services.DakServices;
using dNothi.Services.UserServices;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Core;
using dNothi.Infrastructure;
using dNothi.Core.Entities;
using dNothi.Core.Interfaces;
using dNothi.Services.AccountServices;
using dNothi.Services.NothiServices;
using dNothi.JsonParser;

namespace dNothi.Syncer
{
    class Program
    {
        private static IContainer container;
        private static readonly log4net.ILog _log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        static void Main(string[] args)
        {
            log4net.Config.XmlConfigurator.Configure();
            _log.Info("Application Stated!");
            Bootstrap();
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
            builder.RegisterType<DakNothijatoService>().As<IDakNothijatoService>();
            builder.RegisterType<DakNothivuktoService>().As<IDakNothivuktoService>();
            builder.RegisterType<DakArchiveService>().As<IDakArchiveService>();
            builder.RegisterType<NothiInboxService>().As<INothiInboxServices>();
            builder.RegisterType<NothiOutboxService>().As<INothiOutboxServices>();
            builder.RegisterType<NothiAllService>().As<INothiAllServices>();
            builder.RegisterType<NothiTypeListService>().As<INothiTypeListServices>();
            builder.RegisterType<UserMessageParser>().As<IUserMessageParser>();

            container = (builder.Build());
        }
        public static List<long> GetSource()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    //var url = GetAPIDomain() + GetLoginEndpoint();
                    //var json = JsonConvert.SerializeObject(userParam);
                    //var data = new StringContent(json, Encoding.UTF8, "application/json");
                    //client.DefaultRequestHeaders.Add("api-version", GetAPIVersion());
                    //client.DefaultRequestHeaders.Add("device-id", GetDeviceId());
                    //client.DefaultRequestHeaders.Add("device-type", GetDeviceType());
                    //var response = await client.PostAsync(url, data);
                    //string result = await response.Content.ReadAsStringAsync();
                    //UserMessage responsemessage = _userMessageParser.ParseMessage(result);
                    //return responsemessage;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return null;
        }
        protected static string GetAPIDomain()
        {
            return ReadAppSettings("api-endpoint") ?? DefaultAPIConfiguration.DefaultAPIDomainAddress;
        }
        protected static string GetLoginEndpoint()
        {
            return DefaultAPIConfiguration.LoginEndPoint;
        }
        protected static string GetAPIVersion()
        {
            return ReadAppSettings("api-version") ?? DefaultAPIConfiguration.DefaultAPIversion;
        }

        protected static string GetDeviceId()
        {
            return ReadAppSettings("device-id") ?? DefaultAPIConfiguration.DefaultDeviceId;
        }
        protected static string GetDeviceType()
        {
            return ReadAppSettings("device-type") ?? DefaultAPIConfiguration.DefaultDeviceType;
        }

        protected static string ReadAppSettings(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}
