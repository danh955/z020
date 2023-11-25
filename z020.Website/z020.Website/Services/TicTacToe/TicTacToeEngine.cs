namespace z020.Website.Services.TicTacToe;

public class TicTacToeEngine
{
    /// <summary>
    /// Get the board names for the current user.
    /// </summary>
    /// <param name="userId">The user ID of the boards to list.</param>
    /// <returns></returns>
    public List<string> UsersBoardNames(string userId)
    {
        return
            [
                "Default"
            ];
    }

    /// <summary>
    /// Get a board to play the game on.
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public TicTacToeBoard GetBoard(string name)
    {
        return new TicTacToeBoard(name);
    }
}