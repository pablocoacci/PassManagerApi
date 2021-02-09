using System.Threading.Tasks;
using Core.Data;
using Core.V1.PasswordSites.CreatePasswordSite;
using Core.V1.PasswordSites.DeletePasswordSite;
using Core.V1.PasswordSites.GetPasswordSiteById;
using Core.V1.PasswordSites.GetPasswordSiteById.Models;
using Core.V1.PasswordSites.GetPasswordSiteList;
using Core.V1.PasswordSites.GetPasswordSiteList.Models;
using Core.V1.PasswordSites.UpdatePasswordSite;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.API.Helpers.Extensions;

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
            request.SetUserName(User.UserName());
            await mediator.Send(request);
            return OkNoContent();
        }

        [Authorize]
        [HttpPost("update-passwordsite")]
        public async Task<ActionResult> UpdatePasswordSite([FromBody] UpdatePasswordSiteRequest request)
        {
            request.SetUserName(User.UserName());
            await mediator.Send(request);
            return OkNoContent();
        }

        [Authorize]
        [HttpDelete("delete-passwordsite")]
        public async Task<ActionResult> DeletePasswordSite([FromQuery] DeletePasswordSiteRequest request)
        {
            request.SetUserName(User.UserName());
            await mediator.Send(request);
            return OkNoContent();
        }

        [Authorize]
        [HttpGet("get-passwordsite-byid")]
        public async Task<ActionResult<DetailPasswordSiteModel>> GetPasswordSiteById([FromQuery] GetPasswordSiteByIdRequest request)
        {
            request.SetUserName(User.UserName());
            var passDetail = await mediator.Send(request);
            return Ok(passDetail);
        }

        [Authorize]
        [HttpPost("get-passwordsite-list")]
        public async Task<ActionResult<PagedResults<PasswordSiteModel>>> GetPasswordSiteList([FromBody] GetPasswordSiteListRequest request)
        {
            request.SetUserName(User.UserName());
            var result = await mediator.Send(request);
            return Ok(result);
        }
    }
}
