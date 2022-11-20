using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPlaylist.Shared.DTO
{
    public class CreatePlaylistDTO
    {
        [Required]
        [MaxLength(30)]
        public string? Name { get; set; }
    }
}
