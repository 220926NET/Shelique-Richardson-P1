using Microsoft.AspNetCore.Mvc;

namespace ERSapi.Controllers;

[ApiController]
[Route("[controller]")]
public class ERSapiController : ControllerBase
{

    private readonly ILogger<ERSapiController> _logger;

    public ERSapiController(ILogger<ERSapiController> logger)
    {
        _logger = logger;
    }

   
}