using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using MyPlaylist.Services;
using MyPlaylist.Shared.DTO;

namespace MyPlaylist.Pages
{
    public partial class AddPlaylist
    {
        [Inject]
        private IJSRuntime JS { get; set; }
        [Inject]
        public IPlaylistDataService PlaylistDataService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        private CreatePlaylistDTO playListModel = new();
        private bool IsNameTaken = false;

        async Task OnSubmit(EditContext editContext)
        {
            var isValid = editContext.Validate();
            if (isValid)
            {
                try
                {
                    var isNameTaken = (await PlaylistDataService.GetByName(playListModel.Name)) != null;
                    if (!isNameTaken)
                    {
                        await PlaylistDataService.Add(playListModel);
                        NavigationManager.NavigateTo("/playlists/all");
                    }
                    else
                    {
                        IsNameTaken = true;
                        Console.WriteLine("Taken");
                        StateHasChanged();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    await JS.InvokeVoidAsync("alert", ex.Message);
                }
            }

        }
    }
}
