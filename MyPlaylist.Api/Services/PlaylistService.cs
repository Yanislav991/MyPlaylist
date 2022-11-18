using Microsoft.EntityFrameworkCore;
using MyPlaylist.Api.Data;
using MyPlaylist.Api.Services.Contracts;
using MyPlaylist.Shared.DTO;

namespace MyPlaylist.Api.Services
{
    public class PlaylistService : IPlaylistService
    {
        private readonly MyPlaylistDbContext data;

        public PlaylistService(MyPlaylistDbContext data)
        {
            this.data = data;
        }
        public Task<PlaylistDTO> Create(PlaylistDTO playlistDTO)
        {
            throw new NotImplementedException();
        }

        public Task<PlaylistDTO> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<PlaylistDTO>> GetAll()
        {
            var test  = await data.Playlists.ToListAsync();
            return null;
        }

        public Task<PlaylistDTO> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<PlaylistDTO> Update(PlaylistDTO playlistDTO)
        {
            throw new NotImplementedException();
        }
    }
}
