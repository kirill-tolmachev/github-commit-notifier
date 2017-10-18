using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GithubNotifier.Core
{
    public class Person
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }
    }
    public class Commit
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("author")]
        public Person Author { get; set; }

        [JsonProperty("committer")]
        public Person Committer { get; set; }

        [JsonProperty("added")]
        public List<string> AddedFiles { get; set; }

        [JsonProperty("removed")]
        public List<string> RemovedFiles { get; set; }

        [JsonProperty("modified")]
        public List<string> ModifiedFiles { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }

    public class Repository
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("full_name")]
        public string FullName { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }
    }

    public class GithubPayload
    {
        [JsonProperty("repository")]
        public Repository Repository { get; set; }

        [JsonProperty("compare")]
        public string DiffUrl { get; set; }

        [JsonProperty("commits")]
        public List<Commit> Commits { get; set; }

        [JsonProperty("pusher")]
        public Person Pusher { get; set; }
    }
}
