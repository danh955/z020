namespace z020.Website.Services.TicTacToe;

public class TicTacToeBoard
{
    public TicTacToeBoard()
    {
        Square = new Pieces[9];
        ClearBoard();
    }

    public string Name { get; set; } = string.Empty;

    public Pieces[] Square { get; init; }

    public TicTacToePlayer? PlayerX { get; set; }

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