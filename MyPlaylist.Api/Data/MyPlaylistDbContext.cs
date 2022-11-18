using Microsoft.EntityFrameworkCore;
using MyPlaylist.Api.Models;

namespace MyPlaylist.Api.Data
{
    public class MyPlaylistDbContext : DbContext
    {
        public MyPlaylistDbContext(DbContextOptions<MyPlaylistDbContext> options)
            : base(options){}

        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Singer> Singers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Singer>()
                .HasMany(bc => bc.Songs)
                .WithMany(b => b.Singers);
            modelBuilder.Entity<Playlist>()
                .HasMany(bc => bc.Songs)
                .WithOne(c => c.Playlist)
                .HasForeignKey(bc => bc.PlaylistId);
            modelBuilder.Entity<Genre>()
                .HasMany(x => x.Songs)
                .WithOne(x => x.Genre);
        }
    }
}
