namespace ClientServices
{
    using ModelsLibrary.YouTubeDtos;

    public interface IYouTubeClientService
    {
        Task<YouTubeChannelDto?> GetYouTubeChannelAsync(string query, string type, string part, string
            regionCode);

        Task<string> SetYouTubeChannelAsync(string query, string type, string part, string
            regionCode);
    }
}
