using Microsoft.AspNetCore.Components;

namespace MyPlaylist.Shared
{
    public partial class Header
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        private async Task OnLogoClick()
        {
            await Task.Run(() => { NavigationManager.NavigateTo("/"); });
        }
    }
}
