using Microsoft.AspNetCore.Mvc;
using Umbraco.React.Ssr.Web.Controllers;
using Umbraco.React.Ssr.Web.Features.Page.Queries;

namespace Umbraco.React.Ssr.Web.Features.Page.Controllers
{
    public class PageController : ApiControllerBase
    {
        [HttpGet]
        public async Task<object?> Get([FromQuery] string path, CancellationToken cancellationToken)
        {
            var content = await Mediator.Send(new GetPageQuery(path), cancellationToken);
            return content;
        }
    }
}
