using YoutubeExplode;
using YoutubeExplode.Videos.Streams;
using YoutubeExplode.Converter;
using YoutubeExplode.Common;
using System.Text.RegularExpressions;

namespace Clube.Data
{
    public struct VideoStreams
    {
        public IStreamInfo Audio;
        public IVideoStreamInfo Video;

        public readonly bool IsValid()
        {
            return Audio != null || Video != null;
        }

        public readonly bool IsAudioOnly()
        {
            return Audio != null && Video == null;
        }


        public readonly bool IsVideoOnly()
        {
            return Audio == null && Video != null;
        }
    }

    public partial class YoutubeDownloaderService
    {
        public static readonly YoutubeClient youtubeClientInstance = new();

        [GeneratedRegexAttribute( "^((?:https?:)?\\/\\/)?((?:www|m)\\.)?((?:youtube(-nocookie)?\\.com|youtu.be))(\\/(?:[\\w\\-]+\\?v=|embed\\/|live\\/|v\\/)?)([\\w\\-]+)(\\S+)?$" , RegexOptions.IgnoreCase )]
        private static partial Regex _regexYoutubeVideoUrl();

        [GeneratedRegexAttribute( "[^a-zA-Z]" , RegexOptions.IgnoreCase )]
        private static partial Regex _regexOnlyLetters();

        private readonly IProgress<double> _progressTracker;

        public YoutubeDownloaderService( IProgress<double> progressTracker )
        {
            _progressTracker = progressTracker;
        }


        public static bool IsValidURL(string videoUrl )
        {
            return _regexYoutubeVideoUrl().Match( videoUrl ).Success;
        }

        public async Task<YoutubeExplode.Videos.Video> GetVideoMetadata( string videoUrl )
        {
            return await youtubeClientInstance.Videos.GetAsync( videoUrl );
        }

        public async Task<string> GetVideoThumbnail( string videoUrl )
        {
            YoutubeExplode.Videos.Video videoMetadata = await GetVideoMetadata( videoUrl );
            string thumbnailURL = videoMetadata.Thumbnails.GetWithHighestResolution().Url;
            return thumbnailURL;
        }

        public async Task GetVideoAsync( string videoUrl )
        {
            // Get stream manifest
            StreamManifest streamManifest = await youtubeClientInstance.Videos.Streams.GetManifestAsync( videoUrl );

            var videoStreams = GetBestAudioVideoStream(streamManifest);

            YoutubeExplode.Videos.Video videoMetadata = await youtubeClientInstance.Videos.GetAsync( videoUrl );
            string videoTitle = videoMetadata.Title;
            if (videoStreams.IsValid())
            {
                var streamInfos = new IStreamInfo[] { videoStreams.Audio , videoStreams.Video };
                var videoConverter = new ConversionRequestBuilder( $"YoutubeVideos/{_regexOnlyLetters().Replace( videoTitle , "" )}.mp4" ).Build();
                await youtubeClientInstance.Videos
                    .DownloadAsync(
                        streamInfos ,
                        videoConverter,
                        progress: _progressTracker
                    );
            }
        }

        public VideoStreams GetBestAudioVideoStream( StreamManifest streamManifest )
        {
            IStreamInfo audioStreamInfo = streamManifest
                .GetAudioStreams()
                .Where( s => s.Container == Container.Mp4 || s.Container == Container.Mp3 )
                .GetWithHighestBitrate();

            IVideoStreamInfo videoStreamInfo = streamManifest
                .GetVideoStreams()
                .Where( s => s.Container == Container.Mp4 || s.Container == Container.WebM )
                .GetWithHighestVideoQuality();

            return new VideoStreams
            {
                Audio = audioStreamInfo ,
                Video = videoStreamInfo
            };
        }
    }
}
