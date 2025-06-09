using Microsoft.AspNetCore.Mvc;
using Test2A.DTOs;
using Test2A.Services;

namespace Test2A.Controllers;

[ApiController]
[Route("api/washing-machines")]
public class WashingMachinesController : ControllerBase
{
    private readonly IWashingMachineService _service;
    public WashingMachinesController(IWashingMachineService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> AddWashingMachine([FromBody] WashingMachineCreateDTO dto)
    {
        try
        {
            await _service.AddWashingMachineAsync(dto);
            return Ok("Washing machine added.");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}