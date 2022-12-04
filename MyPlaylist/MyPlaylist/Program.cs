using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MyPlaylist;
using MyPlaylist.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddBootstrapBlazor();

builder.Services.AddHttpClient<IPlaylistDataService, PlaylistDataService>(cl => cl.BaseAddress = new Uri("https://localhost:7106"));
await builder.Build().RunAsync();
