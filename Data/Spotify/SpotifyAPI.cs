using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

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
        public static readonly SpotifyEndpoint TransferPlayback = new( "https://api.spotify.com/v1/me/player" , HttpMethod.Put );
    }

    public static class SpotifyAPI
    {
        public static JsonSerializerOptions _JSONParseOptions = new JsonSerializerOptions
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };

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

        public class SetPlayerCurrentPlaybackPayload
        {
            [JsonPropertyName( "device_ids" )]
            public required string[] DeviceIds { get; set; }

            [JsonPropertyName( "play" )]
            public bool? Play { get; set; }
        }

        public static async Task<string?> SetPlayerCurrentPlaybackAndPlay( this HttpClient client , string accessToken, string deviceId )
        {
            return await RequestRaw(
                    accessToken ,
                    SpotifyRequestURI.TransferPlayback ,
                    client ,
                    Parse( new SetPlayerCurrentPlaybackPayload
                        {
                            DeviceIds = new string[] { deviceId } ,
                            Play = true
                        } )
                    );
        }

        public static async Task<string?> SetPlayerCurrentPlayback( this HttpClient client , string accessToken , string deviceId )
        {
            return await RequestRaw(
                    accessToken ,
                    SpotifyRequestURI.TransferPlayback ,
                    client ,
                    Parse( new SetPlayerCurrentPlaybackPayload
                    {
                        DeviceIds = new string[] { deviceId }
                    } )
                    );
        }

        public static async Task<T?> Request<T>( string accessToken, SpotifyEndpoint endpoint, HttpClient? backchannelClient , JsonDocument? parameters = null )
        {
            string? response = await RequestRaw( accessToken , endpoint , backchannelClient, parameters );

            return response == null
                ? default 
                : JsonSerializer.Deserialize<T>( response );
        }

        public static async Task<string?> RequestRaw( string accessToken , SpotifyEndpoint endpoint , HttpClient? backchannelClient, JsonDocument? parameters = null )
        {
            HttpRequestMessage request = new HttpRequestMessage( endpoint.Method , endpoint.URL );
            request.Headers.Add( "Accept" , "application/json" );
            request.Headers.Add( "Authorization" , $"Bearer {accessToken}" );

            if (parameters != null)
            {
                SetParameters( request , endpoint.Method , parameters );
            }

            HttpClient client = backchannelClient ?? new HttpClient();
            HttpResponseMessage response = await client.SendAsync( request );
            string spotifyRequestResult = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode && !string.IsNullOrEmpty( spotifyRequestResult ))
            {
                return spotifyRequestResult;
            }

            return null;
        }

        private static void SetParameters(HttpRequestMessage request ,HttpMethod httpMethod ,JsonDocument parameters)
        {
            if (httpMethod == HttpMethod.Get)
            {
                // Append parameters to the query string.
                var queryString = new StringBuilder();
                foreach (var property in parameters.RootElement.EnumerateObject())
                {
                    queryString.Append( $"{property.Name}={property.Value.GetString()}&" );
                }
                // Remove the trailing '&' character.
                if (queryString.Length > 0)
                {
                    queryString.Length--;
                }
                request.RequestUri = new Uri( $"{request.RequestUri}?{queryString}" );
            }
            else
            {
                // Assuming POST or other HTTP methods where you can include parameters in the request body.
                var parameterJson = parameters.RootElement.ToString();
                request.Content = new StringContent( parameterJson , Encoding.UTF8 , "application/json" );
            }
        }

        private static JsonDocument Parse(object item )
        {
            return JsonDocument.Parse( JsonSerializer.Serialize( item , _JSONParseOptions ) );
        }
    }
}
