using System;
using MeuConsultorioPsi.Application.Dtos.Appointment;
using MeuConsultorioPsi.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace MeuConsultorioPsi.Application.Services.Appointment;

public class ReadAllAppointmentsService
{
    private readonly AppDbContext _context;

    public ReadAllAppointmentsService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ReadAppointment>> ExecuteAsync(int? pageNumber = null, int? pageSize =null)
    {
        if (pageNumber.HasValue || pageSize.HasValue)
        {
            if (!pageNumber.HasValue || !pageSize.HasValue)
            {
                throw new ArgumentException(
                    "Ambos pageNumber e pageSize devem ser fornecidos ou nenhum deles");
            }

            if (pageNumber < 1)
            {
                throw new ArgumentException("O número da página deve ser maior que 0", nameof(pageNumber));
            }

            if (pageSize < 1 || pageSize > 100)
            {
                throw new ArgumentException("O tamanho da página deve estar entre 1 e 100", nameof(pageSize));
            }
        }

        var query = _context.Appointments.AsQueryable();

        if (pageNumber.HasValue && pageSize.HasValue)
        {
            int skip = (pageNumber.Value - 1) * pageSize.Value;
            query = query.Skip(skip).Take(pageSize.Value);
        }

        var result = await query.Select(a => new ReadAppointment
        {
            Id = a.Id,
            TreatmentId = a.TreatmentId,
            StartAt = a.StartAt,
            EndAt = a.EndAt,
            Status = a.Status
        }).ToListAsync();

        return result;
    }
}
