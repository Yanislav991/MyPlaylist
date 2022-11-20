using System.ComponentModel.DataAnnotations;

namespace MyPlaylist.Shared.DTO
{
    public class PlaylistDTO
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string? Name { get; set; }
        public ICollection<SongDTO> Songs { get; set; } = new HashSet<SongDTO>();
    }
}
