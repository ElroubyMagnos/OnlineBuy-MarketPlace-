using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Online_Buy_Plus.Controllers;

[ApiController]
[Route("[controller]")]
public class GetCatController : ControllerBase
{
    private readonly ILogger<GetCatController> _logger;

    public GetCatController(ILogger<GetCatController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public List<Category> Get()
    {
        ef Context = new ef();
        return Context.Categories.ToList();
    }
}
