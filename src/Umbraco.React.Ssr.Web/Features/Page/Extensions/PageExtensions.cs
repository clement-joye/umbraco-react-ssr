using AutoMapper;
using Umbraco.React.Ssr.Web.Features.Blocks.Extensions;
using Umbraco.React.Ssr.Web.Features.Page.Dtos;
using ContentModels = Umbraco.Cms.Web.Common.PublishedModels;

namespace Umbraco.React.Ssr.Web.Features.Page.Extensions
{
    public static class BasePageExtensions
    {
        public static PageDto GetPage(this ContentModels.Page content, IMapper mapper)
        {
            var page = new PageDto
            {
                Id = content.Id,
                Sections = content.Sections.GetSections(mapper),
                MetadataTitle = content.MetadataTitle ?? "",
                MetadataDescription = content.MetadataDescription ?? ""
            };

            return page;
        }
    }
}
