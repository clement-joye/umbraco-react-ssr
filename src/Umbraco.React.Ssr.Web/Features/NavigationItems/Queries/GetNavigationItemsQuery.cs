using MediatR;
using Umbraco.React.Ssr.Web.Features.NavigationItems.Dtos;
using Umbraco.Cms.Core.Web;
using ContentModels = Umbraco.Cms.Web.Common.PublishedModels;

namespace Umbraco.React.Ssr.Web.Features.NavigationItems.Queries;

public record GetNavigationItemsQuery() : IRequest<NavigationItemsDto>;

public class GetNavigationItemsQueryHandler : RequestHandler<GetNavigationItemsQuery, NavigationItemsDto>
{
    private readonly IUmbracoContextFactory _contextFactory;

    public GetNavigationItemsQueryHandler(IUmbracoContextFactory contextFactory)
    {
        _contextFactory = contextFactory;
    }

    protected override NavigationItemsDto Handle(GetNavigationItemsQuery request)
    {
        var context = _contextFactory.EnsureUmbracoContext().UmbracoContext;


        if (context?.Content?.GetAtRoot()?
                .FirstOrDefault(x => x.ContentType.Alias == "navigation") is not ContentModels.Navigation navigationItems
                || navigationItems.Items == null
                || navigationItems.Items?.Count == 0)
        {
            return new NavigationItemsDto();

        }

        var items = navigationItems?
            .Items?.Select(x => x.Content)
            .Cast<ContentModels.NavigationItem>()
            .Select(x => new NavigationItemDto { 
                Text = x.Text ?? "",
                IsVisible = x.IsVisible,
                Link =  x.Link?.Url() ?? ""
            });


        return new NavigationItemsDto
        {
            Items = items ?? new List<NavigationItemDto>(),
        };
    }
}
