using Microsoft.AspNetCore.Mvc;

namespace IdentityManagementPoc.Api;

[ApiController]
[Route("api/[controller]")]
public class TestController : ControllerBase
{
    [HttpGet]
    public ActionResult<string> Get()
    {
        return "test";
    }
}
