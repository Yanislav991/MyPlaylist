using AutoMapper;
using MyPlaylist.Api.Models;
using MyPlaylist.Shared.DTO;

namespace MyPlaylist.Api.Profiles
{
    public class PlaylistProfile : Profile
    {
        public PlaylistProfile()
        {
            CreateMap<Playlist, PlaylistDTO>().ReverseMap();
            CreateMap<Playlist, CreatePlaylistDTO>().ReverseMap();
            CreateMap<Playlist, UpdatePlaylistDTO>().ReverseMap();
        }
    }
}
