using System;
using System.ComponentModel.DataAnnotations;
using MeuConsultorioPsi.Domain.Enums;

namespace MeuConsultorioPsi.Application.Dtos.RecurrenceRule;

public class UpdateRecurrenceRule
{
    [Required(ErrorMessage = "O ID do tratamento � obrigat�rio")]
    public Guid TreatmentId { get; set; }

    [Required(ErrorMessage = "A frequ�ncia � obrigat�ria")]
    public RecurrenceFrequency Frequency { get; set; }

    [Required(ErrorMessage = "O dia da semana � obrigat�rio")]
    public DayOfWeek DayOfWeek { get; set; }

    [Required(ErrorMessage = "A hora de in�cio � obrigat�ria")]
    public string StartTime { get; set; }

    [Required(ErrorMessage = "A dura��o em minutos � obrigat�ria")]
    [Range(1, 480, ErrorMessage = "A dura��o deve estar entre 1 e 480 minutos")]
    public int DurationMinutes { get; set; }

    [Required(ErrorMessage = "O status ativo/inativo � obrigat�rio")]
    public bool IsActive { get; set; }
}
