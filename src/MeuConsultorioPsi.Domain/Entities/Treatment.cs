using System;

namespace MeuConsultorioPsi.Domain.Entities;

public class Treatment
{
    public Guid Id { get; private set; }
    public Guid TherapistId { get; private set; }
    public Guid PatientId { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime? EndDate { get; private set; }
    public bool IsActive { get; private set; }

    protected Treatment() { }

    public static Treatment Create(Guid therapistId, Guid patientId, DateTime startDate)
    {
        if (therapistId == Guid.Empty)
        {
            throw new ArgumentException("O ID do terapeuta é obrigatório", nameof(therapistId));
        }

        if (patientId == Guid.Empty)
        {
            throw new ArgumentException("O ID do paciente é obrigatório", nameof(patientId));
        }

        if (startDate == default)
        {
            throw new ArgumentException("A data de início é obrigatória", nameof(startDate));
        }

        return new Treatment
        {
            Id = Guid.NewGuid(),
            TherapistId = therapistId,
            PatientId = patientId,
            StartDate = startDate,
            EndDate = null,
            IsActive = true
        };
    }

    public void Update(Guid therapistId, Guid patientId, DateTime startDate, DateTime? endDate, bool isActive)
    {
        if (therapistId == Guid.Empty)
        {
            throw new ArgumentException("O ID do terapeuta é obrigatório", nameof(therapistId));
        }

        if (patientId == Guid.Empty)
        {
            throw new ArgumentException("O ID do paciente é obrigatório", nameof(patientId));
        }

        if (startDate == default)
        {
            throw new ArgumentException("A data de início é obrigatória", nameof(startDate));
        }

        TherapistId = therapistId;
        PatientId = patientId;
        StartDate = startDate;
        EndDate = endDate;
        IsActive = isActive;
    }
}
