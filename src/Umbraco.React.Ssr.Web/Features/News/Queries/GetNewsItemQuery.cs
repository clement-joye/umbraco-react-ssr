using AutoMapper;
using MediatR;
using Umbraco.React.Ssr.Web.Features.News.Dtos;
using Umbraco.Cms.Core.Web;
using ContentModels = Umbraco.Cms.Web.Common.PublishedModels;
using Umbraco.React.Ssr.Web.Features.News.Extensions;

namespace Umbraco.React.Ssr.Web.Features.News.Queries;

public record GetNewsItemQuery(int Id) : IRequest<NewsItemDto>;

public class GetNewsItemQueryHandler : RequestHandler<GetNewsItemQuery, NewsItemDto>
{
    private readonly IMapper _mapper;
    private readonly IUmbracoContextFactory _contextFactory;

    public GetNewsItemQueryHandler(IMapper mapper, IUmbracoContextFactory contextFactory)
    {
        _contextFactory = contextFactory;
        _mapper = mapper;
    }

    protected override NewsItemDto Handle(GetNewsItemQuery request)
    {
        var context = _contextFactory.EnsureUmbracoContext().UmbracoContext;

        if (context?.Content?.GetAtRoot()?
                .FirstOrDefault(x =>
                    x.ContentType.Alias.InvariantEquals(
                        nameof(ContentModels.News))) is not ContentModels.News collection || 
                        collection.Children == null)
        {
            return new NewsItemDto();
        }

        var newsItem = collection.Children
            .Cast<ContentModels.NewsItem>()
            .FirstOrDefault(x => x.Id == request.Id);

        if(newsItem == null)
        {
            return new NewsItemDto();
        }

        return newsItem.GetNewsItem(_mapper);
    }
}

