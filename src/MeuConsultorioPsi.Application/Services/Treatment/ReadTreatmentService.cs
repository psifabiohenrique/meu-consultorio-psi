using MeuConsultorioPsi.Application.Dtos.Treatment;
using MeuConsultorioPsi.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeuConsultorioPsi.Application.Services.Treatment;

public class ReadTreatmentService
{
    private readonly AppDbContext _context;

    public ReadTreatmentService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ReadTreatment> ExecuteAsync(Guid id)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentNullException(nameof(id), "Não foi fornecido um ID válido.");
        }

        var treatment = await _context.Treatments.FirstOrDefaultAsync(t => t.Id == id);
        if (treatment is null)
        {
            throw new ArgumentNullException(nameof(id), "É Necessário um ID existente para acessar um tratamento.");
        }

        return new ReadTreatment
        {
            Id = treatment.Id,
            TherapistId = treatment.TherapistId,
            PatientId = treatment.PatientId,
            StartDate = treatment.StartDate,
            EndDate = treatment.EndDate,
            IsActive = treatment.IsActive,
        };
    }
}
