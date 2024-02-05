using Microsoft.AspNetCore.Mvc;

namespace IdentityManagementPoc.Api;

[ApiController]
[Route("api/[controller]")]
public class TestsController : ControllerBase
{
    [HttpGet]
    public ActionResult<string> Get()
    {
        return Ok("test");
    }
}
