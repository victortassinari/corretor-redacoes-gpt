using backend.Application.Interfaces;
using backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[Route("api/essay-text")]
[ApiController]

public class EssayTextCorretionController : ControllerBase
{
    private readonly IGptEssayCorrectionService _correctionService;

    public EssayTextCorretionController(IGptEssayCorrectionService correctionService)
    {
        _correctionService = correctionService;
    }

    [HttpPost("correct")]
    public async Task CorrectEssay([FromBody] EssayTextInput input)
    {
        HttpContext.Response.ContentType = "text/plain; charset=utf-8";

        await foreach (var result in _correctionService.CorrectEssayAsync(input))
        {
            await HttpContext.Response.WriteAsync(result);
            await HttpContext.Response.Body.FlushAsync();
        }
    }
}
