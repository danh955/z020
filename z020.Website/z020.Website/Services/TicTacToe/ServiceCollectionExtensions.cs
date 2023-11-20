namespace z020.Website.Services.TicTacToe;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddTicTacToeEngine(this IServiceCollection services)
    {
        services.AddSingleton<TicTacToeEngine>();
        return services;
    }
}