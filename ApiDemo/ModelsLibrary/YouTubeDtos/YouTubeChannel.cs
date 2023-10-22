namespace ModelsLibrary.YouTubeDtos
{
    public class YouTubeChannel
    {
        public string? Kind { get; set; }

        public string? ETag { get; set; }

        public string? NextPageToken { get; set; }

        public string? RegionCode { get; set; }

        public PageInfo? PageInfo { get; set; }

        public IList<Item>? Items { get; set; }
    }
}
