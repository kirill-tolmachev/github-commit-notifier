using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GithubNotifier.Core.Formatters
{
    class ShortMessageFormatter : IFormatter
    {
        public string Format(GithubPayload payload)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"New push on {payload.Repository.FullName}");
            sb.AppendLine();
            sb.AppendLine($"{payload.Pusher?.Name} pushed {payload.Commits.Count} commit(s).");
            int commitIndex = 1;
            foreach (var commit in payload.Commits)
            {
                sb.AppendLine(
                    $"{commitIndex++}) author: {commit.Author?.Name}; " +
                    $"added: {commit.AddedFiles.Count}; removed: {commit.RemovedFiles.Count}; modified: {commit.RemovedFiles.Count}.");
            }
            sb.AppendLine();
            sb.AppendLine($"Browse changes here: {payload.DiffUrl}");
            return sb.ToString();
        }

        
    }
}
