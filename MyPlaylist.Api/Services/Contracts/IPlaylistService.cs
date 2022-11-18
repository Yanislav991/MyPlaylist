using MyPlaylist.Shared.DTO;

namespace MyPlaylist.Api.Services.Contracts
{
    public interface IPlaylistService
    {
        Task<PlaylistDTO> GetById(int id);
        Task<IEnumerable<PlaylistDTO>> GetAll();
        Task<PlaylistDTO> Create(PlaylistDTO playlistDTO);  
        Task<PlaylistDTO> Update(PlaylistDTO playlistDTO);  
        Task<PlaylistDTO> Delete(int id);  
    }
}
