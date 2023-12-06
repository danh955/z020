namespace z020.Website.Components.TicTacToe;

using Microsoft.AspNetCore.Components;
using MudBlazor;
using z020.Website.Services.TicTacToe;

public partial class NewBoardDialog
{
    [Inject] public required TicTacToeEngine Engine { get; set; }

    [Parameter] public required string PlayerId { get; set; }

    private string? BoardName { get; set; }
    [CascadingParameter] private MudDialogInstance? Dialog { get; set; }
    private Pieces Piece { get; set; }
    private string? PlayerName { get; set; }

    /// <summary>
    /// Display and get a new board.
    /// </summary>
    /// <param name="dialogService">IDialogService.</param>
    /// <param name="playerId">The player ID.</param>
    /// <returns>True if successful.</returns>
    public static async Task<bool> GetAsync(IDialogService dialogService, string playerId)
    {
        var parameters = new DialogParameters<NewBoardDialog>
        {
            { p => p.PlayerId, playerId }
        };

        var options = new DialogOptions { CloseOnEscapeKey = true, CloseButton = true };
        var dialog = await dialogService.ShowAsync<NewBoardDialog>("New Tic-Tac-Toe game", parameters, options);
        var result = await dialog.Result;

        if (result.Canceled || result.Data == null) return false;
        return (bool)result.Data;
    }

    private void Cancel() => Dialog?.Cancel();

    private void Submit()
    {
        if (string.IsNullOrWhiteSpace(BoardName)
            || string.IsNullOrWhiteSpace(PlayerId)
            || string.IsNullOrWhiteSpace(PlayerName)) return;

        bool isSuccessful = Engine.AddBoard(BoardName, Piece, PlayerId, PlayerName);
        Dialog?.Close(DialogResult.Ok(isSuccessful));
    }
}