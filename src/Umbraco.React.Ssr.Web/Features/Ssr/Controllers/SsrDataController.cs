using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Umbraco.Cms.Core.Web;
using Umbraco.React.Ssr.Web.Controllers;
using Umbraco.React.Ssr.Web.Features.Ssr.Queries;

namespace Umbraco.React.Ssr.Web.Features.Ssr.Controllers
{
    public class SsrDataController : RenderControllerBase
    {
        public SsrDataController(
            ILogger<SsrDataController> logger,
            ICompositeViewEngine compositeViewEngine,
            IUmbracoContextAccessor umbracoContextAccessor) : base(logger, compositeViewEngine, umbracoContextAccessor)
        {
        }

        [NonAction]
        public sealed override IActionResult Index() => throw new NotImplementedException();

        public async Task<IActionResult> IndexAsync()
        {
            if (CurrentPage == null)
            {
                return CurrentTemplate(CurrentPage);
            }

            var content = await Mediator.Send(new GetSsrDataQuery(CurrentPage));

            return CurrentTemplate(content);
        }
    }
}
