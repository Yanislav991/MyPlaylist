using Microsoft.AspNetCore.Components;
using MyPlaylist.Services;
using MyPlaylist.Shared.DTO;

namespace MyPlaylist.Pages
{
    public partial class Playlists
    {
        public List<PlaylistDTO> PlaylistsData { get; set; } = new List<PlaylistDTO>();
        [Inject]
        public IPlaylistDataService _playlistDataService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            PlaylistsData = (await _playlistDataService.GetAll()).ToList();
        }

    }
}
