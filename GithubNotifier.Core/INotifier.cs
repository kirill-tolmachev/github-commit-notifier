using System.Threading.Tasks;

namespace GithubNotifier.Core
{
    public interface INotifier
    {
        Task Notify(GithubPayload payload);
    }

}