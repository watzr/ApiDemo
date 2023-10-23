namespace ModelsLibrary.YouTubeModels
{
    public class CustomDbContext : IDbContext
    {
        public YouTubeAnalyzerContext DbContext { get; } = null!;

        public CustomDbContext(YouTubeAnalyzerContext context)
        {
            DbContext = context;
        }
    }
}
