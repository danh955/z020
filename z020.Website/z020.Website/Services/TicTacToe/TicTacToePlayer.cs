namespace z020.Website.Services.TicTacToe;

public class TicTacToePlayer(string userId, string name)
{
    /// <summary>
    /// The name of the user.  Only for display.
    /// </summary>
    public string Name { get; set; } = name;

    /// <summary>
    /// A unique user ID.
    /// </summary>
    public string UserId { get; init; } = userId;

    public override string ToString()
    {
        return $"{{'{this.UserId}', '{this.Name}'}}";
    }
}