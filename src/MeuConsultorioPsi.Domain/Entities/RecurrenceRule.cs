using System;
using MeuConsultorioPsi.Domain.Enums;

namespace MeuConsultorioPsi.Domain.Entities;

public class RecurrenceRule
{
    public Guid Id { get; private set; }
    public Guid TreatmentId { get; private set; }
    public RecurrenceFrequency Frequency { get; private set; }
    public DayOfWeek DayOfWeek { get; private set; }
    public TimeOnly StartTime { get; private set; }
    public int DurationMinutes { get; private set; }
    public bool IsActive { get; private set; }

    protected RecurrenceRule() { }

    public static RecurrenceRule Create(
        Guid treatmentId,
        RecurrenceFrequency frequency,
        DayOfWeek dayOfWeek,
        TimeOnly startTime,
        int durationMinutes)
    {
        if (treatmentId == Guid.Empty)
        {
            throw new ArgumentException("O ID do tratamento é obrigatório", nameof(treatmentId));
        }

        if (!Enum.IsDefined(typeof(RecurrenceFrequency), frequency))
        {
            throw new ArgumentException("A frequência de recorrência é inválida", nameof(frequency));
        }

        if (!Enum.IsDefined(typeof(DayOfWeek), dayOfWeek))
        {
            throw new ArgumentException("O dia da semana é inválido", nameof(dayOfWeek));
        }

        if (durationMinutes <= 0 || durationMinutes > 480)
        {
            throw new ArgumentException("A duração deve estar entre 1 e 480 minutos", nameof(durationMinutes));
        }

        return new RecurrenceRule
        {
            Id = Guid.NewGuid(),
            TreatmentId = treatmentId,
            Frequency = frequency,
            DayOfWeek = dayOfWeek,
            StartTime = startTime,
            DurationMinutes = durationMinutes,
            IsActive = true
        };
    }

    public void Update(
        Guid treatmentId,
        RecurrenceFrequency frequency,
        DayOfWeek dayOfWeek,
        TimeOnly startTime,
        int durationMinutes,
        bool isActive
        )
    {
        if (treatmentId == Guid.Empty)
        {
            throw new ArgumentException("O ID do tratamento é obrigatório", nameof(treatmentId));
        }

        if (!Enum.IsDefined(typeof(RecurrenceFrequency), frequency))
        {
            throw new ArgumentException("A frequência de recorrência é inválida", nameof(frequency));
        }

        if (!Enum.IsDefined(typeof(DayOfWeek), dayOfWeek))
        {
            throw new ArgumentException("O dia da semana é inválido", nameof(dayOfWeek));
        }

        if (durationMinutes <= 0 || durationMinutes > 480)
        {
            throw new ArgumentException("A duração deve estar entre 1 e 480 minutos", nameof(durationMinutes));
        }

        TreatmentId = treatmentId;
        Frequency = frequency;
        DayOfWeek = dayOfWeek;
        StartTime = startTime;
        DurationMinutes = durationMinutes;
        IsActive = true;
    }
}
