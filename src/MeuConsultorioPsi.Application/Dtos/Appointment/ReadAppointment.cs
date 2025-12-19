using System;
using MeuConsultorioPsi.Domain

using MeuConsultorioPsi.Domain.Enums;

namespace MeuConsultorioPsi.Application.Dtos.Appointment;

public class ReadAppointment
{
    public Guid Id { get; set; }
    public Guid TreatmentId { get; set; }
    public DateTime StartAt { get; set; }
    public DateTime EndAt { get; set; }
    public AppointmentStatus Status { get; set; }
}
