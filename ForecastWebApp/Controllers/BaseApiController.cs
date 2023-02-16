using ForecastCore.Shared;
using Microsoft.AspNetCore.Mvc;

namespace ForecastWebAppAngular.Controllers;

[ApiController]
[Route("[controller]")]
public class BaseApiController : ControllerBase
{
    private readonly ILogger<BaseApiController> _logger;

    public BaseApiController(ILogger<BaseApiController> logger)
    {
        _logger = logger;
    }

    protected IActionResult ReturnErrorResult(Result result)
    {
        _logger.LogError(result.Error);
        return StatusCode(500);
    }
}

