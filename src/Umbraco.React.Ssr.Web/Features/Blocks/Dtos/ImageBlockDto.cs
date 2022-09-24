using Umbraco.React.Ssr.Application.Mappings;
using ContentModels = Umbraco.Cms.Web.Common.PublishedModels;

namespace Umbraco.React.Ssr.Web.Features.Blocks.Dtos
{
    public class ImageBlockDto : BlockDto, IMapFrom<ContentModels.ImageBlock>
    {
        public string Type { get; set; } = "image";
        public string Fit { get; set; } = "";
        public string ImageSrc { get; set; } = "";
        public string ImageAlt { get; set; } = "";
    }
}
