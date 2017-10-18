using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using GithubNotifier.Core;
using LiteDB;
using Telegram.Bot;

namespace GithubNotifier.Telegram.Infrastructure
{
    public class IoC : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TelegramBotClient>().WithParameter("token", ConfigurationManager.AppSettings["telegram-token"]).AsSelf().SingleInstance();
            builder.RegisterType<TelegramNotifier>().As<INotifier>().SingleInstance();
            
            builder.RegisterType<ChatSet>().AsSelf().InstancePerDependency();
        }
    }
}
