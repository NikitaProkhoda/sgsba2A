using Microsoft.AspNetCore.Mvc;
using Test2A.Services;

namespace Test2A.Controllers;

[ApiController]
[Route("api/customers")]
public class CustomersController : ControllerBase
{
    private readonly IWashingMachineService _service;
    public CustomersController(IWashingMachineService service)
    {
        _service = service;
    }

    [HttpGet("{id}/history")]
    public async Task<IActionResult> GetCustomerHistory(int id)
    {
        var history = await _service.GetCustomerHistory(id);
        return Ok(history);
    }
}