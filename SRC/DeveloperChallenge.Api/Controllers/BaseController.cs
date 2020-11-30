using Microsoft.AspNetCore.Mvc;

namespace DeveloperChallenge.Api.Controllers
{
    public class BaseController : ControllerBase
    {
        protected string RequestUri => $"{Request.Scheme}://{Request.Host.Host}:{Request.Host.Port}{Request.PathBase}";
    }
}