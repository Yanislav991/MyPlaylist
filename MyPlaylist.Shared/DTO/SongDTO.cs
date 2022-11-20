using System.ComponentModel.DataAnnotations;

namespace MyPlaylist.Shared.DTO
{
    public class SongDTO
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string? Name { get; set; }
        public string GenreName { get; set; }
        public ICollection<PlaylistDTO> Playlists { get; set; } = new HashSet<PlaylistDTO>();
        public ICollection<SingerDTO> Singers { get; set; } = new HashSet<SingerDTO>();
    }
}
