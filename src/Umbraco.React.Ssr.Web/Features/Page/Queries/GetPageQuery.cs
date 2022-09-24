using AutoMapper;
using MediatR;
using Umbraco.Cms.Core.Web;
using ContentModels = Umbraco.Cms.Web.Common.PublishedModels;
using Umbraco.React.Ssr.Web.Extensions;
using Umbraco.React.Ssr.Web.Features.News.Extensions;
using Umbraco.React.Ssr.Web.Features.Page.Extensions;

namespace Umbraco.React.Ssr.Web.Features.Page.Queries;

public record GetPageQuery(string Path) : IRequest<object?>;

public class GetPageQueryHandler : RequestHandler<GetPageQuery, object?>
{
    private readonly IMapper _mapper;
    private readonly IUmbracoContextFactory _contextFactory;

    public GetPageQueryHandler(IMapper mapper, IUmbracoContextFactory contextFactory)
    {
        _contextFactory = contextFactory;
        _mapper = mapper;
    }

    protected override object? Handle(GetPageQuery request)
    {
        var context = _contextFactory.EnsureUmbracoContext().UmbracoContext;

        var content = context?.Content?.GetByRoute(!string.IsNullOrEmpty(request.Path) ? request.Path : "/");

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

