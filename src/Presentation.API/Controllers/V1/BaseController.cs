using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.API.Helpers.Models;

namespace Presentation.API.Controllers.V1
{
    [Authorize]
    public class BaseController : Controller
    {
        protected StatusCodeResult OkNoContent()
        {
            return StatusCode((int)HttpStatusCode.NoContent);
        }

        protected new OkObjectResult Ok(object value)
        {
            return base.Ok(new HttpSuccess(value));
        }
    }
}
