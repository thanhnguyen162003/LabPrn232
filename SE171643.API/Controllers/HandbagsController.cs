using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SE171643.Service.Abstractions;
using SE171643.Service.Models.HandbagModels;
using SE171643.Service.Security;

namespace SE171643.API.Controllers;

[ApiController]
[Route("api/handbags")]
public class HandbagsController(IHandbagService handbagService) : ControllerBase
{
    [HttpGet]
    [Authorize(Roles = "administrator,moderator,developer,member")]
    public async Task<IActionResult> GetAll()
    {
        var result = await handbagService.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize(Roles = "administrator,moderator,developer,member")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await handbagService.GetByIdAsync(id);
        if (result == null)
            return NotFound(ErrorResponse.HB40401("Handbag not found"));
        return Ok(result);
    }

    [HttpPost]
    [Authorize(Roles = "administrator,moderator")]
    public async Task<IActionResult> Create([FromBody] HandbagCreateRequest request)
    {
        if (!ModelState.IsValid)
        {
            var error = ModelState.Values.SelectMany(v => v.Errors).FirstOrDefault()?.ErrorMessage ?? "Invalid input";
            return BadRequest(ErrorResponse.HB40001(error));
        }
        var result = await handbagService.CreateAsync(request);
        if (!result.Success)
        {
            if (result.ErrorCode == "HB40001")
                return BadRequest(ErrorResponse.HB40001(result.ErrorMessage!));
            if (result.ErrorCode == "HB40301")
                return StatusCode(403, ErrorResponse.HB40301(result.ErrorMessage!));
        }
        return CreatedAtAction(nameof(GetById), new { id = result.Data!.HandbagId }, result.Data);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "administrator,moderator")]
    public async Task<IActionResult> Update(int id, [FromBody] HandbagUpdateRequest request)
    {
        if (!ModelState.IsValid)
        {
            var error = ModelState.Values.SelectMany(v => v.Errors).FirstOrDefault()?.ErrorMessage ?? "Invalid input";
            return BadRequest(ErrorResponse.HB40001(error));
        }
        var result = await handbagService.UpdateAsync(id, request);
        if (!result.Success)
        {
            if (result.ErrorCode == "HB40001")
                return BadRequest(ErrorResponse.HB40001(result.ErrorMessage!));
            if (result.ErrorCode == "HB40401")
                return NotFound(ErrorResponse.HB40401(result.ErrorMessage!));
            if (result.ErrorCode == "HB40301")
                return StatusCode(403, ErrorResponse.HB40301(result.ErrorMessage!));
        }
        return Ok(result.Data);
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "administrator,moderator")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await handbagService.DeleteAsync(id);
        if (!result.Success)
        {
            if (result.ErrorCode == "HB40401")
                return NotFound(ErrorResponse.HB40401(result.ErrorMessage!));
            if (result.ErrorCode == "HB40301")
                return StatusCode(403, ErrorResponse.HB40301(result.ErrorMessage!));
        }
        return Ok();
    }

    [HttpGet("search")]
    [Authorize]
    public async Task<IActionResult> Search([FromQuery] string? modelName, [FromQuery] string? material)
    {
        var result = await handbagService.SearchAsync(modelName, material);
        return Ok(result);
    }
} 