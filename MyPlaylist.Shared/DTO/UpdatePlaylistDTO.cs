using System.ComponentModel.DataAnnotations;

namespace MyPlaylist.Shared.DTO
{
    public class UpdatePlaylistDTO
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string? Name { get; set; }
    }
}
