using Microsoft.EntityFrameworkCore;
using MyPlaylist.Api.Data;

namespace MyPlaylist.Api.Extensions
{
    public static class ApplicationExtension
    {
        public static void PrepareDataBase(this IApplicationBuilder app)
        {
            using var services = app.ApplicationServices.CreateScope();

            var db = services.ServiceProvider.GetService<MyPlaylistDbContext>();
            db.Database.Migrate();
        }
    }
}
