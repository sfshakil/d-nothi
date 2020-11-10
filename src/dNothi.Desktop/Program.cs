﻿using Autofac;
using Autofac.Core;
using AutoMapper;
using dNothi.Core.Entities;
using dNothi.Core.Interfaces;
using dNothi.Desktop.Interfaces;
using dNothi.Infrastructure;
using dNothi.JsonParser;
using dNothi.Services.AccountServices;
using dNothi.Services.UserServices;

using Nothi.Services.DakServices;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            //using (var scope = container.BeginLifetimeScope())
            //{
            //    var main = scope.Resolve<UI.Login>();
            //    Application.Run(main);
            //}
        }
        private static void Bootstrap()
        {
            var builder = new ContainerBuilder();

            // Usually you're only interested in exposing the type
            // via its interface:
            builder.RegisterType<AppDbContext>().As<IDbContext>();
            builder.RegisterType<EfRepository<AppUser>>().As<IRepository<AppUser>>();
            builder.RegisterType<EfRepository<User>>().As<IRepository<User>>();
            builder.RegisterType<EfRepository<Nothi.Core.Entities.DakTag>>().As<IRepository<Nothi.Core.Entities.DakTag>>();
            builder.RegisterType<EfRepository<Nothi.Core.Entities.DakUser>>().As<IRepository<Nothi.Core.Entities.DakUser>>();
            builder.RegisterType<EfRepository<EmployeeInfo>>().As<IRepository<EmployeeInfo>>();
            builder.RegisterType<AccountService>().As<IAccountService>();
            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<DakInboxListService>().As<IDakInboxLIstServices>();
        
            builder.RegisterType<UserMessageParser>().As<IUserMessageParser>();
            builder.RegisterType<AutofacFormFactory>().As<IFormFactory>();

            builder.RegisterType<UI.Login>().AsSelf();
            builder.RegisterType<UI.Nothi>().AsSelf();
            //builder.RegisterType<NothiListForm>().AsSelf();
            builder.RegisterType<Dashboard>().AsSelf();
            container = (builder.Build());
            FormFactory.Use(container.Resolve<IFormFactory>());
        }
    }
}
