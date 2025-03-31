using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace A16TP
{
    public class LocalizationStartupFilter : IStartupFilter
    {
        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
        {
            return app =>
            {
                var options = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
                app.UseRequestLocalization(options.Value);
                next(app);
            };
        }
    }
}