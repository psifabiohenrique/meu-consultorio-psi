using System;
using System.ComponentModel.DataAnnotations;

namespace MeuConsultorioPsi.Application.Dtos.Appointment;

public class CreateAppointment
{
    [Required(ErrorMessage = "O ID do tratamento é obrigatório")]
    public Guid TreatmentId { get; set; }

    [Required(ErrorMessage = "A data e hora de início são obrigatórias")]
    [DataType(DataType.DateTime, ErrorMessage = "Data e hora de início inválidas")]
    public DateTime StartAt { get; set; }

    [Required(ErrorMessage = "A data e hora de término são obrigatórias")]
    [DataType(DataType.DateTime, ErrorMessage = "Data e hora de término inválidas")]
    public DateTime EndAt { get; set; }
}
