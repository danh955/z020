namespace z020.Website.Services;

using Blazored.LocalStorage;
using Blazored.SessionStorage;
using z020.Website.Services.TicTacToe;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSomeServices(this IServiceCollection services)
    {
        services.AddBlazoredLocalStorage()
                .AddBlazoredSessionStorage()
                .AddScoped<UserService>()
                .AddTicTacToeEngine();

        return services;
    }
}