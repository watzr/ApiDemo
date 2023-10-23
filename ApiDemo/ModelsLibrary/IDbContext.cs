namespace ModelsLibrary
{
    using ModelsLibrary.YouTubeModels;

    public interface IDbContext
    {
        YouTubeAnalyzerContext DbContext { get; }
    }
}