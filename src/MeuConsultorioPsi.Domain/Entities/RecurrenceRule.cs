using System;
using MeuConsultorioPsi.Domain.Enums;

namespace MeuConsultorioPsi.Domain.Entities;

public class RecurrenceRule
{
    public Guid Id { get; private set; }
    public Guid TreatmentId { get; private set; }
    public RecurrenceFrequency Frequency {get; private set;}
    public DayOfWeek DayOfWeek { get; private set; }
    public TimeSpan StartTime { get; private set; }
    public int DurationMinutes { get; private set; }
    public bool IsActive { get; private set; }
}
