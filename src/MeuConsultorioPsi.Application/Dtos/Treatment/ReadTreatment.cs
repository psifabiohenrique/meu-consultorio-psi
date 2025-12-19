using System;

namespace MeuConsultorioPsi.Application.Dtos.Treatment;

public class ReadTreatment
{
    public Guid Id { get; set; }
    public Guid TherapistId { get; set; }
    public Guid PatientId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public bool IsActive { get; set; }
}
