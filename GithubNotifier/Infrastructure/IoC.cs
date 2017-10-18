using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;
using System.Web.Http;
using System.Web.Http.Controllers;
using Autofac;
using GithubNotifier.Core;
using GithubNotifier.WebHooks;
using LiteDB;
using Microsoft.AspNet.WebHooks;
using Microsoft.AspNet.WebHooks.Config;
using Microsoft.AspNet.WebHooks.Diagnostics;
using Microsoft.AspNet.WebHooks.Services;
using Newtonsoft.Json.Linq;
using TraceLevel = System.Web.Http.Tracing.TraceLevel;

namespace GithubNotifier.Infrastructure
{
    public class IoC : Module
    {
        private class Logger : ILogger
        {
            public void Log(TraceLevel level, string message, Exception ex)
            {
                Debug.WriteLine($"Log: {level.ToString()} - {message} - {ex?.Message}");
            }
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<NotificationWebHookHandler>().As<IWebHookHandler>().InstancePerDependency();
            builder.RegisterType<DefaultNotifierProvider>().As<INotifierProvider>().SingleInstance();
            builder.Register(ctx => CommonServices.GetSettings()).As<SettingsDictionary>();
            builder.RegisterType<Logger>().As<ILogger>().SingleInstance();

            builder.RegisterInstance(new LiteDatabase(HostingEnvironment.MapPath(@"~/App_Data/users.ldb"))).As<LiteDatabase>().SingleInstance();
        }
    }
    
}