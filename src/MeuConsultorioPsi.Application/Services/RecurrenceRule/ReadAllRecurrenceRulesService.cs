using MeuConsultorioPsi.Application.Dtos.RecurrenceRule;
using MeuConsultorioPsi.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeuConsultorioPsi.Application.Services.RecurrenceRule;

public class ReadAllRecurrenceRulesService
{
    private readonly AppDbContext _context;

    public ReadAllRecurrenceRulesService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ReadRecurrenceRule>> ExecuteAsync(int? pageNumber = null, int? pageSize = null)
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

        var query = _context.RecurrenceRules.AsQueryable();

        if (pageNumber.HasValue && pageSize.HasValue)
        {
            int skip = (pageNumber.Value - 1) * pageSize.Value;
            query = query.Skip(skip).Take(pageSize.Value);
        }

        var result = query.Select(r => new ReadRecurrenceRule
        {
            Id = r.Id,
            TreatmentId = r.TreatmentId,
            Frequency = r.Frequency,
            DayOfWeek = r.DayOfWeek,
            StartTime = r.StartTime.ToString(),
            DurationMinutes = r.DurationMinutes,
            IsActive = r.IsActive,
        });
        return result;
    }
}
