namespace ModelsLibrary.YouTubeDtos.Request
{
    public class GetYouTubeChannelRequestDto
    {
        public string Query { get; set; } = null!;

        public string Type { get; set; } = null!;

        public string Part { get; set; } = null!;

        public string RegionCode { get; set; } = null!;
    }
}
