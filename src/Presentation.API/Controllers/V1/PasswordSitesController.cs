using System.Threading.Tasks;
using Core.V1.PasswordSites.CreatePasswordSite;
using Core.V1.PasswordSites.DeletePasswordSite;
using Core.V1.PasswordSites.GetPasswordSiteById;
using Core.V1.PasswordSites.UpdatePasswordSite;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.API.Controllers.V1
{
    [Route("v{version:apiVersion}/passwordsites")]
    [ApiVersion("1.0")]
    [ApiController]
    public class PasswordSitesController : BaseController
    {
        private readonly IMediator mediator;

        public PasswordSitesController(IMediator mediator)
        {
            this.mediator = mediator ?? throw new System.ArgumentNullException(nameof(mediator));
        }

        [Authorize]
        [HttpPost("create-passwordsite")]
        public async Task<ActionResult> CreatePasswordSite([FromBody] CreatePasswordSiteRequest request)
        {
            await mediator.Send(request);
            return OkNoContent();
        }

        [Authorize]
        [HttpPost("update-passwordsite")]
        public async Task<ActionResult> UpdatePasswordSite([FromBody] UpdatePasswordSiteRequest request)
        {
            await mediator.Send(request);
            return OkNoContent();
        }

        [Authorize]
        [HttpDelete("delete-passwordsite")]
        public async Task<ActionResult> DeletePasswordSite([FromQuery] DeletePasswordSiteRequest request)
        {
            await mediator.Send(request);
            return OkNoContent();
        }

        [Authorize]
        [HttpGet("get-passwordsite-byid")]
        public async Task<ActionResult> GetPasswordSiteById([FromQuery] GetPasswordSiteByIdRequest request)
        {
            await mediator.Send(request);
            return OkNoContent();
        }
    }
}
