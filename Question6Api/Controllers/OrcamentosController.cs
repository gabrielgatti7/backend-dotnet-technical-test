using Microsoft.AspNetCore.Mvc;
using TechnicalTest.Question6.Dtos;
using TechnicalTest.Question6.Services;

namespace Question6Api.Controllers;

[ApiController]
[Route("api/orcamentos")]
public class OrcamentosController : ControllerBase
{
    private readonly OrcamentoService _service;

    public OrcamentosController(OrcamentoService service)
    {
        _service = service;
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetById(Guid id)
    {
        var result = _service.GetById(id);

        if (!result.IsSuccess)
        {
            return NotFound(new
            {
                success = false,
                message = result.Message
            });
        }

        return Ok(new
        {
            success = true,
            data = result.Data
        });
    }

    [HttpPost]
    public IActionResult Create(CreateOrcamentoDto dto)
    {
        var result = _service.Create(dto);

        if (!result.IsSuccess)
            return BadRequest(new
            {
                success = false,
                message = result.Message
            });

        return CreatedAtAction(
            nameof(Create),
            new { id = result.Data!.Id },
            new
            {
                success = true,
                message = result.Message,
                data = result.Data
            });
    }
}