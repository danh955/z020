namespace z020.Website.Components.Pages;

using Microsoft.AspNetCore.Components;
using MudBlazor;
using z020.Website.Components.DialogBox;
using z020.Website.Services;
using z020.Website.Services.TicTacToe;

public partial class TicTacToe
{
    private IEnumerable<string>? boardNames;
    private TicTacToePlayer? player;

    [Inject] public required IDialogService DialogService { get; set; }
    [Inject] public required TicTacToeEngine Engine { get; set; }
    [Inject] public required UserService User { get; set; }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);
        if (firstRender)
        {
            var userId = await User.GetUserID();
            //// TODO: need user management
            this.player = new(userId, "test");
            UpdateBoardNames();
        }
    }

    private async Task NewBoardAsync()
    {
        if (player == null) return;

        var isSuccessful = await NewBoardDialog.GetAsync(DialogService, player);
        if (isSuccessful)
        {
            UpdateBoardNames();
        }
    }

    private void UpdateBoardNames()
    {
        if (this.player == null) return;
        boardNames = Engine.UsersBoardNames(player);
        this.StateHasChanged();
    }
}