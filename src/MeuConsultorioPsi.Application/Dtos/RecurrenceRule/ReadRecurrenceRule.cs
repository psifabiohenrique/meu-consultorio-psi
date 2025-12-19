using System;
using MeuConsultorioPsi.Domain.Enums;

namespace MeuConsultorioPsi.Application.Dtos.RecurrenceRule;

public class ReadRecurrenceRule
{
    public Guid Id { get; set; }
    public Guid TreatmentId { get; set; }
    public RecurrenceFrequency Frequency { get; set; }
    public DayOfWeek DayOfWeek { get; set; }
    public TimeSpan StartTime { get; set; }
    public int DurationMinutes { get; set; }
    public bool IsActive { get; set; }
}
