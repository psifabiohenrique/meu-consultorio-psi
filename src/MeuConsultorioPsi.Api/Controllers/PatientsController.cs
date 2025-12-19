using MeuConsultorioPsi.Application.Dtos.Patient;
using MeuConsultorioPsi.Application.Services.Patient;
using Microsoft.AspNetCore.Mvc;

namespace MeuConsultorioPsi.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PatientsController : ControllerBase
{
    private readonly CreatePatientService _createPatientService;
    private readonly ReadPatientService _readPatientService;
    private readonly ReadAllPatientsService _readAllPatientsService;
    private readonly UpdatePatientService _updatePatientService;

    public PatientsController(
        CreatePatientService createPatientService,
        ReadPatientService readPatientService,
        ReadAllPatientsService readAllPatientsService,
        UpdatePatientService updatePatientService)
    {
        _createPatientService = createPatientService;
        _readPatientService = readPatientService;
        _readAllPatientsService = readAllPatientsService;
        _updatePatientService = updatePatientService;
    }

    [HttpPost]
    public async Task<ActionResult<ReadPatient>> Create([FromBody] CreatePatient dto)
    {
        var result = await _createPatientService.ExecuteAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ReadPatient>>> GetAll()
    {
        var result = await _readAllPatientsService.ExecuteAsync();
        return Ok(result);
    } 

    [HttpGet("{id}")]
    public async Task<ActionResult<ReadPatient>> GetById(Guid id)
    {
        var result = await _readPatientService.ExecuteAsync(id);
        return Ok(result);
    }

    [HttpGet("by-therapist/{therapistId}")]
    public async Task<ActionResult<IEnumerable<ReadPatient>>> GetByTherapist(Guid therapistId, [FromQuery] int? pageNumber = null, [FromQuery] int? pageSize = null)
    {
        var result = await _readAllPatientsService.ExecuteAsync(therapistId, pageNumber, pageSize);
        return Ok(result);
    }

    [HttpPut]
    public async Task<ActionResult<ReadPatient>> Update(Guid id, [FromBody] UpdatePatient dto)
    {
        var result = await _updatePatientService.ExecuteAsync(id, dto);
        return Ok(result);
    }
}
