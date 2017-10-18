using System.Collections.Generic;

namespace GithubNotifier.Core
{
    public interface INotifierProvider
    {
        IList<INotifier> Provide();
    }

    public class DefaultNotifierProvider : INotifierProvider
    {
        public IList<INotifier> Provide()
        {
            return new List<INotifier>()
            {
                new EmailNotifier()
            };
        }
    }
}