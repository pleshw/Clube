using System.Text.Json.Serialization;

namespace Clube.Data.Spotify
{

    public class SpotifyUser
    {
        [JsonPropertyName( "country" )]
        public string? Country { get; set; }

        [JsonPropertyName( "display_name" )]
        public string? DisplayName { get; set; }

        [JsonPropertyName( "email" )]
        public string? Email { get; set; }

        [JsonPropertyName( "explicit_content" )]
        public SpotifyExplicitContent? ExplicitContent { get; set; }

        [JsonPropertyName( "external_urls" )]
        public SpotifyExternalUrls? ExternalURLs { get; set; }

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
    }



    public class SpotifyPlaybackState
    {
        [JsonPropertyName( "device" )]
        public SpotifyDevice? Device { get; set; }

        [JsonPropertyName( "repeat_state" )]
        public string? RepeatState { get; set; }

        [JsonPropertyName( "shuffle_state" )]
        public bool? ShuffleState { get; set; }

        [JsonPropertyName( "context" )]
        public SpotifyContext? Context { get; set; }

        [JsonPropertyName( "timestamp" )]
        public long? Timestamp { get; set; }

        [JsonPropertyName( "progress_ms" )]
        public long? ProgressMs { get; set; }

        [JsonPropertyName( "is_playing" )]
        public bool? IsPlaying { get; set; }

        [JsonPropertyName( "item" )]
        public SpotifyItem? Item { get; set; }

        [JsonPropertyName( "currently_playing_type" )]
        public string? CurrentlyPlayingType { get; set; }

        [JsonPropertyName( "actions" )]
        public SpotifyActions? Actions { get; set; }
    }

    public static class SpotifyPlaybackStateUtils
    {
        public static bool IsActive( this SpotifyPlaybackState spotifyPlaybackState )
        {
            return spotifyPlaybackState.Device != null && spotifyPlaybackState.Device.IsActive != null && spotifyPlaybackState.Device.IsActive.Value;
        }

        public static bool IsPlaying( this SpotifyPlaybackState spotifyPlaybackState )
        {
            return spotifyPlaybackState.IsActive() && spotifyPlaybackState.IsPlaying != null && spotifyPlaybackState.IsPlaying.Value;
        }

        public static bool IsConnectedToDevice( this SpotifyPlaybackState spotifyPlaybackState, string deviceIdToCheck )
        {
            return spotifyPlaybackState.IsActive() && spotifyPlaybackState.Device!.Id == deviceIdToCheck;
        }
    }

    public class SpotifyRestrictions
    {
        [JsonPropertyName( "reason" )]
        public string? Reason { get; set; }
    }
    public class SpotifyExplicitContent
    {
        [JsonPropertyName( "filter_enabled" )]
        public bool Enabled { get; set; }

        [JsonPropertyName( "filter_locked" )]
        public bool Locked { get; set; }
    }

    public class SpotifyExternalUrls
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

    public class SpotifyArtists
    {
        [JsonPropertyName( "external_urls" )]
        public SpotifyExternalUrls? ExternalUrls { get; set; }

        [JsonPropertyName( "href" )]
        public string? Href { get; set; }

        [JsonPropertyName( "id" )]
        public string? Id { get; set; }

        [JsonPropertyName( "name" )]
        public string? Name { get; set; }

        [JsonPropertyName( "type" )]
        public string? Type { get; set; }

        [JsonPropertyName( "uri" )]
        public string? Uri { get; set; }
    }

    public class SpotifyDevice
    {
        [JsonPropertyName( "id" )]
        public string? Id { get; set; }

        [JsonPropertyName( "is_active" )]
        public bool? IsActive { get; set; }

        [JsonPropertyName( "is_private_session" )]
        public bool? IsPrivateSession { get; set; }

        [JsonPropertyName( "is_restricted" )]
        public bool? IsRestricted { get; set; }

        [JsonPropertyName( "name" )]
        public string? Name { get; set; }

        [JsonPropertyName( "type" )]
        public string? Type { get; set; }

        [JsonPropertyName( "volume_percent" )]
        public int? VolumePercent { get; set; }

