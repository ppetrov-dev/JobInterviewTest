using Microsoft.Extensions.DependencyInjection;

namespace JobInterviewTestConsole;

internal class Program
{
    static void Main(string[] args)
    {
        var serviceProvider = BuildServiceProvider();

        var runner = serviceProvider.GetRequiredService<IApplicationRunner>();
        runner.Run();
    }

    private static ServiceProvider BuildServiceProvider()
    {
        var services = new ServiceCollection();
        var startup = new Startup();
        startup.ConfigureServices(services);
        return services.BuildServiceProvider();
    }
}
