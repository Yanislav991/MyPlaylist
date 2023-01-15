using MyPlaylist.Shared.DTO;

namespace MyPlaylist.Services
{
    public interface IPlaylistDataService
    {
        Task<PlaylistDTO> GetById(int id);
        Task<PlaylistDTO> GetByName(string name);
        Task<IEnumerable<PlaylistDTO>> GetAll();
        Task<PlaylistDTO> Add (CreatePlaylistDTO playlist);
        Task<PlaylistDTO> Update(PlaylistDTO playlist);
        Task<PlaylistDTO> Delete(int id);
    }
}
