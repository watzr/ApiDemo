namespace ClientServices
{
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Options;
    using ModelsLibrary;
    using ModelsLibrary.Configurations;
    using ModelsLibrary.YouTubeDtos;
    using ModelsLibrary.YouTubeModels;
    using System.Text;

    public class YouTubeClientService : IYouTubeClientService
    {
        private readonly IBaseHttpClient _httpClient;

        private readonly IOptions<ApiConfiguration> _apiConfiguration;

        private readonly IDbContext _dbContext;

        public readonly IMapper _mapper;

        public YouTubeClientService(IHttpClientFactory httpClientFactory, IOptions<ApiConfiguration> apiConfiguration, IDbContext dbContext, IMapper mapper)
        {
            _httpClient = new BaseHttpClient(httpClientFactory.CreateClient("YouTubeApi"));
            _apiConfiguration = apiConfiguration;
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<YouTubeChannelDto?> GetYouTubeChannelAsync(string query, string type, string part, string
            regionCode)
        {
            var stringBuilder = new StringBuilder($"key={_apiConfiguration.Value.Key}&q={query ?? string.Empty}&type={type ?? string.Empty}");

            if (!string.IsNullOrWhiteSpace(part))
            {
                stringBuilder.Append($"&part={part}");
            }

            if (!string.IsNullOrWhiteSpace(regionCode))
            {
                stringBuilder.Append($"&regionCode={regionCode}");
            }

            var response = await _httpClient.GetAsync($"search?&{stringBuilder}&part={part}&regionCode={regionCode}");

            if (response != null && response.IsSuccessStatusCode)
            {
                var resultAsString = await response.Content.ReadAsStringAsync();
                var resultAsJson = Newtonsoft.Json.JsonConvert.DeserializeObject<YouTubeChannelDto>(resultAsString);

                return resultAsJson;
            }

            return null;
        }

        public async Task<string> SetYouTubeChannelAsync(string query, string type, string part, string
            regionCode)
        {
            var data = await GetYouTubeChannelAsync(query, type, part, regionCode).ConfigureAwait(false);
            
            string response;

            if (data != null)
            {
                var channel = _mapper.Map<YouTubeChannel>(data);
                await _dbContext.DbContext.AddAsync(channel).ConfigureAwait(false);
                await _dbContext.DbContext.SaveChangesAsync().ConfigureAwait(false);

                response = "Saved data successfully.";
            }
            else
            {
                response = "No data found";
            }

            return response;
        }
    }
}
