using System;
using MeuConsultorioPsi.Application.Dtos.Appointment;
using MeuConsultorioPsi.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace MeuConsultorioPsi.Application.Services.Appointment;

public class UpdateAppointmentService
{
    private readonly AppDbContext _context;

    public UpdateAppointmentService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ReadAppointment> ExecuteAsync(Guid id, UpdateAppointment dto)
    {
        if (id == Guid.Empty) throw new ArgumentNullException("É preciso enviar um ID de regra de agendamento válido");

        var appointment = await _context.Appointments.FirstOrDefaultAsync(a => a.Id == id);

        if (appointment is null) throw new ArgumentException("É preciso enviar um ID de agendamento existente");

        appointment.Update(
            dto.TreatmentId,
            dto.StartAt,
            dto.EndAt,
            dto.Status
        );
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
