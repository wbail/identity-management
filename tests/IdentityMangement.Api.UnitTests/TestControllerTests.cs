using System.Net;
using IdentityManagementPoc.Api;
using Microsoft.AspNetCore.Mvc;

namespace IdentityMangement.Api.UnitTests;

public class TestControllerTests
{
    public TestControllerTests()
    {
        _testsController = new TestsController();
    }

    private readonly TestsController _testsController;

    [Fact]
    public void Tests_Get_Returns200OK()
    {
        // arrange
        var expected = "test";

        // act
        var actionResult = _testsController.Get();

        var result = actionResult.Result as OkObjectResult;

        // assert
        Assert.Equal((int)HttpStatusCode.OK, result?.StatusCode);
        Assert.Equal(expected, result?.Value);
    }
}