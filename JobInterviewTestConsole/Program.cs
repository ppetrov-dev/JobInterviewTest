using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JobInterviewTestConsole;

internal class Program
{
    static void Main(string[] args)
    {
        var configuration = new ConfigurationBuilder().Build();
        var serviceProvider = CreateIocContainer(configuration).BuildServiceProvider();
        var runner = serviceProvider.GetRequiredService<IApplicationRunner>();
        runner.Run();
    }

    private static IServiceCollection CreateIocContainer(IConfiguration configuration)
    {
        return new ServiceCollection()
            .UseStartup<Startup>(configuration);
    }
}
