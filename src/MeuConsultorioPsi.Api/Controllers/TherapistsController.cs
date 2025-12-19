using MeuConsultorioPsi.Application.Dtos.Therapist;
using MeuConsultorioPsi.Application.Services.Therapist;
using Microsoft.AspNetCore.Mvc;

namespace MeuConsultorioPsi.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TherapistsController : ControllerBase
{
    private readonly CreateTherapistService _createTherapistService;
    private readonly ReadTherapistService _readTherapistService;
    private readonly ReadAllTherapistsService _readAllTherapistsService;
    private readonly UpdateTherapistService _updateTherapistService;

    public TherapistsController(
        CreateTherapistService createTherapistService,
        ReadTherapistService readTherapistService,
        ReadAllTherapistsService readAllTherapistsService,
        UpdateTherapistService updateTherapistService)
    {
        _createTherapistService = createTherapistService;
        _readTherapistService = readTherapistService;
        _readAllTherapistsService = readAllTherapistsService;
        _updateTherapistService = updateTherapistService;
    }

    [HttpPost]
    public async Task<ActionResult<ReadTherapist>> Create([FromBody] CreateTherapist dto)
    {
        var result = await _createTherapistService.ExecuteAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ReadTherapist>> GetById(Guid id)
    {
        var result = await _readTherapistService.ExecuteAsync(id);
        return Ok(result);
    }

    [HttpGet]
    public async Task<ActionResult<List<ReadTherapist>>> GetAll()
    {
        var result = await _readAllTherapistsService.ExecuteAsync();
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ReadTherapist>> Update(Guid id, [FromBody] UpdateTherapist dto)
    {
        var result = await _updateTherapistService.ExecuteAsync(id, dto);
        return Ok(result);
    }
}
