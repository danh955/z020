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

    public bool SetPayerPiece(int idx, TicTacToePlayer player)
    {
        if (PlayerX == null || PlayerO == null)
        {
            return false;
        }

        Pieces piece = player.Name switch
        {
            var px when px == PlayerX.Name => Pieces.X,
            var py when py == PlayerO.Name => Pieces.X,
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