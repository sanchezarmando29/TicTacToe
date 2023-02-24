using Microsoft.Extensions.DependencyInjection;
using TicTacToe;

namespace TicTacToeConsole;

public class Program
{
    
    static void Main(string[] args)
    {
        var services = new ServiceCollection();
        ConfigureServices(services);
        services
            .AddSingleton<GameLoop, GameLoop>()
            .BuildServiceProvider()
            .GetService<GameLoop>()
            .Execute();

    }

    private static void ConfigureServices(IServiceCollection services)
    {
        services
            .AddScoped<ITicTacToe, TicTacToeGame>();
    }
}