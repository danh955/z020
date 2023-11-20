namespace z020.Website.Services.TicTacToe;

public class TicTacToePlayer
{
    public TicTacToePlayer(string name)
    {
        Name = name;
    }

    public string Name { get; set; } = string.Empty;
}