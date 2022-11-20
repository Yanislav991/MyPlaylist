using System.ComponentModel.DataAnnotations;

namespace MyPlaylist.Api.Models
{
    public class Song : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string? Name { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
        public ICollection<Playlist> Playlists { get; set; } = new HashSet<Playlist>();
        public ICollection<Singer> Singers { get; set; } = new HashSet<Singer>();
    }
}
