using System.ComponentModel.DataAnnotations;

namespace MyPlaylist.Shared.DTO
{
    public class CreatePlaylistDTO
    {
        [Required]
        [MaxLength(30)]
        public string? Name { get; set; }
    }
}
