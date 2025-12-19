using System;
using System.ComponentModel.DataAnnotations;
using MeuConsultorioPsi.Domain.Enums;

namespace MeuConsultorioPsi.Application.Dtos.RecurrenceRule;

public class UpdateRecurrenceRule
{
    [Required(ErrorMessage = "O ID do tratamento é obrigatório")]
    public Guid TreatmentId { get; set; }

    [Required(ErrorMessage = "A frequência é obrigatória")]
    public RecurrenceFrequency Frequency { get; set; }

    [Required(ErrorMessage = "O dia da semana é obrigatório")]
    public DayOfWeek DayOfWeek { get; set; }

    [Required(ErrorMessage = "A hora de início é obrigatória")]
    [DataType(DataType.DateTime, ErrorMessage = "Hora de início inválida")]
    public TimeSpan StartTime { get; set; }

    [Required(ErrorMessage = "A duração em minutos é obrigatória")]
    [Range(1, 480, ErrorMessage = "A duração deve estar entre 1 e 480 minutos")]
    public int DurationMinutes { get; set; }

    [Required(ErrorMessage = "O status ativo/inativo é obrigatório")]
    public bool IsActive { get; set; }
}
