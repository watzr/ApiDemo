namespace ClientServices
{
    using ModelsLibrary.YouTubeModels;

    public interface IYouTubeClientService
    {
        Task<YouTubeChannel?> GetYouTubeChannelAsync(string query, string type, string part, string
            regionCode);
    }
}
