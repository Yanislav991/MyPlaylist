using MyPlaylist.Shared.DTO;
using System.Net.Http.Json;
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

        public async Task<PlaylistDTO> Add(CreatePlaylistDTO playlist)
        {
            var response = await _httpClient.PostAsJsonAsync($"/api/playlist/create", playlist);
            return await response.Content.ReadFromJsonAsync<PlaylistDTO>(); ;
        }

        public Task<PlaylistDTO> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<PlaylistDTO>> GetAll()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<PlaylistDTO>>
                (await _httpClient.GetStreamAsync($"/api/playlist/all"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public Task<PlaylistDTO> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<PlaylistDTO> GetByName(string name)
        {
            try
            {
                return await JsonSerializer.DeserializeAsync<PlaylistDTO>
                    (await _httpClient.GetStreamAsync($"/api/playlist/getByName?name={name}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            }
            catch (Exception)
            {
                return null;
            }
        }

        public Task<PlaylistDTO> Update(PlaylistDTO playlist)
        {
            throw new NotImplementedException();
        }
    }
}
