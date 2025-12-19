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

    protected Appointment() { }

    public static Appointment Create(Guid treatmentId, DateTime startAt, DateTime endAt)
    {
        if (treatmentId == Guid.Empty)
        {
            throw new ArgumentException("O ID do tratamento é obrigatório", nameof(treatmentId));
        }

        if (startAt == default)
        {
            throw new ArgumentException("A data e hora de início são obrigatórias", nameof(startAt));
        }

        if (endAt == default)
        {
            throw new ArgumentException("A data e hora de término são obrigatórias", nameof(endAt));
        }

        if (endAt <= startAt)
        {
            throw new ArgumentException("A data e hora de término deve ser posterior ao início", nameof(endAt));
        }

        return new Appointment
        {
            Id = Guid.NewGuid(),
            TreatmentId = treatmentId,
            StartAt = startAt,
            EndAt = endAt,
            Status = AppointmentStatus.Scheduled
        };
    }
}
