using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using GithubNotifier.Core;
using GithubNotifier.Infrastructure;
using Microsoft.AspNet.WebHooks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GithubNotifier.WebHooks
{
    public class NotificationWebHookHandler : WebHookHandler
    {
        private readonly INotifierProvider _notifierProvider;

        public NotificationWebHookHandler(INotifierProvider notifierProvider)
        {
            this.Receiver = GitHubWebHookReceiver.ReceiverName;
            Order = 1;
            _notifierProvider = notifierProvider;
        }

        public override Task ExecuteAsync(string receiver, WebHookHandlerContext context)
        {
            GithubPayload payload = GetPayload(context);
            return Task.WhenAll(_notifierProvider.Provide().Select(n => n.Notify(payload)));
        }

        private static GithubPayload GetPayload(WebHookHandlerContext context)
        {
            var json = context.GetDataOrDefault<JObject>();
            return json.ToObject<GithubPayload>();
        }
    }
}