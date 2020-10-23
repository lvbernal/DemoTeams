using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CaliSharp.Demo.Notifiers;
using CaliSharp.Demo.Spec;

[assembly: FunctionsStartup(typeof(CaliSharp.Demo.Startup))]

namespace CaliSharp.Demo
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddOptions<Options>()
                .Configure<IConfiguration>(
                    (settings, configuration) => { configuration.Bind(settings); }
                );

            builder.Services.AddHttpClient();

            builder.Services.AddScoped<ITeamsNotifier, TeamsNotifier>();
        }
    }
}
