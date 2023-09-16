using Clube.Data;
using Clube.Data.Spotify;
using Clube.Shared;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Text.Json;
using static Clube.Shared.YoutubeDownloader;

var builder = WebApplication.CreateBuilder( args );

// Add services to the container.
builder.Configuration.AddUserSecrets<Program>();
ConfigureServices( builder.Services , builder.Configuration );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler( "/Error" );
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseSession();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage( "/_Host" );

app.Run();


void ConfigureServices( IServiceCollection services , IConfiguration configuration )
{
    services.AddOptions();
    services.AddHttpContextAccessor();
    services.AddSession();
    services.AddHttpClient();
    services.AddAuthorizationCore();
    services.AddRazorPages();
    services.AddServerSideBlazor();
    services.AddTransient<IObserver<double> , YoutubeDownloader>();
    services.AddTransient<IProgress<double> , ProgressTracker>();
    services.AddSingleton<YoutubeDownloaderService>();
    services.AddSingleton<SpotifyUserContext>();

    SpotifyCredentialsProvider? spotifyCredentialsProvider = new SpotifyCredentialsProvider( configuration );
    services.AddSingleton( provider => spotifyCredentialsProvider );

    services.AddAuthentication( options =>
    {
        options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    } )
    .AddCookie()
    .AddOAuth( "Spotify" , options =>
    {
        options.ClientId = SpotifyCredentialsProvider.ClientId;
        options.ClientSecret = SpotifyCredentialsProvider.ClientSecret;
        options.CallbackPath = "/signin-spotify"; // Adjust this path as needed
        options.AuthorizationEndpoint = "https://accounts.spotify.com/authorize";
        options.TokenEndpoint = "https://accounts.spotify.com/api/token";
        options.SaveTokens = true;

        options.Scope.Add( "ugc-image-upload" );
        options.Scope.Add( "user-read-playback-state" );
        options.Scope.Add( "user-modify-playback-state" );
        options.Scope.Add( "user-read-currently-playing" );
        options.Scope.Add( "app-remote-control" );
        options.Scope.Add( "streaming" );
        options.Scope.Add( "playlist-read-private" );
        options.Scope.Add( "playlist-read-collaborative" );
        options.Scope.Add( "playlist-modify-private" );
        options.Scope.Add( "playlist-modify-public" );
        options.Scope.Add( "user-follow-modify" );
        options.Scope.Add( "user-follow-read" );
        options.Scope.Add( "user-read-playback-position" );
        options.Scope.Add( "user-top-read" );
        options.Scope.Add( "user-read-recently-played" );
        options.Scope.Add( "user-library-modify" );
        options.Scope.Add( "user-library-read" );
        options.Scope.Add( "user-read-email" );
        options.Scope.Add( "user-read-private" );
        //options.Scope.Add( "user-soa-link" );
        //options.Scope.Add( "user-soa-unlink" );
        //options.Scope.Add( "user-manage-entitlements" );
        //options.Scope.Add( "user-manage-partner" );
        //options.Scope.Add( "user-create-partner" );

        options.Events = new OAuthEvents
        {
            OnCreatingTicket = async context =>
            {
                if (string.IsNullOrEmpty( context.AccessToken ))
                {
                    return;
                }

                if (context.Identity is not null)
                {
                    SpotifyUserContext? userContextUpdated = await context.Backchannel.GetSpotiftUserContext( context.AccessToken );

                    SpotifyUserContext? spotifyUserContextOld = context.HttpContext.RequestServices.GetRequiredService<SpotifyUserContext>();
                    spotifyUserContextOld.ReplaceWith( context.Principal , context.AccessToken , userContextUpdated );
                }
            }
        };
    } );
}
