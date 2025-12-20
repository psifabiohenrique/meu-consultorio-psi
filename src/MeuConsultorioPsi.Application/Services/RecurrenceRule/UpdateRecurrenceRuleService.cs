using System;
using MeuConsultorioPsi.Application.Dtos.RecurrenceRule;
using MeuConsultorioPsi.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace MeuConsultorioPsi.Application.Services.RecurrenceRule;

public class UpdateRecurrenceRuleService
{
    private readonly AppDbContext _context;

    public UpdateRecurrenceRuleService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ReadRecurrenceRule> ExecuteAsync(Guid id, UpdateRecurrenceRule dto)
    {
        if (id == Guid.Empty) throw new ArgumentNullException("É preciso enviar um ID de regra de recorrência válido");
        
        var recurrenceRule = await _context.RecurrenceRules.FirstOrDefaultAsync(r => r.Id == id);

        if (recurrenceRule is null) throw new ArgumentException("É preciso enviar um ID de regra de recorrência existente");

        recurrenceRule.Update(
            dto.TreatmentId,
            dto.Frequency,
            dto.DayOfWeek,
            TimeOnly.Parse(dto.StartTime),
            dto.DurationMinutes,
            dto.IsActive
        );
        await _context.SaveChangesAsync();
        return new ReadRecurrenceRule
        {
            Id = recurrenceRule.Id,
            TreatmentId = recurrenceRule.TreatmentId,
            DayOfWeek = recurrenceRule.DayOfWeek,
            DurationMinutes = recurrenceRule.DurationMinutes,
            Frequency = recurrenceRule.Frequency,
            IsActive = recurrenceRule.IsActive,
            StartTime = recurrenceRule.StartTime.ToString()
        };
    }
}
