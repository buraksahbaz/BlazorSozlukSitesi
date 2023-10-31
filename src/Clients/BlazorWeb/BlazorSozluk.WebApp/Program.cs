using Blazored.LocalStorage;
using BlazorSozluk.WebApp;
using BlazorSozluk.WebApp.Infrastructure.Auth;
using BlazorSozluk.WebApp.Infrastructure.Services.Interfaces;
using BlazorSozluk.WebApp.Infrastructure.Services;
using BlazorSozluk.WebApp.Inftastructure.Services;
using BlazorSozluk.WebApp.Inftastructure.Services.Interfaces;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var address = builder.Configuration["address"];
builder.Services.AddHttpClient("WebApiClient", client =>
{
    client.BaseAddress = new Uri("https://localhost:5001");
}).AddHttpMessageHandler<AuthTokenHandler>();

builder.Services.AddScoped(sp =>
{
    var clientFactory = sp.GetRequiredService<IHttpClientFactory>();
    var client = clientFactory.CreateClient("WebApiClient");
    return client;
});

builder.Services.AddScoped<AuthTokenHandler>();

builder.Services.AddTransient<IEntryService, EntryService>();
builder.Services.AddTransient<IVoteService, VoteService>();
builder.Services.AddTransient<IFavService, FavService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IIdentityService, IdentityService>();

builder.Services.AddScoped<AuthenticationStateProvider, AuthStateProvider>();
builder.Services.AddBlazoredLocalStorage();

builder.Services.AddAuthorizationCore();

await builder.Build().RunAsync();
