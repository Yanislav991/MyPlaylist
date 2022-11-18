using System.ComponentModel.DataAnnotations;

namespace MyPlaylist.Api.Models
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string? Name { get; set; }
        public ICollection<Song> Songs { get; set; }
    }
}
