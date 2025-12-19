using MeuConsultorioPsi.Application.Dtos.Treatment;
using MeuConsultorioPsi.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeuConsultorioPsi.Application.Services.Treatment;

public class CreateTreatmentService
{
    private readonly AppDbContext _context;

    public CreateTreatmentService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ReadTreatment> ExecuteAsync(CreateTreatment dto)
    {
        if (dto is null)
        {
            throw new ArgumentNullException(nameof(dto), "Tratamento ausênte na criação");
        }

        var patient = await _context.Patients.FirstOrDefaultAsync(p => p.Id == dto.PatientId);
        if (patient is null)
        {
            throw new ArgumentException(nameof(patient), "É necessário fornecer um paciente já cadastrado");
        }
        var therapist = await _context.Therapists.FirstOrDefaultAsync(t => t.Id == dto.TherapistId);

        if (therapist is null)
        {
            throw new ArgumentException(nameof(patient), "É necessário fornecer um terapeuta já cadastrado");
        }

        var treatmentExists = await _context.Treatments.AnyAsync(t =>
            t.TherapistId == therapist.Id &&
            t.PatientId == patient.Id
            );

        if (treatmentExists)
        {
            throw new ArgumentException("O tratamento já existe. Não é possível iniciar um tratamento duplicado");
        }

        Domain.Entities.Treatment treatment = Domain.Entities.Treatment.Create(
            dto.TherapistId,
            dto.PatientId,
            dto.StartDate
            );

        await _context.Treatments.AddAsync(treatment);
        await _context.SaveChangesAsync();

        return new ReadTreatment
        {
            Id = treatment.Id,
            TherapistId = treatment.TherapistId,
            PatientId = treatment.PatientId,
            StartDate = treatment.StartDate,
            EndDate = treatment.EndDate,
            IsActive = treatment.IsActive
        };
    }
}
