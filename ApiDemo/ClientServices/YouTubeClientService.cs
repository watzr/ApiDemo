namespace ClientServices
{
    using Microsoft.Extensions.Options;
    using ModelsLibrary.Configurations;
    using ModelsLibrary.YouTubeModels;
    using System.Text;

    public class YouTubeClientService : IYouTubeClientService
    {
        private readonly IBaseHttpClient _httpClient;

        private readonly IOptions<ApiConfiguration> _apiConfiguration;

        public YouTubeClientService(IHttpClientFactory httpClientFactory, IOptions<ApiConfiguration> apiConfiguration)
        {
            _httpClient = new BaseHttpClient(httpClientFactory.CreateClient("YouTubeApi"));
            _apiConfiguration = apiConfiguration;
        }

        public async Task<YouTubeChannel?> GetYouTubeChannelAsync(string query, string type, string part, string
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
                var resultAsJson = Newtonsoft.Json.JsonConvert.DeserializeObject<YouTubeChannel>(resultAsString);

                return resultAsJson;
            }

            return null;
        }
    }
}
