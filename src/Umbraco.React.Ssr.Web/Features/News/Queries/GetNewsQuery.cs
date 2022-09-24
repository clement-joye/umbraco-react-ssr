using MediatR;
using Umbraco.React.Ssr.Web.Features.News.Dtos;
using Umbraco.Cms.Core.Web;
using ContentModels = Umbraco.Cms.Web.Common.PublishedModels;

namespace Umbraco.React.Ssr.Web.Features.News.Queries;

public record GetNewsQuery(int Id) : IRequest<IEnumerable<NewsItemDto>>;

public class GetNewsQueryHandler : RequestHandler<GetNewsQuery, IEnumerable<NewsItemDto>>
{
    private readonly IUmbracoContextFactory _contextFactory;

    public GetNewsQueryHandler(IUmbracoContextFactory contextFactory)
    {
        _contextFactory = contextFactory;
    }

    protected override IEnumerable<NewsItemDto> Handle(GetNewsQuery request)
    {
        var context = _contextFactory.EnsureUmbracoContext().UmbracoContext;


        if (context?.Content?.GetAtRoot()?
                .FirstOrDefault(x =>
                    x.ContentType.Alias.InvariantEquals(
                        nameof(ContentModels.News))) is not ContentModels.News collection)
        {
            return Array.Empty<NewsItemDto>();
        }

        return collection.Children?
            .Cast<ContentModels.NewsItem>()
            .Select(x => new NewsItemDto
            {
                Id = x?.Id ?? -1,
                Title = x?.Title ?? "",
                Intro = x?.Intro ?? "",
                Url = x?.Url() ?? "",
                ImageSrc = x?.Image?.Url() ?? "",
                Labels = x?.Labels ?? Array.Empty<string>()
            }) ?? Array.Empty<NewsItemDto>();
    }
}

