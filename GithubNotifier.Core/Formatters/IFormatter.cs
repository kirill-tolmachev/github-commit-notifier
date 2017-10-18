namespace GithubNotifier.Core.Formatters
{
    public interface IFormatter
    {
        string Format(GithubPayload payload);
    }
}