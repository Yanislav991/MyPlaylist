using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyPlaylist.Api.Models;
using MyPlaylist.Api.Services.Contracts;
using MyPlaylist.Shared.DTO;

namespace MyPlaylist.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlaylistController : ControllerBase
    {
        private IPlaylistService _playlistService;
        private readonly IMapper _mapper;
        public PlaylistController(IPlaylistService playlistService, IMapper mapper)
        {
            _mapper = mapper;
            _playlistService = playlistService;
        }
        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<PlaylistDTO>>> Get()
        {
            try
            {
                return Ok(_mapper.Map<PlaylistDTO[]>(await _playlistService.GetAll()));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, new { Message = "Something went wrong!" });
            }
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<PlaylistDTO>> GetById(int id)
        {
            try
            {
                var result = await _playlistService.GetById(id);
                if (result == null) return NotFound();
                return Ok(_mapper.Map<PlaylistDTO[]>(result));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, new { Message = "Something went wrong!" });
            }
        }
        [HttpPost("/create")]
        public async Task<ActionResult<PlaylistDTO>> Create(CreatePlaylistDTO playlist)
        {
            try
            {
                var newRecord = await _playlistService.Create(_mapper.Map<Playlist>(playlist));
                return Ok(_mapper.Map<PlaylistDTO>(newRecord));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, new { Message = "Something went wrong!" });
            }
        }
        [HttpPut("/update")]
        public async Task<ActionResult<IEnumerable<PlaylistDTO>>> Update(UpdatePlaylistDTO playlist)
        {
            try
            {
                var newRecord = await _playlistService.Update(_mapper.Map<Playlist>(playlist));
                return Ok(_mapper.Map<PlaylistDTO>(newRecord));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, new { Message = "Something went wrong!" });
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _playlistService.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, new { Message = "Something went wrong!" });
            }
        }
    }
}
