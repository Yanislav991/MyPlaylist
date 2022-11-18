using Microsoft.AspNetCore.Mvc;
using MyPlaylist.Api.Services.Contracts;
using MyPlaylist.Shared.DTO;

namespace MyPlaylist.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlaylistController : ControllerBase
    {
        private IPlaylistService _playlistService;
        public PlaylistController(IPlaylistService playlistService)
        {
            _playlistService = playlistService;
        }
        [HttpGet("/all")]
        public async Task<ActionResult<IEnumerable<PlaylistDTO>>> Get()
        {
            var test = await _playlistService.GetAll();
            return null;
        }
    }
}
