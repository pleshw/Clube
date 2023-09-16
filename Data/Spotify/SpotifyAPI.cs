using System.Net.Http.Headers;
using System.Text.Json;

namespace Clube.Data.Spotify
{
    public struct SpotifyEndpoint
    {
        public SpotifyEndpoint( string uRL , HttpMethod method )
        {
            URL = uRL;
            Method = method;
        }

        public string URL { get; set; }
        public HttpMethod Method { get; set; }
    }

    public static class SpotifyRequestURI 
    {
        public static readonly SpotifyEndpoint GetCurrentUser = new("https://api.spotify.com/v1/me", HttpMethod.Get );
        public static readonly SpotifyEndpoint GetPlayerPlaybackState = new( "https://api.spotify.com/v1/me/player" , HttpMethod.Get );
    }

    public static class SpotifyAPI
    {
        public static async Task<SpotifyUserContext?> GetSpotiftUserContext( this HttpClient client , string accessToken )
        {
            return await Request<SpotifyUserContext>(
                    accessToken ,
                    SpotifyRequestURI.GetCurrentUser ,
                    client );
        }

        public static async Task<SpotifyPlaybackState?> GetPlayerPlaybackState( this HttpClient client , string accessToken )
        {
            return await Request<SpotifyPlaybackState>(
                    accessToken ,
                    SpotifyRequestURI.GetPlayerPlaybackState ,
                    client );
        }

        public static async Task<T?> Request<T>( string accessToken, SpotifyEndpoint endpoint, HttpClient? backchannelClient )
        {
            HttpRequestMessage request = new HttpRequestMessage( endpoint.Method , endpoint.URL);
            request.Headers.Add( "Accept" , "application/json" );
            request.Headers.Add( "Authorization" , $"Bearer {accessToken}" );

            HttpClient client = backchannelClient ?? new HttpClient();
            HttpResponseMessage response = await client.SendAsync( request );
            string spotifyRequestResult = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode && !string.IsNullOrEmpty( spotifyRequestResult ))
            {
                return JsonSerializer.Deserialize<T>( spotifyRequestResult );
            }

            return default;
        }
    }
}
