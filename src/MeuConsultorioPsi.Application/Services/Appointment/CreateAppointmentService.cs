using System;
using MeuConsultorioPsi.Application.Dtos.Appointment;
using MeuConsultorioPsi.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace MeuConsultorioPsi.Application.Services.Appointment;

public class CreateAppointmentService
{
    private readonly AppDbContext _context;

    public CreateAppointmentService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ReadAppointment> ExecuteAsync (CreateAppointment dto)
    {
        if (dto is null) throw new ArgumentNullException(nameof(dto), "O DTO de Agendamento não pode ser nulo.");

        var treatment = await _context.Treatments.FirstOrDefaultAsync(t => t.Id == dto.TreatmentId);

        if (treatment is null) throw new ArgumentException("Tratamento não encontrado para criar o Agendamento.", nameof(dto));

        var appointment = Domain.Entities.Appointment.Create(
            dto.TreatmentId,
            dto.StartAt,
            dto.EndAt
        );

        await _context.Appointments.AddAsync(appointment);
        await _context.SaveChangesAsync();

        return new ReadAppointment
        {
          Id = appointment.Id,
          TreatmentId = appointment.TreatmentId,
          StartAt = appointment.StartAt,
          EndAt = appointment.EndAt,
          Status = appointment.Status
        };
    }
}
