using Autofac;
using GithubNotifier.Core.Formatters;
using GithubNotifier.Core.Notifiers;

namespace GithubNotifier.Core.Infrastructure
{
    public class IoC : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ShortMessageFormatter>().As<IFormatter>().SingleInstance();
            builder.RegisterType<TextFileLogNotifier>().WithParameter("path", "D:\\Projects\\githubcommitnotifier\\log.txt").As<INotifier>();
        }
    }
}