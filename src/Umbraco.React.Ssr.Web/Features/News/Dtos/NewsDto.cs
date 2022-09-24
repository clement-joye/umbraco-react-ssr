namespace Umbraco.React.Ssr.Web.Features.News.Dtos
{
    public class NewsDto
    {
        public IEnumerable<NewsItemDto> Items { get; set; } = Array.Empty<NewsItemDto>();
    }
}
