namespace z020.Website.Components.TicTacToe;

using System.Xml.Linq;
using Microsoft.AspNetCore.Components;
using z020.Website.Services.TicTacToe;

public partial class TicTacToe_Board : IDisposable
{
    private TicTacToeBoard? board;
    private string? message;

    [Parameter] public required string Name { get; set; }
    [Parameter] public required string PlayerId { get; set; }
    [Inject] public required TicTacToeEngine Engine { get; set; }
    [Inject] public required ILogger<TicTacToe_Board> Logger { get; set; }

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

        if (string.IsNullOrWhiteSpace(Name))
        {
            message = $"Board name must not be empty.";
            return;
        }

        Logger.LogInformation("name={name} ~ {class}.{OnInitialized}", Name, nameof(TicTacToe_Board), nameof(OnInitialized));

        board = Engine.GetBoard(Name);
        if (board == null)
        {
            message = $"Board '{Name}' not found";
            return;
        }

        board.OnBoardChanged += BoardChanged;
    }

    private void BoardChanged() => StateHasChanged();

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
        board?.SetPayerPiece(idx, PlayerId);
    }
}