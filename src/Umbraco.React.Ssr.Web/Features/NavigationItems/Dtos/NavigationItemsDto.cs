namespace Umbraco.React.Ssr.Web.Features.NavigationItems.Dtos
{
    public class NavigationItemsDto
    {
        public IEnumerable<NavigationItemDto> Items { get; set; } = new List<NavigationItemDto>();
    }
}
