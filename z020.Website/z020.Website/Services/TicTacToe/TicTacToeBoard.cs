namespace z020.Website.Services.TicTacToe;

public class TicTacToeBoard
{
    public TicTacToeBoard(string name)
    {
        Name = name;
        Square = new Pieces[9];
        ClearBoard();
    }

    /// <summary>
    /// Name of the board.
    /// </summary>
    public string Name { get; init; }

    /// <summary>
    /// Squares on the board.
    /// </summary>
    public Pieces[] Square { get; init; }

    /// <summary>
    /// Player X.
    /// </summary>
    public string PlayerX { get; set; } = string.Empty;

    /// <summary>
    /// Player O.
    /// </summary>
    public string PlayerO { get; set; } = string.Empty;

    /// <summary>
    /// Set the player piece on the board.
    /// </summary>
    /// <param name="idx">Location on the board.</param>
    /// <param name="player">The player.</param>
    /// <returns>True if player piece was set on the board.</returns>
    public bool SetPayerPiece(int idx, string playerId)
    {
        ////TODO: remove comment
        ////if (string.IsNullOrWhiteSpace(PlayerX) || string.IsNullOrWhiteSpace(PlayerO))
        ////{
        ////    return false;
        ////}

        Pieces piece = playerId switch
        {
            var px when px == PlayerX => Pieces.X,
            var py when py == PlayerO => Pieces.O,
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

    public void ClearBoard()
    {
        for (int idx = 0; idx < Square.Length; idx++)
        {
            Square[idx] = Pieces.Empty;
        }

        OnBoardChanged?.Invoke();
    }

    public event Action? OnBoardChanged;
}