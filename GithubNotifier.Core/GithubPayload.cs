using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GithubNotifier.Core
{
    public class Repository
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("fullname")]
        public string FullName { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }
    }

    public class GithubPayload
    {
        [JsonProperty("repository")]
        public Repository Repository { get; set; }
    }
}
