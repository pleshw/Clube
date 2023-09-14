namespace Clube.Data.Spotify
{
    public class SpotifyCredentials
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }

        public SpotifyCredentials( string id , string secret )
        {
            ClientId = id;
            ClientSecret = secret;
        }

        public SpotifyCredentials( IConfiguration configuration ) :
            this( configuration["Services:Authentication:Spotify:ClientId"]! , configuration["Services:Authentication:Spotify:ClientSecret"]! )
        {
        }
    }

    public class SpotifyCredentialsProvider
    {
        public static SpotifyCredentials? Instance;

        public SpotifyCredentialsProvider( string id , string secret )
        {
            if (Instance == null)
            {
                Instance = new SpotifyCredentials( id , secret );
            }
        }

        public SpotifyCredentialsProvider( IConfiguration configuration )
        {
            if (Instance == null)
            {
                Instance = new SpotifyCredentials( configuration );
            }
        }

        public static string ClientId
        {
            get
            {
                if(Instance == null)
                {
                    throw new InvalidOperationException( "An instance of Spotify Credentials have to be set on app initialization(program.cs)." );
                }

                return Instance.ClientId;
            }
        }

        public static string ClientSecret
        {
            get
            {
                if (Instance == null)
                {
                    throw new InvalidOperationException( "An instance of Spotify Credentials have to be set on app initialization(program.cs)." );
                }

                return Instance.ClientSecret;
            }
        }
    }
}
