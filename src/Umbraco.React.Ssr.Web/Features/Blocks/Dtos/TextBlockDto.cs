using Umbraco.React.Ssr.Application.Mappings;
using ContentModels = Umbraco.Cms.Web.Common.PublishedModels;

namespace Umbraco.React.Ssr.Web.Features.Blocks.Dtos
{
    public class TextBlockDto : BlockDto, IMapFrom<ContentModels.TextBlock>
    {
        public string Type { get; set; } = "text";
        public string Text { get; set; } = "";
        public string TextColor { get; set; } = "";
    }
}
