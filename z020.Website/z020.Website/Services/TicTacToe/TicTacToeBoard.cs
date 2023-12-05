namespace z020.Website.Services.TicTacToe;

public class TicTacToeBoard
{
    public TicTacToeBoard(string boardName)
    {
        BoardName = boardName;
        Square = new Pieces[9];
        ClearBoard();
    }

    public event Action? OnBoardChanged;

    /// <summary>
    /// Name of the board.
    /// </summary>
    public string BoardName { get; init; }

    /// <summary>
    /// Player O.
    /// </summary>
    public string PlayerOId { get; set; } = string.Empty;

    public string PlayerOName { get; set; } = string.Empty;

    /// <summary>
    /// Player X.
    /// </summary>
    public string PlayerXId { get; set; } = string.Empty;

    public string PlayerXName { get; set; } = string.Empty;

    /// <summary>
    /// Squares on the board.
    /// </summary>
    public Pieces[] Square { get; init; }

    public void ClearBoard()
    {
        for (int idx = 0; idx < Square.Length; idx++)
        {
            Square[idx] = Pieces.Empty;
        }

        OnBoardChanged?.Invoke();
    }

    /// <summary>
    /// Set the player piece on the board.
    /// </summary>
    /// <param name="idx">Location on the board.</param>
    /// <param name="player">The player.</param>
    /// <returns>True if player piece was set on the board.</returns>
    public bool SetPayerPiece(int idx, string playerId)
    {
        ////TODO: remove comment
        ////if (string.IsNullOrWhiteSpace(PlayerXId) || string.IsNullOrWhiteSpace(PlayerOId))
        ////{
        ////    return false;
        ////}

        Pieces piece = playerId switch
        {
            var px when px == PlayerXId => Pieces.X,
            var py when py == PlayerOId => Pieces.O,
            _ => Pieces.Empty,
        };

        if (Square[idx] != Pieces.Empty)
        {
            return false;
        }

        Square[idx] = piece;
        OnBoardChanged?.Invoke();
        return true;
    }
}