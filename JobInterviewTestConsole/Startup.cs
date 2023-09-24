using JobInterviewTestConsole.Commands;
using JobInterviewTestConsole.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace JobInterviewTestConsole;

internal class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        RegisterCommands(services);
        services.AddTransient<IApplicationRunner, ApplicationRunner>();
        services.AddSingleton<ITransactionRepository, TransactionRepository>();
    }

    private static void RegisterCommands(IServiceCollection services)
    {
        services.AddTransient<ICommand, AddCommand>();
        services.AddTransient<ICommand, GetCommand>();
        services.AddTransient<ICommand, ExitCommand>();
    }
}
