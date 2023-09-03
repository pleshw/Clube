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

        public bool IsValid()
        {
            return Audio != null || Video != null;
        }

        public bool IsAudioOnly()
        {
            return Audio != null && Video == null;
        }


        public bool IsVideoOnly()
        {
            return Audio == null && Video != null;
        }
    }

    public class YoutubeDownloaderService
    {
        public static readonly YoutubeClient youtubeClientInstance = new YoutubeClient();
        private readonly IProgress<double> _progressTracker;

        public YoutubeDownloaderService( IProgress<double> progressTracker )
        {
            _progressTracker = progressTracker;
        }

        public async Task<string> GetVideoThumbnail( string videoUrl )
        {
            YoutubeExplode.Videos.Video videoMetadata = await youtubeClientInstance.Videos.GetAsync( videoUrl );
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

            Regex regexOnlyLetters = new Regex( @"[^a-zA-Z]" );
            if (videoStreams.IsValid())
            {
                var streamInfos = new IStreamInfo[] { videoStreams.Audio , videoStreams.Video };
                var videoConverter = new ConversionRequestBuilder( $"YoutubeVideos/{regexOnlyLetters.Replace( videoTitle , "" )}.mp4" ).Build();
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
