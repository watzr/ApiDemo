namespace ModelsLibrary.YouTubeDtos
{
    public class ItemDto
    {
        public string Kind { get; set; } = null!;

        public string ETag { get; set; } = null!;

        public IdDto Id { get; set; } = null!;

        public Snippet Snippet { get; set; } = null!;
    }
}
