using MeuConsultorioPsi.Application.Dtos.Treatment;
using MeuConsultorioPsi.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeuConsultorioPsi.Application.Services.Treatment;

public class ReadAllTreatmentsService
{
    private readonly AppDbContext _context;

    public ReadAllTreatmentsService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ReadTreatment>> ExecuteAsync(int? pageNumber = null, int? pageSize = null)
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

        var query = _context.Treatments.AsQueryable();

        if (pageNumber.HasValue && pageSize.HasValue)
        {
            int skip = (pageNumber.Value - 1) * pageSize.Value;
            query = query.Skip(skip).Take(pageSize.Value);
        }

        var result = await query.Select(t => new ReadTreatment
        {
            Id = t.Id,
            TherapistId = t.TherapistId,
            PatientId = t.PatientId,
            StartDate = t.StartDate,
            EndDate = t.EndDate,
            IsActive = t.IsActive,
        }).ToListAsync();

        return result;
    }
}
