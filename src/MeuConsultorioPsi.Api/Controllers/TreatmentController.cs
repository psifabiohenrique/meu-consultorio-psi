using MeuConsultorioPsi.Application.Dtos.Treatment;
using MeuConsultorioPsi.Application.Services.Treatment;
using Microsoft.AspNetCore.Mvc;

namespace MeuConsultorioPsi.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TreatmentController : ControllerBase
{
    private readonly CreateTreatmentService _createTreatmentService;
    private readonly ReadAllTreatmentsService _readAllTreatmentsService;
    private readonly ReadTreatmentService _readTreatmentService;
    private readonly UpdateTreatmentService _updateTreatmentService;

    public TreatmentController(CreateTreatmentService createTreatmentService, ReadAllTreatmentsService readAllTreatmentsService, ReadTreatmentService readTreatmentService, UpdateTreatmentService updateTreatmentService)
    {
        _createTreatmentService = createTreatmentService;
        _readAllTreatmentsService = readAllTreatmentsService;
        _readTreatmentService = readTreatmentService;
        _updateTreatmentService = updateTreatmentService;
    }

    [HttpPost]
    public async Task<ActionResult<ReadTreatment>> Create([FromBody] CreateTreatment dto)
    {
        var treatment = _createTreatmentService.ExecuteAsync(dto);
        return Ok(treatment);
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ReadTreatment>>> GetAll(int? pageNumber = null, int? pageSize = null)
    {
        var treatment = await _readAllTreatmentsService.ExecuteAsync(pageNumber, pageSize);
        return Ok(treatment);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ReadTreatment>> GetById(Guid id)
    {
        ReadTreatment treatment = await _readTreatmentService.ExecuteAsync(id);
        return Ok(treatment);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ReadTreatment>> Update(Guid id, [FromBody] UpdateTreatment dto)
    {
        ReadTreatment treatment = await _updateTreatmentService.ExecuteAsync(id, dto);
        return Ok(treatment);
    }
}
