namespace GoogleApiDemo.Controllers
{
    using ClientServices;
    using Microsoft.AspNetCore.Mvc;
    using ModelsLibrary.YouTubeDtos;
    using ModelsLibrary.YouTubeDtos.Request;

    public class YouTubeApiController : Controller
    {
        private readonly IYouTubeClientService _youTubeClientService;

        public YouTubeApiController(IYouTubeClientService youTubeClientService)
        {
            _youTubeClientService = youTubeClientService;
        }

        [HttpGet("GetYouTubeChannel")]
        public async Task<YouTubeChannelDto?> GetYouTubeChannelAsync(GetYouTubeChannelRequestDto request)
        {
            var response = await _youTubeClientService.GetYouTubeChannelAsync(request.Query, request.Type, request.Part, request.RegionCode);

            return response;
        }

        [HttpPost("SetYouTubeChannel")]
        public async Task<string?> SetYouTubeChannelAsync(SetYouTubeChannelRequestDto request)
        {
            var response = await _youTubeClientService.SetYouTubeChannelAsync(request.Query, request.Type, request.Part, request.RegionCode);

            return response;
        }
    }
}
