using Umbraco.React.Ssr.Application.Models;
using Umbraco.React.Ssr.Web.Features.Blocks.Dtos;

namespace Umbraco.React.Ssr.Web.Features.Page.Dtos
{
    public class PageDto: IMetadata
    {
        public string MetadataTitle { get; set; } = "";
        public string MetadataDescription { get; set; } = "";

        public int Id { get; set; } = -1;
        public string Type { get; set; } = "page";
        public IEnumerable<SectionDto>? Sections { get; set; } = Array.Empty<SectionDto>();
    }
}
