using Microsoft.Win32.SafeHandles;
using System.Security.Claims;
using System.Text.Json.Serialization;

public interface IUserContext
{
    ClaimsPrincipal? CurrentUser { get; set; }
}

public class SpotifyUserContext : IUserContext
{
    public string? AccessToken { get; set; }
    public ClaimsPrincipal? CurrentUser { get; set; }

    [JsonPropertyName( "country" )]
    public string? Country { get; set; }

    [JsonPropertyName( "display_name" )]
    public string? DisplayName { get; set; }

    [JsonPropertyName( "email" )]
    public string? Email { get; set; }

    [JsonPropertyName( "explicit_content" )]
    public SpotifyExplicitContent? ExplicitContent { get; set; }

    [JsonPropertyName( "external_urls" )]
    public SpotifyExternalURLs? ExternalURLs { get; set; }

    [JsonPropertyName( "followers" )]
    public SpotifyFollowers? Followers { get; set; }

    [JsonPropertyName( "href" )]
    public string? Href { get; set; }

    [JsonPropertyName( "id" )]
    public string? Id { get; set; }

    [JsonPropertyName( "images" )]
    public SpotifyImage[]? Images { get; set; }

    [JsonPropertyName( "product" )]
    public string? Product { get; set; }

    [JsonPropertyName( "type" )]
    public string? Type { get; set; }

    [JsonPropertyName( "uri" )]
    public string? URI { get; set; }

    public SpotifyUserContext ReplaceWith( ClaimsPrincipal? userPrincipal, string? accessToken,  SpotifyUserContext? user )
    {
        if ( user == null || userPrincipal == null || string.IsNullOrEmpty(accessToken))
        {
            return this;
        }

        AccessToken = accessToken;
        CurrentUser = userPrincipal;
        Country = user.Country;
        DisplayName = user.DisplayName;
        Email = user.Email;
        ExplicitContent = user.ExplicitContent;
        ExternalURLs = user.ExternalURLs;
        Followers = user.Followers;
        Href = user.Href;
        Id = user.Id;
        Images = user.Images;
        Product = user.Product;
        Type = user.Type;
        URI = user.URI;
        return this;
    }
}

public class SpotifyExplicitContent
{
    [JsonPropertyName( "filter_enabled" )]
    public bool Enabled { get; set; }

    [JsonPropertyName( "filter_locked" )]
    public bool Locked { get; set; }
}

public class SpotifyExternalURLs
{
    [JsonPropertyName( "spotify" )]
    public string? Spotify { get; set; }
}

public class SpotifyFollowers
{
    [JsonPropertyName( "href" )]
    public string? Href { get; set; }

    [JsonPropertyName( "total" )]
    public int? Total { get; set; }
}


public class SpotifyImage
{
    [JsonPropertyName( "url" )]
    public string? URL { get; set; }

    [JsonPropertyName( "width" )]
    public int? Width { get; set; }

    [JsonPropertyName( "height" )]
    public int? Height { get; set; }
}