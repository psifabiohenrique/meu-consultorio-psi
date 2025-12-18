using System;
using MeuConsultorioPsi.Domain.Enums;

namespace MeuConsultorioPsi.Domain.Entities;

public class Appointment
{
    public Guid Id { get; private set; }
    public Guid TreatmentId { get; private set; }
    public DateTime StartAt { get; private set; }
    public DateTime EndAt { get; private set; }
    public AppointmentStatus Status { get; private set; }
}
