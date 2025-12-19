using System;
using System.ComponentModel.DataAnnotations;

namespace MeuConsultorioPsi.Application.Dtos.Treatment;

public class UpdateTreatment
{
    [Required(ErrorMessage = "O ID do terapeuta é obrigatório")]
    public Guid TherapistId { get; set; }

    [Required(ErrorMessage = "O ID do paciente é obrigatório")]
    public Guid PatientId { get; set; }

    [Required(ErrorMessage = "A data de início é obrigatória")]
    [DataType(DataType.Date, ErrorMessage = "Data de início inválida")]
    public DateTime StartDate { get; set; }

    [DataType(DataType.Date, ErrorMessage = "Data de término inválida")]
    public DateTime? EndDate { get; set; }

    [Required(ErrorMessage = "O status ativo/inativo é obrigatório")]
    public bool IsActive { get; set; }
}
