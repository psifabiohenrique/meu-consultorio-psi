using MeuConsultorioPsi.Application.Dtos.RecurrenceRule;
using MeuConsultorioPsi.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeuConsultorioPsi.Application.Services.RecurrenceRule;

public class ReadRecurrenceRuleService
{
    private readonly AppDbContext _context;

    public ReadRecurrenceRuleService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ReadRecurrenceRule> ExecuteAsync(Guid id)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentNullException(nameof(id));
        }

        var recurrenceRule = await _context.RecurrenceRules.FirstOrDefaultAsync(r => r.Id == id);
        if (recurrenceRule is null)
        {
            throw new ArgumentException("O ID enviado não corresponde a uma instância válida de regra de recorrência");
        }

        return new ReadRecurrenceRule
        {
            Id = recurrenceRule.Id,
            TreatmentId = recurrenceRule.TreatmentId,
            Frequency = recurrenceRule.Frequency,
            DayOfWeek = recurrenceRule.DayOfWeek,
            StartTime = recurrenceRule.StartTime.ToString(),
            DurationMinutes = recurrenceRule.DurationMinutes,
            IsActive = recurrenceRule.IsActive
        };
    }
}
