using AutoMapper;
using Umbraco.React.Ssr.Web.Features.Blocks.Dtos;
using Umbraco.React.Ssr.Web.Features.Blocks.Extensions;
using Umbraco.React.Ssr.Web.Features.News.Dtos;
using ContentModels = Umbraco.Cms.Web.Common.PublishedModels;

namespace Umbraco.React.Ssr.Web.Features.News.Extensions
{
    public static class NewsItemExtensions
    {
        public static NewsItemDto GetNewsItem(this ContentModels.NewsItem content, IMapper mapper)
        {
            var newsItem = new NewsItemDto
            {
                Id = content.Id,
                Title = content?.Title ?? "",
                Intro = content?.Intro ?? "",
                Url = content?.Url() ?? "",
                ImageSrc = content?.Image?.Url() ?? "",
                Labels = content?.Labels?.ToArray() ?? Array.Empty<string>(),
                Blocks = content?.Blocks.GetBlocks(mapper) ?? Array.Empty<BlockDto>()
            };

            return newsItem;
        }
    }
}
