using Microsoft.EntityFrameworkCore;
using MyPlaylist.Api.Data;
using MyPlaylist.Api.Extensions;
using MyPlaylist.Api.Services;
using MyPlaylist.Api.Services.Contracts;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<MyPlaylistDbContext>(opt => opt.UseSqlServer(connectionString));
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddTransient<IPlaylistService, PlaylistService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.PrepareDataBase();

app.Run();
