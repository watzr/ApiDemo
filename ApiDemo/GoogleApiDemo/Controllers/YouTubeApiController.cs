namespace GoogleApiDemo.Controllers
{
    using ClientServices;
    using Microsoft.AspNetCore.Mvc;
    using ModelsLibrary.YouTubeDtos;

    public class YouTubeApiController : Controller
    {
        private readonly IYouTubeClientService _youTubeClientService;

        public YouTubeApiController(IYouTubeClientService youTubeClientService)
        {
            _youTubeClientService = youTubeClientService;
        }

        [HttpGet("GetYouTubeChannel")]
        public async Task<YouTubeChannelDto?> GetYouTubeChannelAsync()
        {
            var response = await _youTubeClientService.GetYouTubeChannelAsync("low carb", "video", "snippet", "LK");

            return response;
        }

        [HttpGet("SetYouTubeChannel")]
        public async Task<string?> SetYouTubeChannelAsync()
        {
            var response = await _youTubeClientService.SetYouTubeChannelAsync("low carb", "video", "snippet", "LK");

            return response;
        }
    }
}
