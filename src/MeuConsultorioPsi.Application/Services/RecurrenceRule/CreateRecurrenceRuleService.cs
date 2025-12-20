using MeuConsultorioPsi.Application.Dtos.RecurrenceRule;
using MeuConsultorioPsi.Domain.Enums;
using MeuConsultorioPsi.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace MeuConsultorioPsi.Application.Services.RecurrenceRule;

public class CreateRecurrenceRuleService
{
    private readonly AppDbContext _context;

    public CreateRecurrenceRuleService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ReadRecurrenceRule> ExecuteAsync(CreateRecurrenceRule dto)
    {
        if (dto is null)
        {
            throw new ArgumentNullException(nameof(dto), "Regra de recorrência ausênte na criação");
        }
        var treatment = await _context.Treatments.FirstOrDefaultAsync(t => t.Id == dto.TreatmentId);

        if (treatment is null)
        {
            throw new ArgumentException("Deve ser informado um ID de tratamento existente.", nameof(treatment));
        }

        if (!TimeOnly.TryParseExact(
            dto.StartTime,
            "HH:mm",
            CultureInfo.InvariantCulture,
            DateTimeStyles.None,
            out var startTime))
        {
            throw new ArgumentException("StartTime inválido. Use o formato HH:mm.");
        }

        var recurrenceRule = Domain.Entities.RecurrenceRule.Create(
            dto.TreatmentId,
            dto.Frequency,
            dto.DayOfWeek,
            TimeOnly.Parse(dto.StartTime),
            dto.DurationMinutes
            );

        await _context.RecurrenceRules.AddAsync(recurrenceRule);
        await _context.SaveChangesAsync();

        return new ReadRecurrenceRule
        {
            Id = recurrenceRule.Id,
            TreatmentId = recurrenceRule.TreatmentId,
            Frequency = recurrenceRule.Frequency,
            DayOfWeek = recurrenceRule.DayOfWeek,
            StartTime = recurrenceRule.StartTime.ToString(),
            DurationMinutes = recurrenceRule.DurationMinutes,
            IsActive = recurrenceRule.IsActive,
        };
    }
}
