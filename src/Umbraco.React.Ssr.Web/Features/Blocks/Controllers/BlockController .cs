using Microsoft.AspNetCore.Mvc;
using Umbraco.React.Ssr.Web.Controllers;
using Umbraco.React.Ssr.Web.Features.Blocks.Dtos;

namespace Umbraco.React.Ssr.Web.Features.Blocks.Controllers
{
    public class BlockController : ApiControllerBase
    {
        [Route("text")]
        [HttpGet]
        public TextBlockDto Text()
        {
            return new TextBlockDto();
        }

        [Route("image")]
        [HttpGet]
        public ImageBlockDto Image()
        {
            return new ImageBlockDto();
        }

        [Route("callToAction")]
        [HttpGet]
        public CallToActionBlockDto CallToAction()
        {
            return new CallToActionBlockDto();
        }
    }
}
