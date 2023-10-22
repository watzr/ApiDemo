namespace ClientServices
{
    using ModelsLibrary.YouTubeDtos;

    public interface IYouTubeClientService
    {
        Task<YouTubeChannel?> GetYouTubeChannelAsync(string query, string type, string part, string
            regionCode);
    }
}
