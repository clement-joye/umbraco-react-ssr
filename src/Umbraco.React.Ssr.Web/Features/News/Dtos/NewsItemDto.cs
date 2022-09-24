using Umbraco.React.Ssr.Application.Models;
using Umbraco.React.Ssr.Web.Features.Blocks.Dtos;

namespace Umbraco.React.Ssr.Web.Features.News.Dtos
{
    public class NewsItemDto: IMetadata
    {
        public string MetadataTitle { get; set; } = "";
        public string MetadataDescription { get; set; } = "";

        public int Id { get; set; } = -1;
        public string Url { get; set; } = "";
        public string Title { get; set; } = "";
        public string Intro { get; set; } = "";
        public string ImageSrc { get; set; } = "";
        public IEnumerable<string> Labels { get; set; } = Array.Empty<string>();
        public string Type { get; set; } = "newsItem";
        public IEnumerable<BlockDto>? Blocks { get; set; } = Array.Empty<BlockDto>();
    }
}
