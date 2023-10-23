namespace ModelsLibrary.YouTubeModels;

public partial class YouTubeChannel
{
    public int Id { get; set; }

    public string Kind { get; set; } = null!;

    public string Etag { get; set; } = null!;

    public string RegionCode { get; set; } = null!;

    public int? TotalResults { get; set; }

    public int? ResultsPerPage { get; set; }

    public virtual ICollection<Item> Items { get; set; } = new List<Item>();
}
