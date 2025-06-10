using Microsoft.AspNetCore.Mvc;

namespace CMMSAPP.Common.Api;

[Route("api/v{version:apiVersion}/[controller]")]
public abstract class BaseApiControllerWithDefaultRoute : BaseApiController
{
}
