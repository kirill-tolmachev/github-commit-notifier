using System.Collections.Generic;
using System.Linq;
using Autofac;

namespace GithubNotifier.Core
{
    public interface INotifierProvider
    {
        IEnumerable<INotifier> Provide();
    }

    public class DefaultNotifierProvider : INotifierProvider
    {
        private readonly IEnumerable<INotifier> _notifiers;

        public DefaultNotifierProvider(IEnumerable<INotifier> notifiers)
        {
            _notifiers = notifiers;
        }

        public IEnumerable<INotifier> Provide()
        {
            return _notifiers;
        }
    }
}