using System;
using MeuConsultorioPsi.Application.Dtos.Appointment;
using MeuConsultorioPsi.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace MeuConsultorioPsi.Application.Services.Appointment;

public class ReadAppointmentService
{
    private readonly AppDbContext _context;

    public ReadAppointmentService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ReadAppointment> ExecuteAsync(Guid id)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentNullException(nameof(id));
        }
        var appointment = await _context.Appointments.FirstOrDefaultAsync(a => a.Id == id);
        
        if (appointment is null) throw new ArgumentException("O ID enviado não corresponde a uma instância válida de agendamento");

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
