using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ScreenSound.Web;
using ScreenSound.Web.Services;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor.Services;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddMudServices();
builder.Services.AddTransient<ArtistaAPI>();
builder.Services.AddTransient<MusicasAPI>();
builder.Services.AddHttpClient("API", client =>
{
    client.BaseAddress = new Uri(builder.Configuration["APIServer:Url"]!);
    client.DefaultRequestHeaders.Add("Accept", "application/json");
});

await builder.Build().RunAsync();
