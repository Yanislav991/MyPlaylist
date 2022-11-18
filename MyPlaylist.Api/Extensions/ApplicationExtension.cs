using Microsoft.EntityFrameworkCore;
using MyPlaylist.Api.Data;
using MyPlaylist.Api.Models;

namespace MyPlaylist.Api.Extensions
{
    public static class ApplicationExtension
    {
        public static void PrepareDataBase(this IApplicationBuilder app)
        {
            using var services = app.ApplicationServices.CreateScope();

            var db = services.ServiceProvider.GetService<MyPlaylistDbContext>();
            SeedTrips(db);
            db.Database.Migrate();
        }
        private static void SeedTrips(MyPlaylistDbContext data)
        {
            if (data.Playlists.Any()) return;
            var genres = GetGenres();
            data.Genres.AddRange(genres);

            var playlists = GetPlaylists();
            data.Playlists.AddRange(playlists);

            var singers = GetSingers();
            data.Singers.AddRange(singers);

            var songs = GetSongs();
            data.Songs.AddRange(songs);
            data.SaveChanges();
        }
        private static IEnumerable<Singer> GetSingers()
        {
            return new Singer[]
            {
                new Singer(){ Name = "Singer 1", DateCreated = DateTime.Now },
                new Singer(){ Name = "Singer 2", DateCreated = DateTime.Now },
            };
        }
        private static IEnumerable<Playlist> GetPlaylists()
        {
            return new Playlist[]
            {
                new Playlist(){ Name = "Playlist 1", DateCreated = DateTime.Now },
                new Playlist() { Name = "Playlist 2", DateCreated = DateTime.Now.AddDays(1) }
            };
        }
        private static IEnumerable<Genre> GetGenres()
        {
            return new Genre[]
            {
                new Genre(){ Name = "Genre 1" },
                new Genre() { Name = "Genre 2" }
            };
        }
        private static IEnumerable<Song> GetSongs()
        {
            return Enumerable.Range(1, 4).Select(x => new Song()
            {
                DateCreated = DateTime.Now,
                GenreId = x % 2 == 0 ? 1 : 2,
                Name = "Song " + x,
            });
        }
    }
}