        [JsonPropertyName( "supports_volume" )]
        public bool? SupportsVolume { get; set; }
    }

    public class SpotifyContext
    {
        [JsonPropertyName( "type" )]
        public string? Type { get; set; }

        [JsonPropertyName( "href" )]
        public string? Href { get; set; }

        [JsonPropertyName( "external_urls" )]
        public SpotifyExternalUrls? ExternalUrls { get; set; }

        [JsonPropertyName( "uri" )]
        public string? Uri { get; set; }
    }

    public class SpotifyActions
    {
        [JsonPropertyName( "interrupting_playback" )]
        public bool? InterruptingPlayback { get; set; }

        [JsonPropertyName( "pausing" )]
        public bool? Pausing { get; set; }

        [JsonPropertyName( "resuming" )]
        public bool? Resuming { get; set; }

        [JsonPropertyName( "seeking" )]
        public bool? Seeking { get; set; }

        [JsonPropertyName( "skipping_next" )]
        public bool? SkippingNext { get; set; }

        [JsonPropertyName( "skipping_prev" )]
        public bool? SkippingPrev { get; set; }

        [JsonPropertyName( "toggling_repeat_context" )]
        public bool? TogglingRepeatContext { get; set; }

        [JsonPropertyName( "toggling_shuffle" )]
        public bool? TogglingShuffle { get; set; }

        [JsonPropertyName( "toggling_repeat_track" )]
        public bool? TogglingRepeatTrack { get; set; }

        [JsonPropertyName( "transferring_playback" )]
        public bool? TransferringPlayback { get; set; }
    }

    public class SpotifyItem
    {
        [JsonPropertyName( "album" )]
        public SpotifyAlbum? Album { get; set; }

        [JsonPropertyName( "artists" )]
        public List<SpotifyArtists>? Artists { get; set; }

        [JsonPropertyName( "available_markets" )]
        public List<string>? AvailableMarkets { get; set; }

        [JsonPropertyName( "disc_number" )]
        public int? DiscNumber { get; set; }

        [JsonPropertyName( "duration_ms" )]
        public int? DurationMs { get; set; }

        [JsonPropertyName( "explicit" )]
        public bool? Explicit { get; set; }

        [JsonPropertyName( "external_ids" )]
        public Dictionary<string , string>? ExternalIds { get; set; }

        [JsonPropertyName( "external_urls" )]
        public SpotifyExternalUrls? ExternalUrls { get; set; }

        [JsonPropertyName( "href" )]
        public string? Href { get; set; }

        [JsonPropertyName( "id" )]
        public string? Id { get; set; }

        [JsonPropertyName( "is_playable" )]
        public bool? IsPlayable { get; set; }

        [JsonPropertyName( "linked_from" )]
        public object? LinkedFrom { get; set; }

        [JsonPropertyName( "restrictions" )]
        public SpotifyRestrictions? Restrictions { get; set; }

        [JsonPropertyName( "name" )]
        public string? Name { get; set; }

        [JsonPropertyName( "popularity" )]
        public int? Popularity { get; set; }

        [JsonPropertyName( "preview_url" )]
        public string? PreviewUrl { get; set; }

        [JsonPropertyName( "track_number" )]
        public int? TrackNumber { get; set; }

        [JsonPropertyName( "type" )]
        public string? Type { get; set; }

        [JsonPropertyName( "uri" )]
        public string? Uri { get; set; }

        [JsonPropertyName( "is_local" )]
        public bool? IsLocal { get; set; }
    }

    public class SpotifyResponse
    {
        [JsonPropertyName( "device" )]
        public SpotifyDevice? Device { get; set; }

        [JsonPropertyName( "repeat_state" )]
        public string? RepeatState { get; set; }

        [JsonPropertyName( "shuffle_state" )]
        public bool? ShuffleState { get; set; }

        [JsonPropertyName( "context" )]
        public SpotifyContext? Context { get; set; }

        [JsonPropertyName( "timestamp" )]
        public long? Timestamp { get; set; }

        [JsonPropertyName( "progress_ms" )]
        public long? ProgressMs { get; set; }

        [JsonPropertyName( "is_playing" )]
        public bool? IsPlaying { get; set; }

