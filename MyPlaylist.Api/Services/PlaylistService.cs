using Microsoft.EntityFrameworkCore;
using MyPlaylist.Api.Data;
using MyPlaylist.Api.Models;
using MyPlaylist.Api.Services.Contracts;

namespace MyPlaylist.Api.Services
{
    public class PlaylistService : IPlaylistService
    {
        private readonly MyPlaylistDbContext data;

        public PlaylistService(MyPlaylistDbContext data)
        {
            this.data = data;
        }
        public async Task<Playlist> Create(Playlist playlist)
        {
            if (data.Playlists.FirstOrDefault(x => x.Name == playlist.Name) != null)
            {
                throw new ArgumentException("Playlist with this name already exists");
            }
            await data.Playlists.AddAsync(playlist);
            await data.SaveChangesAsync();
            return await data.Playlists.FirstOrDefaultAsync(x => x.Name == playlist.Name);
        }

        public async Task Delete(int id)
        {
            data.Playlists.Remove(data.Playlists.FirstOrDefault(x => x.Id == id));
            await data.SaveChangesAsync();
        }

        public async Task<IEnumerable<Playlist>> GetAll()
        {
            return await data.Playlists.ToListAsync();
        }

        public async Task<Playlist> GetById(int id)
        {
            return await data.Playlists.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Playlist> GetByName(string name)
        {
            return await data.Playlists.FirstOrDefaultAsync(x => x.Name == name);
        }

        public async Task<Playlist> Update(Playlist playlist)
        {
            var record = await data.Playlists.FirstOrDefaultAsync(x=>x.Id == playlist.Id);
            if (data.Playlists.FirstOrDefault(x => x.Name == playlist.Name) != null)
            {
                throw new ArgumentException("Playlist with this name already exists!");
            }
            record.Name = playlist.Name;
            record.LastModified = DateTime.Now;
            await data.SaveChangesAsync();
            return await data.Playlists.FirstOrDefaultAsync(x => x.Name == playlist.Name);
        }
    }
}
