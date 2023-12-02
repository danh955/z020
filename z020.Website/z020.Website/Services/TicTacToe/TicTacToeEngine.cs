namespace z020.Website.Services.TicTacToe;

using System.Collections.Concurrent;

public class TicTacToeEngine(ILogger<TicTacToeEngine> logger)
{
    private readonly ILogger<TicTacToeEngine> logger = logger ?? throw new ArgumentNullException(nameof(logger));
    private readonly ConcurrentDictionary<string, TicTacToeBoard> boards = new();

    /// <summary>
    /// Get a board to play the game on.
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public TicTacToeBoard? GetBoard(string name)
    {
        return boards.TryGetValue(name, out TicTacToeBoard? value) ? value : null;
    }

    /// <summary>
    /// Get the board names for the current user.
    /// </summary>
    /// <param name="userId">The user ID of the boards to list.</param>
    /// <returns></returns>
    public IEnumerable<string> UsersBoardNames(TicTacToePlayer player)
    {
        return boards.Values
            .Where(b => b.PlayerX == player || b.PlayerO == player)
            .Select(b => b.Name)
            .ToList();
    }

    /// <summary>
    /// Add a new board.
    /// </summary>
    /// <param name="name">The name for the new board.</param>
    /// <param name="piece">What piece the first player will be using.</param>
    /// <param name="player">The first player.</param>
    /// <returns>True if successful in creating a new board.</returns>
    public bool AddBoard(string name, Pieces piece, TicTacToePlayer player)
    {
        if (string.IsNullOrEmpty(name) || player == null)
        {
            logger.LogWarning("{func}({name}={nameValue}, {piece}, {player}) A parameter is Null or empty.", nameof(AddBoard), nameof(name), name, piece, player);
            return false;
        }

        TicTacToeBoard board = new(name);

        if (!boards.TryAdd(name, board)) return false;

        switch (piece)
        {
            case Pieces.X:
                board.PlayerX = player;
                break;

            case Pieces.O:
                board.PlayerO = player;
                break;
        }

        return true;
    }
}