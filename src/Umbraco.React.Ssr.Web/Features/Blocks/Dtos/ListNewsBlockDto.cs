using Umbraco.React.Ssr.Application.Mappings;
using ContentModels = Umbraco.Cms.Web.Common.PublishedModels;

namespace Umbraco.React.Ssr.Web.Features.Blocks.Dtos
{
    public class ListNewsBlockDto : BlockDto, IMapFrom<ContentModels.ListNewsBlock>
    {
        public string Type { get; set; } = "listNews";
        public string BackgroundColor { get; set; } = "";
        public string Display { get; set; } = "";
        public string DefaultNumber { get; set; } = "";
        public string ShowDate { get; set; } = "";
        public string ShowLabel { get; set; } = "";
        public string ShowIntro { get; set; } = "";
        public string ShowLink { get; set; } = "";

        public string Title { get; set; } = "";
        public string TextColor { get; set; } = "";
    }
}
