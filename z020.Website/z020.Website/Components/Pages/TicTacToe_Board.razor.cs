namespace z020.Website.Components.Pages;

using Microsoft.AspNetCore.Components;
using z020.Website.Services.TicTacToe;

public partial class TicTacToe_Board : IDisposable
{
    private TicTacToeBoard? board;

    private string? message;

    [Parameter]
    public string? BoardName { get; set; }

    [Inject] public TicTacToeEngine? Ttt { get; set; }

    public void Dispose()
    {
        if (board != null)
        {
            board.OnBoardChanged -= BoardChanged;
        }

        GC.SuppressFinalize(this);
    }

    protected override void OnInitialized()
    {
        base.OnInitialized();

        if (BoardName == null)
        {
            message = $"Board '{BoardName}' not found";
            return;
        }

        board = Ttt?.GetBoard(BoardName);

        if (board != null)
        {
            board.OnBoardChanged += BoardChanged;
            board.PlayerX = new("Mr. X");
            board.PlayerO = new("Mr. O");
        }
    }

    private void BoardChanged() => this.StateHasChanged();

    private void ClearBoard() => board?.ClearBoard();

    private char MarkThisSpot(int idx)
    {
        return board?.Square[idx] switch
        {
            Pieces.X => '\u2715',
            Pieces.O => '\u25EF',
            _ => ' ',
        };
    }

    private void SetPiece(int idx)
    {
        if (board?.PlayerX != null)
        {
            board.SetPayerPiece(idx, board.PlayerX);
        }
    }
}