using System.Threading.Tasks;
using Microsoft.AspNet.WebHooks;

namespace GithubNotifier.Core
{
    public interface INotifier
    {
        Task Notify(GithubPayload payload);
    }

}