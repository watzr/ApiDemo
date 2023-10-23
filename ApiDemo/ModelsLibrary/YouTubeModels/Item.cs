namespace ModelsLibrary.YouTubeModels;

public partial class Item
{
    public int Id { get; set; }

    public string Kind { get; set; } = null!;

    public string Etag { get; set; } = null!;

    public int? YouTubeChannelId { get; set; }

    public string SnippetChannelId { get; set; } = null!;

    public string SnippetTitle { get; set; } = null!;

    public string SnippetDescription { get; set; } = null!;

    public string SnippetChannelTitle { get; set; } = null!;

    public DateTime SnippetPublishTime { get; set; }

    public virtual YouTubeChannel YouTubeChannel { get; set; } = null!;
}
