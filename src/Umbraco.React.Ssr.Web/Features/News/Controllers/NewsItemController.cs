using Microsoft.AspNetCore.Mvc;
using Umbraco.React.Ssr.Web.Controllers;
using Umbraco.React.Ssr.Web.Features.News.Dtos;
using Umbraco.React.Ssr.Web.Features.News.Queries;

namespace Umbraco.React.Ssr.Web.Features.News.Controllers
{
    public class NewsItemController : ApiControllerBase
    {
        [HttpGet]
        public async Task<NewsItemDto> Get([FromQuery] int id, CancellationToken cancellationToken)
        {
            var content = await Mediator.Send(new GetNewsItemQuery(id), cancellationToken);
            return content;
        }
    }
}
