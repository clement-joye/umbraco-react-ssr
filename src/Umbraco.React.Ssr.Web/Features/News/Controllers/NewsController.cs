using Microsoft.AspNetCore.Mvc;
using Umbraco.React.Ssr.Web.Controllers;
using Umbraco.React.Ssr.Web.Features.News.Dtos;
using Umbraco.React.Ssr.Web.Features.News.Queries;

namespace Umbraco.React.Ssr.Web.Features.News.Controllers
{
    public class NewsController : ApiControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<NewsItemDto>> Get([FromQuery] int id, CancellationToken cancellationToken)
        {
            var content = await Mediator.Send(new GetNewsQuery(id), cancellationToken);
            return content;
        }
    }
}
