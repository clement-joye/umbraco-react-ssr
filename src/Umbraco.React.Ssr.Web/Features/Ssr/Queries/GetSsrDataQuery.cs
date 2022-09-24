using AutoMapper;
using MediatR;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Web;
using Umbraco.React.Ssr.Web.Extensions;
using Umbraco.React.Ssr.Web.Features.News.Extensions;
using Umbraco.React.Ssr.Web.Features.Page.Extensions;
using ContentModels = Umbraco.Cms.Web.Common.PublishedModels;

namespace Umbraco.React.Ssr.Web.Features.Ssr.Queries;

public record GetSsrDataQuery(IPublishedContent Content) : IRequest<object?>;

public class GetIndexQueryHandler : RequestHandler<GetSsrDataQuery, object?>
{
    private readonly IMapper _mapper;
    private readonly IUmbracoContextFactory _contextFactory;

    public GetIndexQueryHandler(IMapper mapper, IUmbracoContextFactory contextFactory)
    {
        _contextFactory = contextFactory;
        _mapper = mapper;
    }

    protected override object? Handle(GetSsrDataQuery request)
    {
        var content = request.Content;

        if (content == null)
        {
            return null;
        }

        return content.ContentType.Alias.ToPascalCase() switch
        {
            nameof(ContentModels.Page) => (content as ContentModels.Page)?.GetPage(_mapper),
            nameof(ContentModels.NewsItem) => (content as ContentModels.NewsItem)?.GetNewsItem(_mapper),
            _ => null
        };
    }
}

