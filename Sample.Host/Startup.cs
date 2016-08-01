using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Sample.Host.Startup))]
namespace Sample.Host
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var contextA = new ContextA.Startup();
            var contextB = new ContextB.Startup();

            app.Map("/context-a", contextA.Configuration);
            app.Map("/context-b", contextB.Configuration);
        }
    }
}
