namespace ClientServices
{
    public class BaseHttpClient : IBaseHttpClient
    {
        private readonly HttpClient _httpClient;

        public BaseHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage?> GetAsync(string requestUri)
        {
            if (_httpClient != null && _httpClient.BaseAddress != null)
            {
                var uri = new Uri(Path.Combine(_httpClient.BaseAddress.AbsoluteUri, requestUri));
                var response = await _httpClient.GetAsync(uri).ConfigureAwait(false);

                return response;
            }

            return null;
        }
    }
}
