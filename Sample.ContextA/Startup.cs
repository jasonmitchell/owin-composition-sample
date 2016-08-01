using System;
using System.Reflection;
using Microsoft.Owin;
using Microsoft.Owin.FileSystems;
using Microsoft.Owin.StaticFiles;
using Owin;
using AppFunc = System.Func<System.Collections.Generic.IDictionary<string, object>, System.Threading.Tasks.Task>;

namespace Sample.ContextA
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var x = Assembly.GetExecutingAssembly();
            var physicalFileSystem = new PhysicalFileSystem("../Sample.ContextA/Web");
            var options = new FileServerOptions
            {
                EnableDefaultFiles = true,
                FileSystem = physicalFileSystem,
                StaticFileOptions =
                {
                    FileSystem = physicalFileSystem,
                    ServeUnknownFileTypes = true
                },
                DefaultFilesOptions =
                {
                    DefaultFileNames = new[] { "index.html" }
                }
            };

            app.UseFileServer(options);

            app.Use(new Func<AppFunc, AppFunc>(next => (async env =>
            {
                var context = new OwinContext(env);
                await context.Response.WriteAsync("Hello, ContextA");
            })));
        }
    }
}
