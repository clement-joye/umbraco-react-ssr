using MediatR;
using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Web.Common.Controllers;

namespace Umbraco.React.Ssr.Web.Controllers;

[Route("api/[controller]")]
public abstract class ApiControllerBase : UmbracoApiController
{
    private ISender _mediator = null!;

    protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();
}
