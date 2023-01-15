using MyPlaylist.Api.Models;

namespace MyPlaylist.Api.Services.Contracts
{
    public interface IPlaylistService
    {
        Task<Playlist> GetById(int id);
        Task<IEnumerable<Playlist>> GetAll();
        Task<Playlist> Create(Playlist playlistDTO);
        Task<Playlist> Update(Playlist playlistDTO);
        Task Delete(int id);
    }
}
