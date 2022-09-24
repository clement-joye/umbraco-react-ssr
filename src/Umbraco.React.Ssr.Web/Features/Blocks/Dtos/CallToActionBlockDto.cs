using Umbraco.React.Ssr.Application.Mappings;
using ContentModels = Umbraco.Cms.Web.Common.PublishedModels;

namespace Umbraco.React.Ssr.Web.Features.Blocks.Dtos
{
    public class CallToActionBlockDto : BlockDto, IMapFrom<ContentModels.CallToActionBlock>
    {
        public string Type { get; set; } = "callToAction";
        public string Title { get; set; } = "";
        public string TitleColor { get; set; } = "";
        public string BackgroundColor { get; set; } = "";
        public string ButtonColor { get; set; } = "";
        public string ButtonText { get; set; } = "";
        public string ButtonTextColor { get; set; } = "";
        public string ButtonLink { get; set; } = "";
        public string Text { get; set; } = "";
        public string TextColor { get; set; } = "";
    }
}
