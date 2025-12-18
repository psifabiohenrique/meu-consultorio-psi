using System;

namespace MeuConsultorioPsi.Domain.Entities;

public class Treatment
{
    public Guid Id { get; private set; }
    public Guid TherapistId { get; private set; }
    public Guid PatientId { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime? EndDate { get; private set;}
    public bool IsActive { get; private set; }
}
