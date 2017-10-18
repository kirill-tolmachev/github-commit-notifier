using System;
using System.Threading.Tasks;

namespace GithubNotifier.Core.Notifiers
{
    class EmailNotifier : INotifier
    {
        public Task Notify(GithubPayload payload)
        {
            throw new NotImplementedException();
        }
    }
}
