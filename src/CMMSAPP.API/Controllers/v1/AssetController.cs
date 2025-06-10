using CMMSAPP.Common.Api;
using Microsoft.AspNetCore.Mvc;

namespace CMMSAPP.API.Controllers.v1;

public class AssetController : BaseApiControllerWithDefaultRoute
{
    [HttpGet]
    public ApiResult GetName()
    {
        return Ok();
    }
}
