namespace ClientServices
{
    public interface IBaseHttpClient
    {
        Task<HttpResponseMessage?> GetAsync(string requestUri);
    }
}
