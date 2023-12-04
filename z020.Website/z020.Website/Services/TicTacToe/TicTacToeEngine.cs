namespace z020.Website.Services.TicTacToe;

using System.Collections.Concurrent;

public class TicTacToeEngine(ILogger<TicTacToeEngine> logger)
{
    private readonly ConcurrentDictionary<string, TicTacToeBoard> boards = new();
    private readonly ILogger<TicTacToeEngine> logger = logger;

    /// <summary>
    /// Add a new board.
    /// </summary>
    /// <param name="name">The name for the new board.</param>
    /// <param name="piece">What piece the first player will be using.</param>
    /// <param name="playerId">The first player ID.</param>
    /// <returns>True if successful in creating a new board.</returns>
    public bool AddBoard(string name, Pieces piece, string playerId)
    {
        if (string.IsNullOrEmpty(name) || playerId == null)
        {
            logger.LogWarning("{func}({name}={nameValue}, {piece}, {playerId}) A parameter is Null or empty.", nameof(AddBoard), nameof(name), name, piece, playerId);
            return false;
        }

        TicTacToeBoard board = new(name);

        if (!boards.TryAdd(name, board)) return false;

        switch (piece)
        {
            case Pieces.X:
                board.PlayerX = playerId;
                break;

            case Pieces.O:
                board.PlayerO = playerId;
                break;
        }

        return true;
    }

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
    public IEnumerable<string> UsersBoardNames(string playerId)
    {
        logger.LogDebug("playerId={playerId}, boards={boards} ~ {class}.{func}", playerId, boards.Count, nameof(TicTacToeEngine), nameof(UsersBoardNames));

        return boards.Values
            .Where(b => b.PlayerX == playerId || b.PlayerO == playerId)
            .Select(b => b.Name)
            .OrderBy(b => b)
            .ToList();
    }
}