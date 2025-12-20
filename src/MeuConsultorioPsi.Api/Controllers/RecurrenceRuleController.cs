using MeuConsultorioPsi.Application.Dtos.RecurrenceRule;
using MeuConsultorioPsi.Application.Services.RecurrenceRule;
using Microsoft.AspNetCore.Mvc;

namespace MeuConsultorioPsi.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RecurrenceRuleController : ControllerBase
{
    private readonly CreateRecurrenceRuleService _createRecurrenceRuleService;
    private readonly ReadAllRecurrenceRulesService _readAllRecurrenceRulesService;
    private readonly ReadRecurrenceRuleService _readRecurrenceRuleService;
    private readonly UpdateRecurrenceRuleService _updateRecurrenceRuleService;

    public RecurrenceRuleController(CreateRecurrenceRuleService createRecurrenceRuleService, ReadAllRecurrenceRulesService readAllRulesService, ReadRecurrenceRuleService readRecurrenceRuleService, UpdateRecurrenceRuleService updateRecurrenceRuleService)
    {
        _createRecurrenceRuleService = createRecurrenceRuleService;
        _readAllRecurrenceRulesService = readAllRulesService;
        _readRecurrenceRuleService = readRecurrenceRuleService;
        _updateRecurrenceRuleService = updateRecurrenceRuleService;
    }

    [HttpPost]
    public async Task<ActionResult<ReadRecurrenceRule>> Create([FromBody] CreateRecurrenceRule dto)
    {
        var recurrenceRule =  await _createRecurrenceRuleService.ExecuteAsync(dto);
        return Ok(recurrenceRule);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ReadRecurrenceRule>>> GetAll(int? pageNumber = null, int? pageSize = null)
    {
        var recurrenceRule = await _readAllRecurrenceRulesService.ExecuteAsync(pageNumber, pageSize);
        return Ok(recurrenceRule);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ReadRecurrenceRule>> GetById(Guid id)
    {
        var recurrenceRule = await _readRecurrenceRuleService.ExecuteAsync(id);
        return Ok(recurrenceRule);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(Guid id, [FromBody] UpdateRecurrenceRule dto)
    {
        var recurrenceRule = await _updateRecurrenceRuleService.ExecuteAsync(id, dto);
        return Ok(recurrenceRule);
    }
}
