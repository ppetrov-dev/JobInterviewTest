using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JobInterviewTestConsole;

public static class ServiceCollectionExtensions
{
    private const string ConfigureServicesMethodName = "ConfigureServices";

    public static IServiceCollection UseStartup<TStartup>(this IServiceCollection services, IConfiguration configuration)
        where TStartup : class
    {
        var startupType = typeof(TStartup);
        var cfgServicesMethod = startupType.GetMethod(ConfigureServicesMethodName, new[] { typeof(IServiceCollection) });
        var hasConfigCtor = startupType.GetConstructor(new[] { typeof(IConfiguration) }) != null;
        var startup = hasConfigCtor
            ? (TStartup)Activator.CreateInstance(typeof(TStartup), configuration)
            : (TStartup)Activator.CreateInstance(typeof(TStartup), null);

        cfgServicesMethod?.Invoke(startup, new object[] { services });

        return services;
    }
}
