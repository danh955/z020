namespace z020.Website.Services;

using z020.Website.Services.TicTacToe;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSomeServices(this IServiceCollection services)
    {
        services.AddScoped<SessionService>()
                .AddTicTacToeEngine();

        return services;
    }
}