using System;
using Microsoft.Owin;
using Owin;
using AppFunc = System.Func<System.Collections.Generic.IDictionary<string, object>, System.Threading.Tasks.Task>;

namespace Sample.ContextA
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.Use(new Func<AppFunc, AppFunc>(next => (async env =>
            {
                var context = new OwinContext(env);
                await context.Response.WriteAsync("Hello, ContextA");
            })));
        }
    }
}