        [JsonPropertyName( "item" )]
        public SpotifyItem? Item { get; set; }

        [JsonPropertyName( "currently_playing_type" )]
        public string? CurrentlyPlayingType { get; set; }

        [JsonPropertyName( "actions" )]
        public SpotifyActions? Actions { get; set; }
    }

    public class SpotifyArtist
    {
        [JsonPropertyName( "external_urls" )]
        public SpotifyExternalUrls? ExternalUrls { get; set; }

        [JsonPropertyName( "href" )]
        public string? Href { get; set; }

        [JsonPropertyName( "id" )]
        public string? Id { get; set; }

        [JsonPropertyName( "name" )]
        public string? Name { get; set; }

        [JsonPropertyName( "type" )]
        public string? Type { get; set; }

        [JsonPropertyName( "uri" )]
        public string? Uri { get; set; }
    }

    public class SpotifyAlbum
    {
        [JsonPropertyName( "album_type" )]
        public string? AlbumType { get; set; }

        [JsonPropertyName( "total_tracks" )]
        public int? TotalTracks { get; set; }

        [JsonPropertyName( "available_markets" )]
        public List<string>? AvailableMarkets { get; set; }

        [JsonPropertyName( "external_urls" )]
        public SpotifyExternalUrls? ExternalUrls { get; set; }

        [JsonPropertyName( "href" )]
        public string? Href { get; set; }

        [JsonPropertyName( "id" )]
        public string? Id { get; set; }

        [JsonPropertyName( "images" )]
        public List<SpotifyImage>? Images { get; set; }

        [JsonPropertyName( "name" )]
        public string? Name { get; set; }

        [JsonPropertyName( "release_date" )]
        public string? ReleaseDate { get; set; }

        [JsonPropertyName( "release_date_precision" )]
        public string? ReleaseDatePrecision { get; set; }

        [JsonPropertyName( "restrictions" )]
        public SpotifyRestrictions? Restrictions { get; set; }

        [JsonPropertyName( "type" )]
        public string? Type { get; set; }

        [JsonPropertyName( "uri" )]
        public string? Uri { get; set; }

        [JsonPropertyName( "artists" )]
        public List<SpotifyArtist>? Artists { get; set; }
    }


    public class SpotifyTrack
    {
        [JsonPropertyName( "album" )]
        public SpotifyAlbum? Album { get; set; }

        [JsonPropertyName( "artists" )]
        public List<SpotifyArtist>? Artists { get; set; }

        [JsonPropertyName( "available_markets" )]
        public List<string>? AvailableMarkets { get; set; }

        [JsonPropertyName( "disc_number" )]
        public int? DiscNumber { get; set; }

        [JsonPropertyName( "duration_ms" )]
        public int? DurationMs { get; set; }

        [JsonPropertyName( "explicit" )]
        public bool? Explicit { get; set; }

        [JsonPropertyName( "external_ids" )]
        public Dictionary<string , string>? ExternalIds { get; set; }

        [JsonPropertyName( "external_urls" )]
        public SpotifyExternalUrls? ExternalUrls { get; set; }

        [JsonPropertyName( "href" )]
        public string? Href { get; set; }

        [JsonPropertyName( "id" )]
        public string? Id { get; set; }

        [JsonPropertyName( "is_local" )]
        public bool? IsLocal { get; set; }

        [JsonPropertyName( "name" )]
        public string? Name { get; set; }

        [JsonPropertyName( "popularity" )]
        public int? Popularity { get; set; }

        [JsonPropertyName( "preview_url" )]
        public string? PreviewUrl { get; set; }

        [JsonPropertyName( "track_number" )]
        public int? TrackNumber { get; set; }

        [JsonPropertyName( "type" )]
        public string? Type { get; set; }

        [JsonPropertyName( "uri" )]
        public string? Uri { get; set; }
    }

    public static class Payload
    {
        public class SetPlayerCurrentPlayback
        {
            [JsonPropertyName( "device_ids" )]
            public required string[] DeviceIds { get; set; }

            [JsonPropertyName( "play" )]
            public bool? Play { get; set; }
        }
    }
}
