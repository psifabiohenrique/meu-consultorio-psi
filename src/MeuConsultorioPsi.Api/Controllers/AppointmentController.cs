using System;
using MeuConsultorioPsi.Application.Dtos.Appointment;
using MeuConsultorioPsi.Application.Services.Appointment;
using Microsoft.AspNetCore.Mvc;

namespace MeuConsultorioPsi.Api.Controllers;


[ApiController]
[Route("api/[controller]")]
public class AppointmentController : ControllerBase
{
    private readonly CreateAppointmentService _createAppointmentService;


    private readonly ReadAllAppointmentsService _readAllAppointmentsService;
    private readonly ReadAppointmentService _readAppointmentService;
    private readonly UpdateAppointmentService _updateAppointmentService;

    public AppointmentController(CreateAppointmentService createAppointmentService, ReadAllAppointmentsService readAllAppointmentsService, ReadAppointmentService readAppointmentService, UpdateAppointmentService updateAppointmentService)
    {
        _createAppointmentService = createAppointmentService;
        _readAllAppointmentsService = readAllAppointmentsService;
        _readAppointmentService = readAppointmentService;
        _updateAppointmentService = updateAppointmentService;
    }

    [HttpPost]
    public async Task<ActionResult<ReadAppointment>> Create([FromBody] CreateAppointment dto)
    {
        var appointment = _createAppointmentService.ExecuteAsync(dto);
        return Ok(appointment);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ReadAppointment>>> GetAll(int? pageNumber = null, int? pageSize = null)
    {
        var appointment = _readAllAppointmentsService.ExecuteAsync(pageNumber, pageSize);
        return Ok(appointment);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ReadAppointment>> GetById(Guid id)
    {
        var appointment = _readAppointmentService.ExecuteAsync(id);
        return Ok(appointment);
    }

    [HttpPut]
    public async Task<ActionResult<ReadAppointment>> Update(Guid id, [FromBody] UpdateAppointment dto)
    {
        var appointment = _updateAppointmentService.ExecuteAsync(id, dto);
        return Ok(appointment);
    }
}
