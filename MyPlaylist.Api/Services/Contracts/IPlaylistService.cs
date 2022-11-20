using MyPlaylist.Api.Models;
using MyPlaylist.Shared.DTO;

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
