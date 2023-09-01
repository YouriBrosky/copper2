using ManagerOne.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ManagerOne.Hosting.Controllers;

[ApiController]
[Route("[controller]")]
public class DataController : ControllerBase
{
    private readonly ILogger<DataController> _logger;
    private readonly IManagerOne _managerOne;
    
    public DataController(ILogger<DataController> logger, IManagerOne managerOne)
    {
        _logger = logger;
        _managerOne = managerOne;
    }

    [HttpGet(Name = "Get")]
    public async Task<ActionResult<Person>> Get(int amount)
    {
        var data = await _managerOne.GetPeople(amount);
        var dataArray = data.ToArray();
        
        if (data == null)
        {
            _logger.LogError("Data not found");
            return NotFound();
        }
        
        _logger.LogInformation("Data retrieved successfully");
        return Ok(dataArray);
    }
}