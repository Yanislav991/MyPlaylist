using Microsoft.AspNetCore.Components;
using MyPlaylist.Services;
using MyPlaylist.Shared.DTO;

namespace MyPlaylist.Pages
{
    public partial class Playlists
    {
        public List<PlaylistDTO> PlaylistsData { get; set; } = new List<PlaylistDTO>();
        [Inject]
        public IPlaylistDataService PlaylistDataService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            PlaylistsData = (await PlaylistDataService.GetAll()).ToList();
        }
        private async Task AddSong(int playlistID)
        {

        }

    }
}
