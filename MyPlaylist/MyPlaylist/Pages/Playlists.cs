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
        public string NewPlaylistName { get; set; }

        protected override async Task OnInitializedAsync()
        {
            PlaylistsData = (await _playlistDataService.GetAll()).ToList();
        }
        public async void CreatePlaylist()
        {
            await _playlistDataService.Add(new PlaylistDTO() { Name = NewPlaylistName });
            NewPlaylistName = string.Empty;
        }

    }
}
