namespace z020.Website.Components.DialogBox;

using Microsoft.AspNetCore.Components;
using MudBlazor;
using z020.Website.Services.TicTacToe;

public partial class NewBoardDialog
{
    [Inject] public TicTacToeEngine? Engine { get; set; }

    [Parameter] public TicTacToePlayer? Player { get; set; }

    [CascadingParameter] private MudDialogInstance? Dialog { get; set; }

    private string? Name { get; set; }
    private Pieces Piece { get; set; }

    /// <summary>
    /// Display and get a new board.
    /// </summary>
    /// <param name="DialogService">IDialogService.</param>
    /// <returns>True if successful.</returns>
    public static async Task<bool> GetAsync(IDialogService DialogService, TicTacToePlayer player)
    {
        var parameters = new DialogParameters<NewBoardDialog>
        {
            { p => p.Player, player }
        };

        var options = new DialogOptions { CloseOnEscapeKey = true, CloseButton = true };
        var dialog = await DialogService.ShowAsync<NewBoardDialog>("New Tic-Tac-Toe game", parameters, options);
        var result = await dialog.Result;

        if (result.Canceled || result.Data == null) return false;
        return (bool)result.Data;
    }

    private void Cancel() => Dialog?.Cancel();

    private void Submit()
    {
        if (string.IsNullOrWhiteSpace(Name) || Player == null || Engine == null) return;

        bool isSuccessful = Engine.AddBoard(Name, Piece, Player);
        Dialog?.Close(DialogResult.Ok(isSuccessful));
    }
}