using Microsoft.AspNetCore.Mvc;
using Umbraco.React.Ssr.Web.Controllers;
using Umbraco.React.Ssr.Web.Features.NavigationItems.Dtos;
using Umbraco.React.Ssr.Web.Features.NavigationItems.Queries;

namespace Umbraco.React.Ssr.Web.Features.NavigationItems.Controllers
{
    public class NavigationItemsController : ApiControllerBase
    {
        [HttpGet]
        public async Task<NavigationItemsDto> Get()
        {
            var content = await Mediator.Send(new GetNavigationItemsQuery());
            return content;
        }
    }
}
