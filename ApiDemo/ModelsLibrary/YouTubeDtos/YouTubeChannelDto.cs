namespace ModelsLibrary.YouTubeDtos
{
    public class YouTubeChannelDto
    {
        public string Kind { get; set; } = null!;

        public string ETag { get; set; } = null!;

        public string NextPageToken { get; set; } = null!;

        public string RegionCode { get; set; } = null!;

        public PageInfoDto PageInfo { get; set; } = null!;

        public IList<ItemDto> Items { get; set; } = null!;
    }
}
