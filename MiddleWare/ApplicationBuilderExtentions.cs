using Microsoft.Extensions.FileProviders;
using System.IO;


namespace Microsoft.AspNetCore.Builder
{
    public static class ApplicationBuilderExtentions
    {
        public static IApplicationBuilder UseNodeModules(this IApplicationBuilder app,string rootPath)
        {
            var path = Path.Combine(rootPath, "node_modules");
            var fileProvider = new PhysicalFileProvider(path);
            var options = new StaticFileOptions()
            {
                RequestPath = "/node_modules",
                FileProvider = fileProvider
            };
            app.UseStaticFiles(options);
            return app;
        }
    }
}
