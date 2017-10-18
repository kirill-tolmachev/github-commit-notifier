using System.Web.Http;
using System.Web.Http.Tracing;
using Microsoft.AspNet.WebHooks;
using Microsoft.AspNet.WebHooks.Controllers;

namespace GithubNotifier
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var controllerType = typeof(WebHookReceiversController);

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            
            config.InitializeReceiveGitHubWebHooks();
        }
    }


}