using MyPlaylist.Shared.DTO;
using System.Text.Json;

namespace MyPlaylist.Services
{
    public class PlaylistDataService : IPlaylistDataService
    {
        private readonly HttpClient _httpClient;

        public PlaylistDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<PlaylistDTO> Add(PlaylistDTO playlist)
        {
            throw new NotImplementedException();
        }

        public Task<PlaylistDTO> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<PlaylistDTO>> GetAll()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<PlaylistDTO>>
                (await _httpClient.GetStreamAsync($"/api/playlist/all"), new JsonSerializerOptions());
        }

        public Task<PlaylistDTO> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<PlaylistDTO> Update(PlaylistDTO playlist)
        {
            throw new NotImplementedException();
        }
    }
}
