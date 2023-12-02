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
    public TicTacToePlayer? PlayerX { get; set; }

    /// <summary>
    /// Player O.
    /// </summary>
    public TicTacToePlayer? PlayerO { get; set; }

    /// <summary>
    /// Set the player piece on the board.
    /// </summary>
    /// <param name="idx">Location on the board.</param>
    /// <param name="player">The player.</param>
    /// <returns>True if player piece was set on the board.</returns>
    public bool SetPayerPiece(int idx, TicTacToePlayer? player)
    {
        if (player == null) return false;

        //// TODO: remove comment
        ////if (PlayerX == null || PlayerO == null)
        ////{
        ////    return false;
        ////}

        Pieces piece = player switch
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