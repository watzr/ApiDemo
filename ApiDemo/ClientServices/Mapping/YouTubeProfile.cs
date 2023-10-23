namespace ClientServices.Mapping
{
    using AutoMapper;
    using ModelsLibrary.YouTubeDtos;
    using ModelsLibrary.YouTubeModels;

    public class YouTubeProfile : Profile
    {
        public YouTubeProfile()
        {
            CreateMap<YouTubeChannelDto, YouTubeChannel>()
                .ForMember(destination => destination.Id, option => option.Ignore())
                .ForMember(destination => destination.TotalResults, option => option.MapFrom(source => source.PageInfo.TotalResults))
                .ForMember(destination => destination.ResultsPerPage, option => option.MapFrom(source => source.PageInfo.ResultsPerPage));
            //.ForMember(destination => destination.Items, option => option.MapFrom(source => source.Items)).ReverseMap();

            CreateMap<ItemDto, Item>()
                .ForMember(destination => destination.Id, option => option.Ignore())
                .ForMember(destination => destination.SnippetChannelId, option => option.MapFrom(source => source.Snippet.ChannelId))
                .ForMember(destination => destination.SnippetTitle, option => option.MapFrom(source => source.Snippet.Title))
                .ForMember(destination => destination.SnippetDescription, option => option.MapFrom(source => source.Snippet.Description))
                .ForMember(destination => destination.SnippetChannelTitle, option => option.MapFrom(source => source.Snippet.ChannelTitle))
                .ForMember(destination => destination.SnippetPublishTime, option => option.MapFrom(source => source.Snippet.PublishTime));
        }
    }
}
