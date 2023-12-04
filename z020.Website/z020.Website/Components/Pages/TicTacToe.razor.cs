namespace z020.Website.Components.Pages;

using Microsoft.AspNetCore.Components;
using MudBlazor;
using z020.Website.Components.DialogBox;
using z020.Website.Services;
using z020.Website.Services.TicTacToe;

public partial class TicTacToe
{
    private IEnumerable<string>? boardNames;
    private string playerId = string.Empty;

    [Inject] public required IDialogService DialogService { get; set; }
    [Inject] public required TicTacToeEngine Engine { get; set; }
    [Inject] public required SessionService Session { get; set; }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);
        if (firstRender)
        {
            await Session.SetupAfterRenderAsync();
            playerId = Session.PlayerId;
            UpdateBoardNames();
        }
    }

    private async Task NewBoardAsync()
    {
        var isSuccessful = await NewBoardDialog.GetAsync(DialogService, playerId);
        if (isSuccessful)
        {
            UpdateBoardNames();
        }
    }

    private void UpdateBoardNames()
    {
        boardNames = Engine.UsersBoardNames(playerId);
        this.StateHasChanged();
    }
}