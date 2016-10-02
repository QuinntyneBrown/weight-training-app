using Owin;
using System.Web.Http;
using Microsoft.Owin;
using Unity.WebApi;

[assembly: OwinStartup(typeof(WeightTrainingApp.Web.Startup))]

namespace WeightTrainingApp.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {            
            GlobalConfiguration.Configure(config =>
            {
                config.DependencyResolver = new UnityDependencyResolver(UnityConfiguration.GetContainer());
                WeightTrainingApp.ApiConfiguration.Install(config, app);
            });
        }
    }
}
